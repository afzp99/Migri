using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



return await App.Run(args);

public record SessionIdentity(string UserId);
public record ClientParameters(string Name = "Ikon");

public record Application(string Id, string ApplicantName, string Status, string SubmissionDate, string ApplicationType, string Nationality);
public record DocumentItem(string Name, string Type, string Size, string UploadDate, string Status, string IconName, string Url = "", Dictionary<string, string>? CheckedValues = null);
public record HistoryEvent(string Date, string Time, string Action, string Actor, string Detail, string IconName, string ColorClass);
public record ChecklistItem(string Requirement, string Status, DocumentItem? MatchedDocument = null); // Status: "fulfilled", "pending", "under-review", "missing"

[App]
public class MigriApp(IApp<SessionIdentity, ClientParameters> app)
{
    private UI UI { get; } = new(app, new Theme());

    private readonly Reactive<List<Application>> _applications = new(new List<Application>
    {
        new("APP-2026-001", "Matti Meik\u00e4l\u00e4inen", "In Progress", "2026-03-20", "Student Residence Permit", "Russian Federation"),
        new("APP-2026-002", "Elena Sokolova", "Pending Additional Info", "2026-03-24", "Work Residence Permit", "Russian Federation"),
        new("APP-2026-003", "Ahmad Al-Fayed", "Approved", "2026-03-26", "Work Residence Permit", "Egypt"),
        new("APP-2026-004", "Chen Wei", "Approved", "2026-03-15", "Family Member Residence Permit", "China")
    });

    private readonly ClientReactive<Application?> _selectedApplication = new(null);
    private readonly ClientReactive<string> _currentTheme = new(Constants.LightTheme);
    private readonly ClientReactive<string> _currentPath = new("");
    private readonly ClientReactive<string> _activeTab = new("overview");
    private readonly ClientReactive<bool> _pdfDialogOpen = new(false);
    private readonly ClientReactive<string> _pdfDialogUrl = new("");
    private readonly ClientReactive<string> _pdfSearchText = new("");
    private readonly ClientReactive<DocumentItem?> _pdfActiveDocument = new(null);
    private readonly ClientReactive<bool> _demoToastOpen = new(false);

    private static readonly Dictionary<string, List<DocumentItem>> _caseDocuments = new()
    {
        ["APP-2026-001"] = new()
        {
            new("Bank_Information.pdf", "Financial", "2.4 MB", "2026-03-20", "Verified", "file-check-2", "/Bank_Transaction.pdf",
                new() { ["Account Holder"] = "Matti Meikäläinen", ["IBAN"] = "FI21 1234 5600 0007 85", ["Balance"] = "€9,699.00", ["Statement Period"] = "01.01.2026 - 31.03.2026" }),
        },
        ["APP-2026-002"] = new()
        {
            new("Passport_Elena_Sokolova.pdf", "Identity", "3.1 MB", "2026-03-24", "Verified", "file-check-2", "",
                new() { ["Passport ID"] = "RU-7284519", ["Full Name"] = "Elena Sokolova", ["Nationality"] = "Russian Federation", ["Expiry"] = "2031-08-14" }),
            new("Finnish_Language_Certificate_YKI.pdf", "Language", "520 KB", "2026-03-24", "Verified", "file-check-2", "",
                new() { ["Certificate ID"] = "YKI-2025-44821", ["Level"] = "B1 (Intermediate)", ["Test Date"] = "2025-11-15", ["Score"] = "4/6" }),
            new("Continuous_Residence_Proof.pdf", "Residence", "1.8 MB", "2026-03-25", "Under Review", "file-text", "",
                new() { ["Municipality"] = "Helsinki", ["Registered Since"] = "2020-06-01", ["Address"] = "Mannerheimintie 12 A 4" }),
            new("Police_Clearance_Certificate.pdf", "Background", "670 KB", "2026-03-24", "Verified", "file-check-2", "",
                new() { ["Issuing Authority"] = "MVD Russia", ["Result"] = "No criminal record", ["Valid Until"] = "2026-09-24" }),
            new("Income_Statements_2024_2025.pdf", "Financial", "1.2 MB", "2026-03-24", "Pending", "file-clock", "",
                new() { ["Employer"] = "Reaktor Oy", ["Annual Income 2025"] = "€42,800", ["Tax Rate"] = "28.5%" })
        },
        ["APP-2026-003"] = new()
        {
            new("Passport_Ahmad_AlFayed.pdf", "Identity", "2.8 MB", "2026-03-26", "Verified", "file-check-2", "",
                new() { ["Passport ID"] = "EG-9103847", ["Full Name"] = "Ahmad Al-Fayed", ["Nationality"] = "Egypt", ["Expiry"] = "2030-02-18" }),
            new("Job_Offer_Letter_TechCorp.pdf", "Employment", "450 KB", "2026-03-26", "Verified", "file-check-2", "",
                new() { ["Employer"] = "TechCorp Finland Oy", ["Position"] = "Senior Software Engineer", ["Salary"] = "€5,200/month", ["Start Date"] = "2026-05-01" }),
            new("Degree_Certificate_Engineering.pdf", "Education", "1.5 MB", "2026-03-26", "Verified", "file-check-2", "",
                new() { ["Institution"] = "Cairo University", ["Degree"] = "B.Sc. Computer Engineering", ["Graduation"] = "2019", ["GPA"] = "3.7/4.0" })
        },
        ["APP-2026-004"] = new()
        {
            new("Passport_Chen_Wei.pdf", "Identity", "2.2 MB", "2026-03-15", "Verified", "file-check-2", "",
                new() { ["Passport ID"] = "CN-E83920174", ["Full Name"] = "Chen Wei", ["Nationality"] = "China", ["Expiry"] = "2032-07-22" }),
            new("Marriage_Certificate.pdf", "Family", "1.1 MB", "2026-03-15", "Verified", "file-check-2", "",
                new() { ["Spouse"] = "Li Mei (Finnish Resident)", ["Marriage Date"] = "2024-06-15", ["Issuing Authority"] = "Beijing Civil Affairs Bureau", ["Registration No."] = "BJ-2024-08312" }),
            new("Sponsor_Employment_Proof.pdf", "Financial", "560 KB", "2026-03-15", "Verified", "file-check-2", "",
                new() { ["Sponsor"] = "Li Mei", ["Employer"] = "Nokia Oyj", ["Annual Income"] = "€56,400", ["Employment Since"] = "2021-03-01" }),
            new("Health_Insurance_Policy.pdf", "Insurance", "920 KB", "2026-03-16", "Verified", "file-check-2", "",
                new() { ["Provider"] = "IF Insurance", ["Policy No."] = "HI-2026-88412", ["Coverage"] = "€120,000", ["Valid Until"] = "2028-08-31" }),
            new("Housing_Proof_Helsinki.pdf", "Residence", "340 KB", "2026-03-15", "Verified", "file-check-2", "",
                new() { ["Address"] = "Aleksanterinkatu 28 B 12, Helsinki", ["Type"] = "Rental Apartment", ["Size"] = "62 m²", ["Lease Until"] = "2028-12-31" })
        }
    };

    private static readonly Dictionary<string, List<HistoryEvent>> _caseHistory = new()
    {
        ["APP-2026-001"] = new()
        {
            new("2026-03-22", "11:30", "Document Review Started", "Officer Korhonen", "Bank statement queued for manual review. Verifying account holder details and available balance.", "search", "text-brand-600 dark:text-brand-400 bg-brand-50 dark:bg-brand-900/40"),
            new("2026-03-20", "16:45", "Financial Statement Verified", "System (Automated)", "Bank statement cross-referenced with financial records. Account holder confirmed as Matti Meikäläinen. Balance of €9,699.00 verified.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-20", "15:20", "Identity Verification Passed", "System (Automated)", "Passport biometric check completed. Identity confirmed via national registry.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-20", "10:00", "Application Submitted", "Matti Meikäläinen", "Student residence permit application submitted with 1 supporting document.", "inbox", "text-muted-foreground bg-secondary/60")
        },
        ["APP-2026-002"] = new()
        {
            new("2026-03-26", "14:32", "Security Check Cleared", "System (Automated)", "Biometric and passport verification completed successfully. No alerts flagged.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-25", "11:15", "Document Received", "Elena Sokolova", "Residence proof document uploaded and queued for review.", "file-plus", "text-brand-600 dark:text-brand-400 bg-brand-50 dark:bg-brand-900/40"),
            new("2026-03-24", "09:48", "Additional Info Requested", "Officer Virtanen", "Requested proof of continuous residence in Finland for the past 5 years.", "message-square", "text-warning-solid bg-warning-primary/50"),
            new("2026-03-24", "16:05", "Language Certificate Verified", "System (Automated)", "YKI Finnish language certificate validated. Level: intermediate (3).", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-24", "12:30", "Police Clearance Verified", "System (Automated)", "No criminal record found. Clearance certificate authenticated.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-24", "10:00", "Application Submitted", "Elena Sokolova", "Work residence permit application submitted with 5 supporting documents.", "inbox", "text-muted-foreground bg-secondary/60")
        },
        ["APP-2026-003"] = new()
        {
            new("2026-03-28", "09:15", "Application Approved", "Officer Korhonen", "All documents verified. Work residence permit approved for employment at TechCorp Finland.", "check-circle", "text-success-solid bg-success-primary/50"),
            new("2026-03-27", "16:40", "Final Review Completed", "Officer Korhonen", "All three submitted documents pass verification. Case ready for approval.", "clipboard-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-27", "14:00", "Degree Certificate Verified", "System (Automated)", "Engineering degree authenticated with issuing university. Credentials confirmed.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-27", "11:20", "Employment Offer Verified", "System (Automated)", "Job offer letter validated with TechCorp Finland HR department. Position and salary confirmed.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-26", "17:30", "Identity Verification Passed", "System (Automated)", "Passport biometric check completed. Identity confirmed via international registry.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-26", "15:02", "Identity Verification Initiated", "System (Automated)", "Passport scan submitted for automated identity verification.", "scan-face", "text-brand-600 dark:text-brand-400 bg-brand-50 dark:bg-brand-900/40"),
            new("2026-03-26", "15:00", "Application Submitted", "Ahmad Al-Fayed", "Work residence permit application submitted with 3 documents.", "inbox", "text-muted-foreground bg-secondary/60")
        },
        ["APP-2026-004"] = new()
        {
            new("2026-03-18", "09:00", "Application Approved", "Officer Laine", "All documents verified. Family member residence permit approved for Chen Wei to join spouse Li Mei in Helsinki.", "check-circle", "text-success-solid bg-success-primary/50"),
            new("2026-03-17", "14:20", "Final Review Completed", "Officer Laine", "All five submitted documents pass verification. Sponsor income and housing meet requirements. Case ready for approval.", "clipboard-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-16", "11:45", "Health Insurance Verified", "System (Automated)", "IF Insurance policy HI-2026-88412 confirmed active. Coverage of €120,000 meets minimum requirements.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-16", "10:10", "Document Received", "Chen Wei", "Health insurance policy uploaded.", "file-plus", "text-brand-600 dark:text-brand-400 bg-brand-50 dark:bg-brand-900/40"),
            new("2026-03-15", "16:30", "Sponsor Income Verified", "System (Automated)", "Sponsor Li Mei's employment at Nokia Oyj confirmed. Annual income of €56,400 meets family reunification threshold.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-15", "14:00", "Marriage Certificate Verified", "System (Automated)", "Marriage certificate BJ-2024-08312 cross-referenced with Beijing Civil Affairs Bureau registry. Spousal relationship confirmed.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-15", "12:15", "Identity Verification Passed", "System (Automated)", "Passport CN-E83920174 biometric scan completed successfully.", "shield-check", "text-success-solid bg-success-primary/50"),
            new("2026-03-15", "10:00", "Application Submitted", "Chen Wei", "Family member residence permit application submitted with 5 supporting documents for spousal reunification.", "inbox", "text-muted-foreground bg-secondary/60")
        }
    };

    private static readonly byte[] MigriLogoSvg = System.Text.Encoding.UTF8.GetBytes(
        @"<svg viewBox=""0 0 100 100"" xmlns=""http://www.w3.org/2000/svg"">
            <polygon points=""55,5 100,18 35,35"" fill=""#7aa9e6""/>
            <polygon points=""0,45 55,5 20,100"" fill=""#27348b""/>
          </svg>"
    );

    public async Task Main()
    {
        app.ClientJoinedAsync += async args =>
        {
            if (!string.IsNullOrEmpty(args.ClientContext.Theme))
            {
                _currentTheme.Value = args.ClientContext.Theme == Constants.DarkTheme ? Constants.DarkTheme : Constants.LightTheme;
            }
            _currentPath.Value = args.ClientContext.InitialPath ?? "";
        };

        app.Navigation.PathChangedAsync += async args =>
        {
            _currentPath.Value = args.Path;
        };

        UI.Root([Page.Plain], content: view =>
        {
            if (_currentPath.Value.StartsWith("/pdf"))
            {
                RenderPdfPage(view);
                return;
            }

            view.Column(["h-screen w-full bg-background text-foreground flex flex-col font-sans overflow-hidden"], content: view =>
            {
                // Top Header - Authentic Migri Finland styling (White background with blue accents)
                view.Row(["w-full h-[72px] bg-background text-foreground px-4 lg:px-6 items-center justify-between border-b border-secondary/50 shadow-sm z-20 shrink-0 relative"], content: view =>
                {
                    // Subtle top border - Migri Blue
                    view.Box(["absolute top-0 left-0 w-full h-[4px] bg-brand-800"]);

                    view.Row(["items-center gap-4 cursor-pointer group motion-[0:opacity-0_translate-x-[-10px],100:opacity-100_translate-x-0] motion-duration-500ms motion-ease-out"], content: view =>
                    {
                        // Authentic SVG logo rendering
                        view.Image(["w-10 h-10 object-contain group-hover:opacity-90 transition-opacity"], data: MigriLogoSvg, mimeType: "image/svg+xml", alt: "Migri Logo");
                        
                        view.Column(["gap-0 mt-0.5"], content: logoText => 
                        {
                            // Migri official typography hierarchy
                            logoText.Text(["text-[1.1rem] md:text-[1.2rem] font-bold tracking-tight text-brand-800 dark:text-brand-300 leading-none"], "Maahanmuuttovirasto");
                            logoText.Text(["text-[0.62rem] md:text-[0.65rem] font-semibold text-brand-800/80 dark:text-brand-400/80 tracking-widest uppercase leading-tight mt-0.5 whitespace-nowrap hidden sm:block"], "Migrationsverket \u2022 Finnish Immigration Service");
                        });
                    });

                    view.Row([Layout.Row.Md, "motion-[0:opacity-0_translate-x-[10px],100:opacity-100_translate-x-0] motion-duration-500ms motion-ease-out"], content: view =>
                    {
                        view.Row(["hidden sm:flex items-center gap-2 px-3 py-1.5 rounded-md border border-secondary/40 bg-secondary/20 mr-1"], content: badge => {
                            badge.Box(["w-2 h-2 rounded-full bg-success-solid"]);
                            badge.Text(["text-xs font-semibold text-foreground/80 tracking-wide uppercase"], "Officer AMS");
                        });

                        view.Button([Button.GhostMd, Button.Size.Icon, "text-foreground hover:bg-secondary transition-colors rounded-full"],
                            onClick: async () => await ToggleThemeAsync(),
                            content: v => v.Icon(["w-5 h-5 text-brand-800 dark:text-brand-400 hover:text-brand-900 dark:hover:text-brand-300"], name: _currentTheme.Value == Constants.DarkTheme ? "sun" : "moon"));
                    });
                });

                // Main Workspace
                view.Row(["flex-1 overflow-hidden w-full max-w-[1800px] mx-auto flex flex-col md:flex-row relative"], content: view =>
                {
                    var selected = _selectedApplication.Value;

                    // Sidebar
                    // On Mobile: Hide if a case is selected.
                    // On Desktop: Always show.
                    var sidebarDisplayClass = selected == null ? "flex" : "hidden md:flex";
                    
                    view.Column([$"w-full md:w-[360px] lg:w-[400px] bg-secondary/30 dark:bg-card border-r border-secondary/50 h-full flex-col {sidebarDisplayClass} shrink-0 relative"], content: view =>
                    {
                        var openCases = _applications.Value.Where(a => a.Status != "Approved" && a.Status != "Rejected").ToList();
                        var closedCases = _applications.Value.Where(a => a.Status == "Approved" || a.Status == "Rejected").ToList();

                        // Scrollable area for both sections
                        view.ScrollArea(rootStyle: ["flex-1"], content: view =>
                        {
                            // ── Open Cases Section ──
                            view.Column(["p-5 pb-3 border-b border-secondary/50 sticky top-0 bg-background/90 backdrop-blur-md z-10"], content: view =>
                            {
                                view.Text([Text.H2, "text-foreground font-semibold tracking-tight"], "Open Cases");
                                view.Row(["items-center gap-2 mt-1.5"], content: row => 
                                {
                                    row.Box(["w-2 h-2 rounded-full bg-brand-500 shadow-[0_0_8px_rgba(39,52,139,0.8)] motion-[0:opacity-50_scale-90,50:opacity-100_scale-110,100:opacity-50_scale-90] motion-duration-2000ms motion-loop motion-ease-ease-in-out"]);
                                    row.Text([Text.Muted, "text-sm"], $"{openCases.Count} cases require attention");
                                });
                            });

                            view.Column(["p-3 gap-3"], content: view =>
                            {
                                if (openCases.Count == 0)
                                {
                                    view.Column([Layout.Center, "py-8"], content: c =>
                                    {
                                        c.Icon(["w-8 h-8 text-muted-foreground/40 mb-2"], name: "check-circle");
                                        c.Text([Text.Small, "text-muted-foreground"], "No open cases");
                                    });
                                }
                                else
                                {
                                    foreach (var appItem in openCases)
                                    {
                                        CaseCard(view, appItem, selected);
                                    }
                                }
                            });

                            // ── Closed Cases Section ──
                            if (closedCases.Count > 0)
                            {
                                view.Column(["px-5 pt-4 pb-3 border-t border-secondary/50"], content: view =>
                                {
                                    view.Text([Text.H2, "text-foreground font-semibold tracking-tight"], "Closed Cases");
                                });

                                view.Column(["p-3 gap-3"], content: view =>
                                {
                                    foreach (var appItem in closedCases)
                                    {
                                        CaseCard(view, appItem, selected);
                                    }
                                });
                            }
                        });
                    });

                    // Detail View Area
                    // On Mobile: Hide if case is NOT selected.
                    // On Desktop: Always show.
                    var detailDisplayClass = selected != null ? "flex" : "hidden md:flex";

                    view.Column([$"flex-1 bg-background h-full overflow-y-auto relative flex-col {detailDisplayClass}"], content: view =>
                    {
                        if (selected == null)
                        {
                            view.Column([Layout.Center, "h-full w-full motion-[0:opacity-0_scale-[0.98],100:opacity-100_scale-100] motion-duration-400ms motion-ease-out relative"], content: view =>
                            {
                                // Decorative background shapes
                                view.Box(["absolute inset-0 overflow-hidden pointer-events-none opacity-[0.03] dark:opacity-[0.02] bg-[radial-gradient(ellipse_at_center,var(--brand-500)_0%,transparent_50%)] w-full h-full"]);

                                view.Column(["w-24 h-24 rounded-full bg-secondary/40 items-center justify-center mb-6 border border-secondary shadow-inner relative z-10 motion-[0:translate-y-[10px],100:translate-y-0] motion-duration-500ms motion-ease-out"], content: c => {
                                    c.Icon(["w-10 h-10 text-muted-foreground opacity-60"], name: "inbox-stroke");
                                });
                                view.Text([Text.H2, "text-foreground font-medium tracking-tight mb-3 z-10"], "No Case Selected");
                                view.Text([Text.Body, "text-muted-foreground max-w-[320px] text-center leading-relaxed z-10"], "Select an application from the queue to review documents, view history, and process the case.");
                            });
                        }
                        else
                        {
                            view.Column(["w-full motion-[0:opacity-0_translate-y-[15px],100:opacity-100_translate-y-0] motion-duration-300ms motion-ease-[cubic-bezier(0.25,1,0.35,1)] motion-fill-both"], content: mainScroll => 
                            {
                                // Back Button (Mobile Only)
                                mainScroll.Row(["md:hidden w-full p-4 border-b border-secondary items-center sticky top-0 bg-background/90 backdrop-blur z-20 shadow-sm"], content: view => 
                                {
                                    view.Button([Button.GhostSm, "text-brand-700 dark:text-brand-300 font-medium -ml-2 px-2"], onClick: async () => { _selectedApplication.Value = null; }, content: v => {
                                        v.Icon(["w-4 h-4 mr-1.5"], name: "arrow-left");
                                        v.Text(text: "Back to Cases");
                                    });
                                });

                                mainScroll.Column(["p-5 md:p-8 lg:p-12 gap-8 max-w-5xl mx-auto w-full"], content: view =>
                                {
                                    // Detail Header
                                    view.Column(["pb-6 border-b border-secondary/60 gap-5"], content: view =>
                                    {
                                        view.Row([Layout.Row.SpaceBetween, "items-start"], content: view =>
                                        {
                                            view.Column([Layout.Column.Xs], content: view =>
                                            {
                                                view.Text([Text.H1, "text-foreground tracking-tight text-3xl font-heading"], selected.ApplicantName);
                                                view.Row(["items-center gap-4 mt-3 flex-wrap"], content: view =>
                                                {
                                                    view.Row(["items-center gap-1.5 text-muted-foreground px-2 py-0.5 bg-secondary/50 rounded-md border border-secondary"], content: view => {
                                                        view.Icon(["w-3.5 h-3.5"], name: "fingerprint");
                                                        view.Text(["font-mono text-sm font-medium tracking-wide"], selected.Id);
                                                    });
                                                    view.Row(["items-center gap-1.5 text-muted-foreground"], content: view => {
                                                        view.Icon(["w-4 h-4"], name: "calendar-clock");
                                                        view.Text(["text-sm font-medium"], $"Submitted: {selected.SubmissionDate}");
                                                    });
                                                });
                                            });
                                            view.Box([$"px-4 py-1.5 rounded-full border shadow-sm {GetStatusPillColor(selected.Status)}"], content: view =>
                                            {
                                                view.Text([Text.Small, "font-bold tracking-wider uppercase"], selected.Status);
                                            });
                                        });
                                    });

                                    // Metric Info Cards
                                    view.Row(["grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5"], content: view =>
                                    {
                                        InfoCard(view, "Application Type", selected.ApplicationType, "briefcase", "border-l-brand-600 bg-gradient-to-br from-card to-card hover:to-brand-50/30 dark:hover:to-brand-900/10");
                                        InfoCard(view, "Nationality", selected.Nationality, "globe-2", "border-l-brand-400 bg-gradient-to-br from-card to-card hover:to-brand-50/20 dark:hover:to-brand-900/10");
                                        InfoCard(view, "Assigned Agent", "You (Officer)", "user-circle", "border-l-secondary bg-gradient-to-br from-card to-secondary/10 hover:to-secondary/30");
                                    });

                                    // Content Panel
                                    view.Column([Card.Elevated, "mt-2 overflow-hidden shadow-lg border-secondary/70 rounded-2xl bg-card transition-shadow hover:shadow-xl duration-300"], content: view =>
                                    {
                                        // Tabs
                                        var activeTab = _activeTab.Value;
                                        view.Row(["border-b border-secondary/60 bg-secondary/20 p-2 flex gap-1.5 overflow-x-auto hide-scrollbar"], content: view =>
                                        {
                                            var docCount = _caseDocuments.TryGetValue(selected.Id, out var docs) ? docs.Count : 0;
                                            TabButton(view, "overview", "Overview", activeTab);
                                            TabButton(view, "documents", $"Documents ({docCount})", activeTab);
                                            TabButton(view, "history", "Processing History", activeTab);
                                        });

                                        // Tab Content
                                        if (activeTab == "overview")
                                        {
                                            RenderOverviewTab(view, selected);
                                        }
                                        else if (activeTab == "documents")
                                        {
                                            RenderDocumentsTab(view, selected);
                                        }
                                        else if (activeTab == "history")
                                        {
                                            RenderHistoryTab(view, selected);
                                        }
                                    });
                                });
                            });
                        }
                    });
                });
            });

            // PDF Viewer Modal
            view.Dialog(
                open: _pdfDialogOpen.Value,
                onOpenChange: async o => _pdfDialogOpen.Value = o ?? false,
                overlayStyle: [Dialog.Overlay, "bg-black/70 backdrop-blur-sm"],
                contentStyle: ["fixed top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] w-[75vw] h-[75vh] bg-background rounded-2xl shadow-2xl border border-secondary/50 flex flex-col overflow-hidden p-0 max-w-none"],
                content: view =>
                {
                    // Dialog Header
                    view.Row(["h-14 px-5 items-center justify-between border-b border-secondary/50 shrink-0 bg-background/95 backdrop-blur-md"], content: header =>
                    {
                        header.Row(["items-center gap-2.5"], content: r =>
                        {
                            r.Icon(["w-5 h-5 text-foreground"], name: "file-text");
                            r.Text(["font-semibold text-sm text-foreground tracking-tight"], "Proof Point");
                        });
                        header.Button([Button.GhostMd, "w-10 h-10 p-0 flex items-center justify-center text-muted-foreground hover:text-foreground rounded-lg transition-colors"],
                            onClick: async () => _pdfDialogOpen.Value = false,
                            content: v => v.Icon(["w-7 h-7"], name: "x"));
                    });

                    // ProofPoint PDF Renderer & Metadata Sidebar
                    if (!string.IsNullOrEmpty(_pdfDialogUrl.Value))
                    {
                        var activeDoc = _pdfActiveDocument.Value;
                        if (activeDoc != null && activeDoc.CheckedValues is { Count: > 0 })
                        {
                            view.Row(["flex-1 min-h-0 bg-background overflow-hidden"], content: r =>
                            {
                                // PDF Viewer (left)
                                r.ProofPoint(
                                    pdfUrl: _pdfDialogUrl.Value,
                                    searchText: _pdfSearchText.Value,
                                    style: ["flex-1 min-w-0 border-r border-secondary/50"]
                                );

                                // Key-Values Side Panel (right)
                                r.Column(["w-[320px] shrink-0 bg-secondary/10 flex flex-col items-stretch max-h-full"], content: side => 
                                {
                                    side.Column(["p-5 border-b border-secondary/50 shrink-0 gap-2"], content: b => {
                                        b.Text([Text.H4, "font-semibold tracking-tight text-foreground"], "Document Metadata");
                                        b.Text([Text.Caption, "text-muted-foreground break-words leading-snug"], activeDoc.Name);
                                        b.Row([$"inline-flex min-w-0 items-center justify-self-start self-start gap-1.5 px-2.5 py-1 rounded-full border text-xs font-semibold mt-1", 
                                            activeDoc.Status == "Verified" ? "text-success-solid bg-success-primary/50 border-success-secondary/50" : 
                                            activeDoc.Status == "Under Review" ? "text-brand-700 dark:text-brand-300 bg-brand-50 dark:bg-brand-900/40 border-brand-200 dark:border-brand-700/60" : 
                                            "text-warning-solid bg-warning-primary/50 border-warning-secondary/50"], content: badge => {
                                            badge.Icon(["w-3 h-3"], name: activeDoc.Status == "Verified" ? "check-circle" : activeDoc.Status == "Under Review" ? "search" : "clock");
                                            badge.Text(text: activeDoc.Status);
                                        });
                                    });
                                    
                                    side.ScrollArea(rootStyle: ["flex-1"], content: scroll => {
                                        scroll.Column(["gap-5 p-5"], content: list => {
                                            foreach (var kv in activeDoc.CheckedValues)
                                            {
                                                list.Button(["flex flex-col text-left gap-1.5 bg-transparent border-none p-0 cursor-pointer group w-full"],
                                                    onClick: async () => { _pdfSearchText.Value = kv.Value.Trim().Replace("€", "").Replace("$", "").Replace("£", "").Trim(); },
                                                    content: item => {
                                                        item.Text([Text.Caption, "text-muted-foreground font-semibold uppercase tracking-wider text-[10px] group-hover:text-brand-600 dark:group-hover:text-brand-400 transition-colors"], kv.Key);
                                                        item.Text([Text.Body, "text-sm text-foreground font-medium bg-card p-3 rounded-lg border border-secondary/40 shadow-sm group-hover:border-brand-400/50 group-hover:shadow-md transition-all whitespace-pre-wrap w-full"], kv.Value);
                                                    });
                                            }
                                        });
                                    });
                                });
                            });
                        }
                        else
                        {
                            view.ProofPoint(
                                pdfUrl: _pdfDialogUrl.Value,
                                searchText: _pdfSearchText.Value,
                                style: ["flex-1"]
                            );
                        }
                    }
                }
            );

            // Demo toast notification
            view.Toast(open: _demoToastOpen.Value, onOpenChange: async o => _demoToastOpen.Value = o ?? false,
                viewportStyle: [Toast.ViewportBottomCenter, "w-auto max-w-[500px]"],
                toastStyle: [Toast.Base, "[grid-template-columns:1fr] min-w-[420px] p-5 border-brand-200 dark:border-brand-700/60 bg-card shadow-xl rounded-xl"],
                title: "Action Disabled", titleStyle: [Toast.Title, "text-base font-bold text-foreground tracking-tight"],
                description: "Actions in this solution are disabled to preserve its state for the demonstration.",
                descriptionStyle: [Toast.Description, "text-sm text-muted-foreground leading-relaxed mt-1"],
                durationMs: 4000, showClose: true, closeStyle: [Toast.Close]);
        });
    }

    private void RenderPdfPage(UIView view)
    {
        view.Column(["h-screen w-screen bg-background flex flex-col overflow-hidden font-sans"], content: view =>
        {
            // Header
            view.Row(["h-[72px] bg-background border-b border-secondary items-center px-6 justify-between shrink-0"], content: view =>
            {
                view.Button(["flex flex-row items-center gap-4 cursor-pointer bg-transparent border-none hover:bg-secondary/20 p-2 rounded-md transition-colors"], 
                    onClick: async () => await app.Navigation.SetPathAsync("/"),
                    content: view =>
                {
                    view.Icon(["w-5 h-5"], name: "arrow-left");
                    view.Text(["text-lg font-bold text-brand-800 dark:text-brand-300"], "Document Verification - Migri ProofPoint");
                });

                view.Button([Button.GhostMd], label: "Close Viewer", onClick: async () => await app.Navigation.SetPathAsync("/"));
            });

            // ProofPoint Component
            view.ProofPoint(
                pdfUrl: "https://raw.githubusercontent.com/mozilla/pdf.js/ba2edeae/web/compressed.tracemonkey-pldi-09.pdf",
                style: ["flex-1"]
            );
        });
    }

    private void CaseCard(UIView view, Application appItem, Application? selected)
    {
        var isSelected = selected?.Id == appItem.Id;
        var bgClass = isSelected 
            ? "bg-brand-50/80 border-brand-500 shadow-md ring-1 ring-brand-500/30 dark:bg-brand-900/40 dark:border-brand-500/60" 
            : "bg-card border-secondary/60 hover:border-brand-400/60 hover:shadow-md hover:-translate-y-[2px] dark:hover:bg-secondary/40 transition-all duration-200 ease-out";
        
        view.Button([$"w-full text-left flex flex-col p-4 rounded-xl border {bgClass} group"], onClick: async () => { _selectedApplication.Value = appItem; _activeTab.Value = "overview"; }, content: view =>
        {
            view.Row([Layout.Row.SpaceBetween, "w-full mb-2 items-start"], content: view =>
            {
                view.Column([Layout.Column.Xs], content: view => 
                {
                    view.Text([$"font-semibold text-sm transition-colors {(isSelected ? "text-brand-800 dark:text-brand-200" : "text-foreground group-hover:text-brand-600 dark:group-hover:text-brand-300")} "], appItem.ApplicantName);
                    view.Box(["mt-1"], content: bgBox => {
                        bgBox.Text([Text.Caption, "text-muted-foreground font-mono bg-secondary/50 px-2 py-0.5 rounded-md w-fit"], appItem.Id);
                    });
                });
                
                var iconName = appItem.Status == "Approved" ? "check-circle" : (appItem.Status == "In Progress" ? "clock" : "alert-circle");
                view.Icon([$"w-4 h-4 {GetStatusColor(appItem.Status)} flex-shrink-0 mt-0.5"], name: iconName);
            });
            
            view.Row([Layout.Row.SpaceBetween, "w-full items-center mt-2 pt-2 border-t border-secondary/30"], content: view =>
            {
                view.Text([Text.Small, "text-muted-foreground truncate max-w-[55%] flex items-center"], appItem.ApplicationType);
                view.Text([Text.Small, "font-medium text-right", GetStatusColor(appItem.Status)], appItem.Status);
            });
        });
    }

    private void TabButton(UIView view, string tabId, string label, string activeTab)
    {
        var isActive = activeTab == tabId;
        if (isActive)
        {
            view.Button([Button.GhostMd, "bg-background shadow-sm text-brand-800 dark:text-brand-300 font-semibold px-5 rounded-lg border border-secondary/40 relative h-10"],
                onClick: async () => { _activeTab.Value = tabId; },
                content: btn =>
                {
                    btn.Text(text: label);
                    btn.Box(["absolute bottom-0 left-0 w-full h-[2px] bg-brand-500 rounded-t-sm"]);
                });
        }
        else
        {
            view.Button([Button.GhostMd, "text-muted-foreground hover:text-foreground hover:bg-secondary/50 px-5 rounded-lg whitespace-nowrap h-10 transition-colors font-medium"],
                label: label,
                onClick: async () => { _activeTab.Value = tabId; });
        }
    }

    private void RenderOverviewTab(UIView view, Application selected)
    {
        view.Column(["p-6 sm:p-8 lg:p-10 gap-8 motion-[0:opacity-0_translate-y-[8px],100:opacity-100_translate-y-0] motion-duration-300ms motion-ease-out"], content: view =>
        {
            view.Column([Layout.Column.Md], content: view =>
            {
                view.Row(["items-center gap-2 mb-1"], content: row => {
                    row.Icon(["w-5 h-5 text-brand-500"], name: "info");
                    row.Text([Text.H3, "text-foreground font-semibold tracking-tight"], "Application Summary");
                });
                var summaryText = selected.Status switch
                {
                    "Approved" => "This application has been approved. All required documents were verified and background checks have been completed successfully. The residence permit has been granted.",
                    "Rejected" => "This application has been rejected. The submitted documentation did not meet the required criteria after thorough review. The applicant has been notified of the decision and may appeal within 30 days.",
                    "Pending Additional Info" => "This application is pending additional information from the applicant. Core documents have been reviewed, but further evidence is required before a decision can be made.",
                    _ => "This application is currently under review. The applicant has submitted all required primary documents. Background checks and residential verifications are being processed by the relevant authorities."
                };
                view.Text([Text.Body, "text-muted-foreground text-base leading-relaxed max-w-[800px]"], summaryText);

                // Alert banner
                view.Row(["mt-5 p-4 rounded-xl bg-blue-50 dark:bg-brand-900/20 border border-brand-200 dark:border-brand-700/50 flex gap-3.5 items-start"], content: banner => {
                    banner.Icon(["w-6 h-6 text-brand-600 dark:text-brand-400 shrink-0 mt-0.5"], name: "shield-check");
                    banner.Column(["gap-1.5"], content: c => {
                        c.Text(["font-semibold text-brand-900 dark:text-brand-100 text-sm tracking-tight"], "Identity & Security Verification Passed");
                        c.Text(["text-sm text-brand-800/80 dark:text-brand-300/80 leading-snug"], $"Automated initial passport and biometric checks were fully cleared on {selected.SubmissionDate}.");
                    });
                });
            });

            // Requirements Checklist — only for non-approved cases
            if (selected.Status != "Approved")
            {
                view.Separator([Separator.Horizontal, "bg-secondary/60"]);

                view.Column([Layout.Column.Md], content: view =>
                {
                    view.Row(["items-center gap-2 mb-3"], content: row => {
                        row.Icon(["w-5 h-5 text-brand-500"], name: "clipboard-list");
                        row.Text([Text.H3, "text-foreground font-semibold tracking-tight"], "Requirements Checklist");
                    });
                    view.Text([Text.Small, "text-muted-foreground mb-4"], $"Migri Finland requirements for: {selected.ApplicationType}");

                    var checklist = GetRequirementsChecklist(selected);

                    view.Column(["gap-2.5"], content: list =>
                    {
                        foreach (var item in checklist)
                        {
                            var (iconName, iconColor, bgColor, textColor) = item.Status switch
                            {
                                "fulfilled" => ("check", "text-[#27348B]", "bg-[#7AA9E6]/20 border-transparent", "text-foreground"),
                                "pending" => ("clock", "text-warning-solid", "bg-warning-primary/30 border-warning-secondary/40", "text-foreground"),
                                "under-review" => ("search", "text-brand-600 dark:text-brand-400", "bg-brand-50 dark:bg-brand-900/30 border-brand-200 dark:border-brand-700/50", "text-foreground"),
                                _ => ("x-circle", "text-error-solid", "bg-error-secondary/30 border-error-secondary/40", "text-muted-foreground")
                            };

                            list.Button([$"w-full text-left items-center gap-3 p-3 rounded-lg border {bgColor} hover:brightness-95 dark:hover:brightness-110 transition-all flex cursor-pointer group"], 
                                onClick: async () => 
                                {
                                    if (item.MatchedDocument != null && !string.IsNullOrEmpty(item.MatchedDocument.Url))
                                    {
                                        _pdfActiveDocument.Value = item.MatchedDocument;
                                        _pdfDialogUrl.Value = item.MatchedDocument.Url;
                                        _pdfSearchText.Value = "";
                                        _pdfDialogOpen.Value = true;
                                    }
                                    else
                                    {
                                        _activeTab.Value = "documents";
                                    }
                                },
                                content: row =>
                            {
                                row.Icon([$"w-5 h-5 shrink-0 {iconColor}"], name: iconName);
                                row.Text([$"flex-1 text-sm font-medium {textColor} group-hover:text-brand-700 dark:group-hover:text-brand-300 transition-colors"], item.Requirement);
                                row.Icon([$"w-4 h-4 text-muted-foreground/50 shrink-0 opacity-0 group-hover:opacity-100 transition-opacity"], name: "chevron-right");
                            });
                        }
                    });

                    // Legend
                    view.Row(["mt-4 gap-5 flex-wrap"], content: legend =>
                    {
                        legend.Row(["items-center gap-1.5"], content: r => {
                            r.Icon(["w-3.5 h-3.5 text-[#27348B]"], name: "check");
                            r.Text([Text.Caption, "text-muted-foreground"], "Fulfilled");
                        });
                        legend.Row(["items-center gap-1.5"], content: r => {
                            r.Icon(["w-3.5 h-3.5 text-warning-solid"], name: "clock");
                            r.Text([Text.Caption, "text-muted-foreground"], "Pending");
                        });
                        legend.Row(["items-center gap-1.5"], content: r => {
                            r.Icon(["w-3.5 h-3.5 text-brand-600 dark:text-brand-400"], name: "search");
                            r.Text([Text.Caption, "text-muted-foreground"], "Under Review");
                        });
                        legend.Row(["items-center gap-1.5"], content: r => {
                            r.Icon(["w-3.5 h-3.5 text-error-solid"], name: "x-circle");
                            r.Text([Text.Caption, "text-muted-foreground"], "Missing");
                        });
                    });
                });
            }

            view.Separator([Separator.Horizontal, "bg-secondary/60"]);

            if (selected.Status != "Approved" && selected.Status != "Rejected")
            {
                view.Column([Layout.Column.Md], content: view =>
                {
                    view.Text([Text.Caption, "text-foreground font-semibold tracking-wider uppercase text-muted-foreground mb-1"], "Required Actions");
                    view.Row(["flex flex-wrap gap-4 focus-visible:outline-none"], content: view =>
                    {
                    if (selected.Status != "Pending Additional Info")
                    {
                        view.Button([Button.PrimaryLg, "bg-gradient-to-r from-brand-700 to-brand-600 hover:from-brand-600 hover:to-brand-500 text-white min-w-[150px] shadow-md hover:shadow-lg transition-all rounded-xl hover:-translate-y-0.5 h-12"],
                            onClick: async () => { _demoToastOpen.Value = false; _demoToastOpen.Value = true; },
                            content: btn => {
                            btn.Icon(["w-4 h-4 mr-2"], name: "check-circle-2");
                            btn.Text(text: "Approve Case");
                        });
                    }
                        view.Button([Button.GhostLg, "text-danger hover:bg-error-secondary/20 hover:text-error-solid rounded-xl transition-all h-12 px-6"],
                            onClick: async () => { _demoToastOpen.Value = false; _demoToastOpen.Value = true; },
                            label: "Reject");
                    });
                });
            }
        });
    }

    private void RenderDocumentsTab(UIView view, Application selected)
    {
        var documents = _caseDocuments.TryGetValue(selected.Id, out var docs) ? docs : new List<DocumentItem>();

        view.Column(["p-6 sm:p-8 lg:p-10 gap-6 motion-[0:opacity-0_translate-y-[8px],100:opacity-100_translate-y-0] motion-duration-300ms motion-ease-out"], content: view =>
        {
            // Header row
            view.Row([Layout.Row.SpaceBetween, "items-center mb-2"], content: view =>
            {
                view.Column(["gap-1"], content: c =>
                {
                    c.Row(["items-center gap-2"], content: r =>
                    {
                        r.Icon(["w-5 h-5 text-brand-500"], name: "folder-open");
                        r.Text([Text.H3, "text-foreground font-semibold tracking-tight"], "Submitted Documents");
                    });
                    c.Text([Text.Small, "text-muted-foreground"], $"{documents.Count} documents attached to this application");
                });
            });

            // Document list
            view.Column(["gap-3"], content: view =>
            {
                foreach (var doc in documents)
                {
                    var statusColor = doc.Status switch
                    {
                        "Verified" => "text-success-solid bg-success-primary/50 border-success-secondary/50",
                        "Under Review" => "text-brand-700 dark:text-brand-300 bg-brand-50 dark:bg-brand-900/40 border-brand-200 dark:border-brand-700/60",
                        _ => "text-warning-solid bg-warning-primary/50 border-warning-secondary/50"
                    };

                    var statusIcon = doc.Status switch
                    {
                        "Verified" => "check-circle",
                        "Under Review" => "search",
                        _ => "clock"
                    };

                    var hasUrl = !string.IsNullOrEmpty(doc.Url);
                    var cardUrl = doc.Url;

                    view.Row([$"p-4 rounded-xl border border-secondary/60 bg-card hover:border-brand-400/50 hover:shadow-md transition-all duration-200 items-center gap-4 group {(hasUrl ? "cursor-pointer" : "")}"], content: view =>
                    {
                        // File icon — clickable if doc has URL
                        if (hasUrl)
                        {
                            view.Button(["w-12 h-12 rounded-xl bg-brand-50 dark:bg-brand-900/30 border border-brand-200/50 dark:border-brand-700/30 items-center justify-center shrink-0 p-0 cursor-pointer"],
                                onClick: async () => { _pdfActiveDocument.Value = doc; _pdfDialogUrl.Value = cardUrl; _pdfSearchText.Value = ""; _pdfDialogOpen.Value = true; },
                                content: c => c.Icon(["w-5 h-5 text-brand-600 dark:text-brand-400"], name: doc.IconName));
                        }
                        else
                        {
                            view.Column(["w-12 h-12 rounded-xl bg-brand-50 dark:bg-brand-900/30 border border-brand-200/50 dark:border-brand-700/30 items-center justify-center shrink-0"], content: c =>
                                c.Icon(["w-5 h-5 text-brand-600 dark:text-brand-400"], name: doc.IconName));
                        }

                        // File info
                        view.Column(["flex-1 gap-1 min-w-0"], content: c =>
                        {
                            // Name + metadata — clickable if doc has URL
                            if (hasUrl)
                            {
                                c.Button(["w-full text-left bg-transparent border-none p-0 cursor-pointer flex flex-col gap-1"],
                                    onClick: async () => { _pdfActiveDocument.Value = doc; _pdfDialogUrl.Value = cardUrl; _pdfSearchText.Value = ""; _pdfDialogOpen.Value = true; },
                                    content: nameArea =>
                                {
                                    nameArea.Text(["font-semibold text-sm text-foreground group-hover:text-brand-700 dark:group-hover:text-brand-300 transition-colors truncate"], doc.Name);
                                    nameArea.Row(["items-center gap-3 flex-wrap"], content: r =>
                                    {
                                        r.Text([Text.Caption, "text-muted-foreground font-medium"], doc.Type);
                                        r.Box(["w-1 h-1 rounded-full bg-muted-foreground/40"]);
                                        r.Text([Text.Caption, "text-muted-foreground"], doc.Size);
                                        r.Box(["w-1 h-1 rounded-full bg-muted-foreground/40"]);
                                        r.Text([Text.Caption, "text-muted-foreground"], $"Uploaded {doc.UploadDate}");
                                    });
                                });
                            }
                            else
                            {
                                c.Text(["font-semibold text-sm text-foreground group-hover:text-brand-700 dark:group-hover:text-brand-300 transition-colors truncate"], doc.Name);
                                c.Row(["items-center gap-3 flex-wrap"], content: r =>
                                {
                                    r.Text([Text.Caption, "text-muted-foreground font-medium"], doc.Type);
                                    r.Box(["w-1 h-1 rounded-full bg-muted-foreground/40"]);
                                    r.Text([Text.Caption, "text-muted-foreground"], doc.Size);
                                    r.Box(["w-1 h-1 rounded-full bg-muted-foreground/40"]);
                                    r.Text([Text.Caption, "text-muted-foreground"], $"Uploaded {doc.UploadDate}");
                                });
                            }

                            // Checked values — independent buttons with their own search text
                            if (doc.CheckedValues is { Count: > 0 })
                            {
                                var docUrlForKv = doc.Url;
                                c.Row(["flex-wrap gap-x-4 gap-y-1 mt-1.5 pt-1.5 border-t border-secondary/30"], content: r =>
                                {
                                    foreach (var kv in doc.CheckedValues)
                                    {
                                        var val = kv.Value;
                                        if (!string.IsNullOrEmpty(docUrlForKv))
                                        {
                                            r.Button(["flex items-center gap-1 bg-transparent border-none p-0 cursor-pointer hover:bg-brand-50 dark:hover:bg-brand-900/20 rounded px-1.5 py-0.5 -mx-1 transition-colors group/kv"], 
                                                onClick: async () => { _pdfActiveDocument.Value = doc; _pdfDialogUrl.Value = docUrlForKv; _pdfSearchText.Value = val.Trim().Replace("€", "").Replace("$", "").Replace("£", "").Trim(); _pdfDialogOpen.Value = true; },
                                                content: pair =>
                                            {
                                                pair.Text([Text.Caption, "text-muted-foreground"], $"{kv.Key}:");
                                                pair.Text([Text.Caption, "text-foreground font-medium group-hover/kv:text-brand-600 dark:group-hover/kv:text-brand-400 transition-colors underline decoration-dotted decoration-muted-foreground/40 underline-offset-2"], val);
                                            });
                                        }
                                        else
                                        {
                                            r.Row(["items-center gap-1"], content: pair =>
                                            {
                                                pair.Text([Text.Caption, "text-muted-foreground"], $"{kv.Key}:");
                                                pair.Text([Text.Caption, "text-foreground font-medium"], val);
                                            });
                                        }
                                    }
                                });
                            }
                        });

                        // Status badge
                        view.Row([$"items-center gap-1.5 px-3 py-1 rounded-full border text-xs font-semibold shrink-0 {statusColor}"], content: r =>
                        {
                            r.Icon(["w-3.5 h-3.5"], name: statusIcon);
                            r.Text(text: doc.Status);
                        });

                        // Eye button (only for docs with a URL)
                        if (hasUrl)
                        {
                            view.Button([Button.GhostMd, "w-10 h-10 p-0 flex items-center justify-center text-muted-foreground hover:text-brand-600 dark:hover:text-brand-400 rounded-lg transition-colors shrink-0"],
                                onClick: async () => { _pdfActiveDocument.Value = doc; _pdfDialogUrl.Value = cardUrl; _pdfSearchText.Value = ""; _pdfDialogOpen.Value = true; },
                                content: v => v.Icon(["w-5 h-5"], name: "eye"));
                        }
                    });
                }
            });

            // Summary footer
            var verifiedCount = documents.Count(d => d.Status == "Verified");
            var reviewCount = documents.Count(d => d.Status == "Under Review");
            var pendingCount = documents.Count(d => d.Status == "Pending");

            view.Row(["mt-2 p-4 rounded-xl bg-secondary/30 dark:bg-secondary/10 border border-secondary/50 items-center gap-4 justify-between flex-wrap"], content: view =>
            {
                view.Row(["items-center gap-6 flex-wrap"], content: r =>
                {
                    if (verifiedCount > 0)
                    {
                        r.Row(["items-center gap-2"], content: item =>
                        {
                            item.Box(["w-2.5 h-2.5 rounded-full bg-success-solid"]);
                            item.Text([Text.Small, "text-muted-foreground font-medium"], $"{verifiedCount} Verified");
                        });
                    }
                    if (reviewCount > 0)
                    {
                        r.Row(["items-center gap-2"], content: item =>
                        {
                            item.Box(["w-2.5 h-2.5 rounded-full bg-brand-500"]);
                            item.Text([Text.Small, "text-muted-foreground font-medium"], $"{reviewCount} Under Review");
                        });
                    }
                    if (pendingCount > 0)
                    {
                        r.Row(["items-center gap-2"], content: item =>
                        {
                            item.Box(["w-2.5 h-2.5 rounded-full bg-warning-solid"]);
                            item.Text([Text.Small, "text-muted-foreground font-medium"], $"{pendingCount} Pending");
                        });
                    }
                });
                view.Text([Text.Caption, "text-muted-foreground"], $"Total: {documents.Count} files");
            });
        });
    }

    private void RenderHistoryTab(UIView view, Application selected)
    {
        var history = _caseHistory.TryGetValue(selected.Id, out var events) ? events : new List<HistoryEvent>();

        view.Column(["p-6 sm:p-8 lg:p-10 gap-6 motion-[0:opacity-0_translate-y-[8px],100:opacity-100_translate-y-0] motion-duration-300ms motion-ease-out"], content: view =>
        {
            // Header
            view.Row(["items-center gap-2 mb-2"], content: r =>
            {
                r.Icon(["w-5 h-5 text-brand-500"], name: "history");
                r.Text([Text.H3, "text-foreground font-semibold tracking-tight"], "Processing Timeline");
            });
            view.Text([Text.Small, "text-muted-foreground mb-4"], $"{history.Count} events recorded for this application");

            // Timeline
            view.Column(["relative"], content: view =>
            {
                // Vertical line
                view.Box(["absolute left-[19px] top-6 bottom-6 w-[2px] bg-gradient-to-b from-brand-400 via-secondary to-secondary/30 rounded-full"]);

                foreach (var evt in history)
                {
                    view.Row(["gap-5 relative group"], content: view =>
                    {
                        // Timeline dot
                        view.Column(["items-center shrink-0 z-10 pt-1"], content: c =>
                        {
                            c.Column([$"w-10 h-10 rounded-full items-center justify-center border-2 border-background shadow-sm {evt.ColorClass}"], content: dot =>
                            {
                                dot.Icon(["w-4 h-4"], name: evt.IconName);
                            });
                        });

                        // Event content card
                        view.Column(["flex-1 pb-8 group-last:pb-0"], content: c =>
                        {
                            c.Column(["p-4 rounded-xl border border-secondary/60 bg-card hover:border-brand-400/40 hover:shadow-sm transition-all duration-200 gap-2"], content: card =>
                            {
                                card.Row([Layout.Row.SpaceBetween, "items-start"], content: r =>
                                {
                                    r.Text(["font-semibold text-sm text-foreground tracking-tight"], evt.Action);
                                    r.Row(["items-center gap-1.5 shrink-0"], content: time =>
                                    {
                                        time.Icon(["w-3.5 h-3.5 text-muted-foreground/60"], name: "clock");
                                        time.Text([Text.Caption, "text-muted-foreground font-mono tabular-nums"], $"{evt.Date} · {evt.Time}");
                                    });
                                });

                                card.Text([Text.Small, "text-muted-foreground leading-relaxed"], evt.Detail);

                                card.Row(["items-center gap-1.5 mt-1"], content: r =>
                                {
                                    r.Icon(["w-3.5 h-3.5 text-muted-foreground/60"], name: "user");
                                    r.Text([Text.Caption, "text-muted-foreground font-medium"], evt.Actor);
                                });
                            });
                        });
                    });
                }
            });
        });
    }

    private void InfoCard(UIView view, string label, string value, string iconName, string styleClass)
    {
        view.Column([Card.Default, $"p-6 border-l-4 border-t-0 border-r-0 border-b-0 shadow-sm transition-all duration-300 relative overflow-hidden group {styleClass}"], content: card =>
        {
            card.Box(["absolute -right-6 -bottom-6 opacity-[0.02] group-hover:opacity-[0.04] dark:opacity-[0.03] dark:group-hover:opacity-[0.05] transition-opacity motion-safe:group-hover:scale-[1.15] duration-500 ease-out transform-gpu"], content: c => {
                c.Icon(["w-32 h-32"], name: iconName);
            });

            card.Row(["items-center gap-2 mb-3 relative z-10"], content: r => {
                r.Icon(["w-4 h-4 text-muted-foreground/80"], name: iconName);
                r.Text([Text.Caption, "text-muted-foreground uppercase tracking-widest font-semibold text-[11px]"], label);
            });
            card.Text([Text.H2, "text-foreground font-medium relative z-10 text-[1.15rem] tracking-tight"], value);
        });
    }

    private string GetStatusColor(string status) => status switch
    {
        "Approved" => "text-success-solid",
        "Rejected" => "text-error-solid",
        "In Progress" => "text-brand-600 dark:text-brand-400",
        "Pending Additional Info" => "text-warning-solid",
        _ => "text-muted-foreground"
    };

    private string GetStatusPillColor(string status) => status switch
    {
        "Approved" => "bg-success-primary/60 text-success-solid border-success-secondary/50",
        "Rejected" => "bg-error-secondary/60 text-error-solid border-error-secondary/50",
        "In Progress" => "bg-brand-50 text-brand-700 border-brand-200 dark:bg-brand-900/40 dark:text-brand-300 dark:border-brand-700/60",
        "Pending Additional Info" => "bg-warning-primary/60 text-warning-solid border-warning-secondary/50",
        _ => "bg-secondary text-secondary-foreground border-secondary"
    };

    private async Task ToggleThemeAsync()
    {
        var nextTheme = _currentTheme.Value == Constants.DarkTheme ? Constants.LightTheme : Constants.DarkTheme;
        var updated = await ClientFunctions.SetThemeAsync(nextTheme);

        if (updated)
        {
            _currentTheme.Value = nextTheme;
        }
    }

    private List<ChecklistItem> GetRequirementsChecklist(Application selected)
    {
        var docs = _caseDocuments.TryGetValue(selected.Id, out var d) ? d : new List<DocumentItem>();

        (string Status, DocumentItem? Doc) DocStatus(string docType)
        {
            var doc = docs.FirstOrDefault(d => d.Type == docType);
            if (doc == null) return ("missing", null);
            return (doc.Status switch
            {
                "Verified" => "fulfilled",
                "Under Review" => "under-review",
                "Pending" => "pending",
                _ => "pending"
            }, doc);
        }

        (string Status, DocumentItem? Doc) DocStatusByName(string nameContains)
        {
            var doc = docs.FirstOrDefault(d => d.Name.Contains(nameContains, StringComparison.OrdinalIgnoreCase));
            if (doc == null) return ("missing", null);
            return (doc.Status switch
            {
                "Verified" => "fulfilled",
                "Under Review" => "under-review",
                "Pending" => "pending",
                _ => "pending"
            }, doc);
        }

        (string Status, DocumentItem? Doc) HasIdentityVerified() 
        {
            var doc = docs.FirstOrDefault(d => d.Type == "Identity" && d.Status == "Verified");
            return doc != null ? ("fulfilled", doc) : DocStatus("Identity");
        }

        ChecklistItem CreateItem(string req, (string Status, DocumentItem? Doc) result) => new(req, result.Status, result.Doc);

        var admissionResult = DocStatusByName("Admission").Status == "missing" ? DocStatusByName("University") : DocStatusByName("Admission");
        var jobOfferResult = DocStatusByName("Job_Offer").Status == "missing" ? DocStatus("Employment") : DocStatusByName("Job_Offer");

        return selected.ApplicationType switch
        {
            "Student Residence Permit" => new List<ChecklistItem>
            {
                CreateItem("Valid passport", HasIdentityVerified()),
                CreateItem("University or institution acceptance letter", admissionResult),
                CreateItem("Proof of sufficient funds (min. \u20ac6,720/year)", DocStatus("Financial")),
                CreateItem("Health insurance coverage", DocStatus("Insurance")),
                CreateItem("Study plan", DocStatusByName("Study_Plan")),
            },
            "Work Residence Permit" => new List<ChecklistItem>
            {
                CreateItem("Valid passport", HasIdentityVerified()),
                CreateItem("Employment contract or job offer letter", jobOfferResult),
                CreateItem("Proof of qualifications or degree", DocStatus("Education")),
                CreateItem("Income verification", DocStatus("Financial")),
                CreateItem("Police clearance certificate", DocStatus("Background")),
                CreateItem("Finnish language proficiency (YKI certificate)", DocStatus("Language")),
                CreateItem("Proof of continuous residence (if applicable)", DocStatus("Residence")),
            },
            "Family Member Residence Permit" => new List<ChecklistItem>
            {
                CreateItem("Valid passport", HasIdentityVerified()),
                CreateItem("Proof of family relationship (marriage or birth certificate)", DocStatus("Family")),
                CreateItem("Sponsor\u2019s proof of income or employment", DocStatus("Financial")),
                CreateItem("Health insurance coverage", DocStatus("Insurance")),
                CreateItem("Proof of adequate housing in Finland", DocStatus("Residence")),
            },
            _ => new List<ChecklistItem>
            {
                CreateItem("Valid passport", DocStatus("Identity")),
                new("Supporting documents", docs.Count > 0 ? "fulfilled" : "missing", null),
            }
        };
    }
}
