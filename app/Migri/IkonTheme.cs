// ReSharper disable once CheckNamespace
// ReSharper disable MemberHidesStaticFromOuterClass

namespace Themes.Ikon;

public sealed class Theme : ITheme
{
    public string DefaultIconLibrary => "lucide";

    public string Css =>
        """
        @import url('https://fonts.googleapis.com/css2?family=Inter:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Crimson+Pro:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=JetBrains+Mono:ital,wght@0,400;0,500;0,600;0,700;1,400;1,500;1,600;1,700&display=swap');

        :root {
            /* Fonts */
            --font-sans: "Inter", system-ui, -apple-system, BlinkMacSystemFont, sans-serif;
            --font-body: "Inter", system-ui, -apple-system, BlinkMacSystemFont, sans-serif;
            --font-heading: "Poppins", system-ui, -apple-system, BlinkMacSystemFont, sans-serif;
            --font-serif: "Crimson Pro", ui-serif, Georgia, Cambria, "Times New Roman", Times, serif;
            --font-mono: "JetBrains Mono", SFMono-Regular, Menlo, Monaco, Consolas, monospace;
            --font-display: "Poppins";

            /* Brand color scale — Migri Theme */
            --brand-25:  #f5f7fc;
            --brand-50:  #ebf0fc;
            --brand-100: #dce4fa;
            --brand-200: #bed1f7;
            --brand-300: #98bbf1;
            --brand-400: #7aa9e6; /* migri-blue-light */
            --brand-500: #5587d4;
            --brand-600: #3c6ab8;
            --brand-700: #2c4e91;
            --brand-800: #27348b; /* migri-blue-dark */
            --brand-900: #202b70;
            --brand-950: #131a42;

            /* Neutral color scale — pure gray */
            --neutral-25:  #fafafa;
            --neutral-50:  #f5f5f5;
            --neutral-100: #f4f4f5;
            --neutral-200: #e4e4e7;
            --neutral-300: #d4d4d8;
            --neutral-400: #a1a1aa;
            --neutral-500: #71717a;
            --neutral-600: #52525b;
            --neutral-700: #3f3f46;
            --neutral-800: #27272a;
            --neutral-900: #18181b;
            --neutral-950: #09090b;

            /* Radii — all derived from --radius-base */
            --radius-base: 0.625rem;
            --radius-xxs: calc(var(--radius-base) * 0.2);
            --radius-xs: calc(var(--radius-base) * 0.3);
            --radius-sm: calc(var(--radius-base) * 0.4);
            --radius-md: calc(var(--radius-base) * 0.6);
            --radius-lg: calc(var(--radius-base) * 0.8);
            --radius-xl: calc(var(--radius-base) * 1.2);
            --radius-2xl: calc(var(--radius-base) * 1.6);
            --radius-3xl: calc(var(--radius-base) * 2.0);
            --radius-4xl: calc(var(--radius-base) * 2.4);
            --radius-full: 9999px;
            --radius-none: 0;

            /* Shadows */
            --shadow-2xs: 0 1px 2px rgb(0 0 0 / 0.04);
            --shadow-xs: 0 1px 2px rgb(0 0 0 / 0.05);
            --shadow-sm: 0 1px 3px rgb(0 0 0 / 0.08), 0 1px 2px rgb(0 0 0 / 0.04);
            --shadow-md: 0 4px 6px rgb(0 0 0 / 0.06), 0 2px 4px rgb(0 0 0 / 0.04);
            --shadow-lg: 0 10px 15px rgb(0 0 0 / 0.08), 0 4px 6px rgb(0 0 0 / 0.04);
            --shadow-xl: 0 20px 25px rgb(0 0 0 / 0.08), 0 8px 10px rgb(0 0 0 / 0.04);
            --shadow-2xl: 0 25px 50px rgb(0 0 0 / 0.16);
            --shadow-3xl: 0 35px 60px rgb(0 0 0 / 0.2);
            --shadow-inner: inset 0 2px 4px rgb(0 0 0 / 0.04);

            /* Core semantic tokens */
            --bg-background: #ffffff;
            --bg-card: #ffffff;
            --bg-popover: #ffffff;
            --bg-muted: #f8f8f8;
            --bg-accent: var(--brand-100);
            --text-foreground: #111111; /* migri-black */
            --text-card-foreground: #111111;
            --text-popover-foreground: #111111;
            --text-primary-foreground: #ffffff;
            --text-secondary-foreground: #4b5666;
            --text-muted-foreground: #6c727e;
            --text-accent-foreground: var(--brand-900);
            --text-danger-foreground: #fef2f2;

            /* Background semantic tokens - light theme */
            --bg-active: var(--neutral-50);
            --bg-blue-light: #f0f9ff;
            --bg-blue: #eff6ff;
            --bg-brand-primary-alt: var(--brand-100);
            --bg-brand-primary: var(--brand-500);
            --bg-brand-secondary: var(--brand-100);
            --bg-brand-section-subtle: var(--brand-800);
            --bg-brand-section: var(--brand-700);
            --bg-brand-solid-hover: var(--brand-600);
            --bg-brand-solid: var(--brand-500);
            --bg-danger: #f14444;
            --bg-disabled-subtle: var(--neutral-25);
            --bg-disabled: var(--neutral-100);
            --bg-error-primary: #fef2f2;
            --bg-error-secondary: #fee2e2;
            --bg-error-solid-hover: #b91c1c;
            --bg-error-solid: #dc2626;
            --bg-gray-blue: #f8fafc;
            --bg-indigo: #eef2ff;
            --bg-info-solid-hover: #0284c7;
            --bg-info-solid: #0ea5e9;
            --bg-orange: #fff7ed;
            --bg-overlay: var(--neutral-950);
            --bg-pink: #fdf2f8;
            --bg-primary-alt: #ffffff;
            --bg-primary-hover: var(--neutral-100);
            --bg-primary-solid: var(--neutral-900);
            --bg-primary: #ffffff;
            --bg-purple: #faf5ff;
            --bg-quaternary: var(--neutral-200);
            --bg-secondary-alt: var(--neutral-25);
            --bg-secondary-hover: #e4e8ef;
            --bg-secondary-solid: var(--neutral-600);
            --bg-secondary-subtle: var(--neutral-25);
            --bg-secondary: var(--neutral-50);
            --bg-success-primary: #f0fdf4;
            --bg-success-secondary: #dcfce7;
            --bg-success-solid-hover: #15803d;
            --bg-success-solid: #16a34a;
            --bg-success-subtle: #f0fdf4;
            --bg-tertiary: var(--neutral-200);
            --bg-warning-primary: #fffbeb;
            --bg-warning-secondary: #fef3c7;
            --bg-warning-solid-hover: #b45309;
            --bg-warning-solid: #d97706;

            /* Border semantic tokens - light theme */
            --border-blue-light: #bae6fd;
            --border-blue: #bfdbfe;
            --border-brand-alt: var(--brand-600);
            --border-brand-secondary: var(--brand-200);
            --border-brand: var(--brand-500);
            --border-disabled-subtle: var(--neutral-200);
            --border-disabled: var(--neutral-300);
            --border-danger: #dc2626;
            --border-error-secondary: #fecaca;
            --border-error-subtle: #fca5a5;
            --border-error: #ef4444;
            --border-focus-ring: var(--brand-500);
            --border-gray-blue: #e2e8f0;
            --border-indigo: #c7d2fe;
            --border-info: #7dd3fc;
            --border-input: #e4e8ef;
            --border-orange: #fed7aa;
            --border-pink: #fbcfe8;
            --border-primary: var(--neutral-300);
            --border-purple: #ddd6fe;
            --border-ring: var(--brand-500);
            --border-secondary-alt: rgb(0 0 0 / 0.06);
            --border-secondary: #e4e8ef;
            --border-success: #86efac;
            --border-tertiary: var(--neutral-100);
            --border-warning: #fde68a;
            --border-muted-foreground: var(--neutral-500);

            /* Foreground semantic tokens - for icons and UI elements (not text).
               These have different contrast values optimized for iconography. */
            --fg-brand-primary-alt: var(--brand-600);
            --fg-brand-primary: var(--brand-500);
            --fg-brand-secondary-alt: var(--brand-400);
            --fg-brand-secondary-hover: var(--brand-600);
            --fg-brand-secondary: var(--brand-500);
            --fg-danger-primary-hover: #fecaca;
            --fg-danger-primary: #fca5a5;
            --fg-disabled-subtle: var(--neutral-300);
            --fg-disabled: var(--neutral-400);
            --fg-error-primary: #dc2626;
            --fg-error-secondary: #ef4444;
            --fg-primary: var(--neutral-900);
            --fg-quaternary-hover: var(--neutral-500);
            --fg-quaternary: var(--neutral-400);
            --fg-secondary-hover: var(--neutral-800);
            --fg-secondary: var(--neutral-700);
            --fg-success-primary: #16a34a;
            --fg-success-secondary: #22c55e;
            --fg-tertiary-hover: var(--neutral-700);
            --fg-tertiary: var(--neutral-600);
            --fg-warning-primary: #d97706;
            --fg-warning-secondary: #f59e0b;
            --fg-white: #ffffff;

            /* Text semantic tokens - for text content only.
               These have different contrast values optimized for readability. */
            --text-blue-light: #0369a1;
            --text-blue: #1d4ed8;
            --text-brand-primary: var(--brand-700);
            --text-brand-secondary-hover: var(--brand-600);
            --text-brand-secondary: var(--brand-500);
            --text-brand-tertiary-alt: var(--brand-400);
            --text-brand-tertiary: var(--brand-500);
            --text-danger: #dc2626;
            --text-disabled: var(--neutral-500);
            --text-error-primary-hover: #b91c1c;
            --text-error-primary: #dc2626;
            --text-gray-blue: #334155;
            --text-indigo: #4338ca;
            --text-info-primary: #0284c7;
            --text-orange: #c2410c;
            --text-pink: #be185d;
            --text-placeholder-subtle: var(--neutral-300);
            --text-placeholder: var(--neutral-500);
            --text-primary-on-brand: #ffffff;
            --text-primary: #111111; /* migri-black */
            --text-purple: var(--brand-500);
            --text-quaternary-on-brand: var(--brand-200);
            --text-quaternary: #6c727e;
            --text-secondary-hover: var(--neutral-800);
            --text-secondary-on-brand: #ede9fe;
            --text-secondary: var(--neutral-700);
            --text-success-primary: #16a34a;
            --text-success-secondary: #15803d;
            --text-tertiary-hover: var(--neutral-700);
            --text-tertiary-on-brand: #ede9fe;
            --text-tertiary: var(--neutral-600);
            --text-warning-primary: #d97706;
            --text-warning-secondary: #b45309;
            --text-white: #ffffff;
        }

        [data-theme="dark"] {
            /* Core semantic tokens */
            --bg-background: #161616;
            --bg-card: #262626;
            --bg-popover: #262626;
            --bg-muted: #2d2d2d;
            --bg-accent: var(--brand-900);
            --text-foreground: #e4e4e4;
            --text-card-foreground: #e4e4e4;
            --text-popover-foreground: #e4e4e4;
            --text-primary-foreground: #1e1b4b;
            --text-secondary-foreground: #e4e4e4;
            --text-muted-foreground: #a4a4a4;
            --text-accent-foreground: var(--brand-200);
            --text-danger-foreground: #fafafa;

            /* Background semantic tokens - dark theme */
            --bg-active: #262626;
            --bg-blue-light: #0c4a6e;
            --bg-blue: #1e3a5f;
            --bg-brand-primary-alt: var(--brand-900);
            --bg-brand-primary: var(--brand-500);
            --bg-brand-secondary: var(--brand-900);
            --bg-brand-section-subtle: #161616;
            --bg-brand-section: #262626;
            --bg-brand-solid-hover: var(--brand-400);
            --bg-brand-solid: var(--brand-500);
            --bg-danger: #f14444;
            --bg-disabled-subtle: #262626;
            --bg-disabled: #262626;
            --bg-error-primary: #450a0a;
            --bg-error-secondary: #7f1d1d;
            --bg-error-solid-hover: #f87171;
            --bg-error-solid: #ef4444;
            --bg-gray-blue: #0f172a;
            --bg-indigo: #1e1b4b;
            --bg-info-solid-hover: #38bdf8;
            --bg-info-solid: #0ea5e9;
            --bg-orange: #431407;
            --bg-overlay: #262626;
            --bg-pink: #500724;
            --bg-primary-alt: #262626;
            --bg-primary-hover: #262626;
            --bg-primary-solid: #e4e4e4;
            --bg-primary: #161616;
            --bg-purple: var(--brand-900);
            --bg-quaternary: #404040;
            --bg-secondary-alt: #161616;
            --bg-secondary-hover: #404040;
            --bg-secondary-solid: #a4a4a4;
            --bg-secondary-subtle: #262626;
            --bg-secondary: #262626;
            --bg-success-primary: #052e16;
            --bg-success-secondary: #14532d;
            --bg-success-solid-hover: #4ade80;
            --bg-success-solid: #22c55e;
            --bg-success-subtle: #052e16;
            --bg-tertiary: #262626;
            --bg-warning-primary: #451a03;
            --bg-warning-secondary: #78350f;
            --bg-warning-solid-hover: #fbbf24;
            --bg-warning-solid: #f59e0b;

            /* Border semantic tokens - dark theme */
            --border-blue-light: #0369a1;
            --border-blue: #1e40af;
            --border-brand-alt: var(--brand-600);
            --border-brand-secondary: var(--brand-900);
            --border-brand: var(--brand-500);
            --border-danger: #f87171;
            --border-disabled-subtle: #262626;
            --border-disabled: #404040;
            --border-error-secondary: #991b1b;
            --border-error-subtle: #dc2626;
            --border-error: #f87171;
            --border-focus-ring: var(--brand-500);
            --border-gray-blue: #334155;
            --border-indigo: #3730a3;
            --border-info: #0284c7;
            --border-input: #404040;
            --border-orange: #9a3412;
            --border-pink: #9d174d;
            --border-primary: #404040;
            --border-purple: var(--brand-900);
            --border-ring: var(--brand-500);
            --border-secondary-alt: #262626;
            --border-secondary: #404040;
            --border-success: #166534;
            --border-tertiary: #262626;
            --border-warning: #92400e;
            --border-muted-foreground: #a4a4a4;

            /* Foreground semantic tokens - for icons and UI elements (not text).
               These have different contrast values optimized for iconography. */
            --fg-brand-primary-alt: var(--brand-400);
            --fg-brand-primary: var(--brand-500);
            --fg-brand-secondary-alt: #404040;
            --fg-brand-secondary-hover: var(--brand-400);
            --fg-brand-secondary: var(--brand-500);
            --fg-danger-primary-hover: #fecaca;
            --fg-danger-primary: #f87171;
            --fg-disabled-subtle: #404040;
            --fg-disabled: #525252;
            --fg-error-primary: #ef4444;
            --fg-error-secondary: #f87171;
            --fg-primary: #e4e4e4;
            --fg-quaternary-hover: #737373;
            --fg-quaternary: #525252;
            --fg-secondary-hover: #e4e4e4;
            --fg-secondary: #d4d4d4;
            --fg-success-primary: #4ade80;
            --fg-success-secondary: #86efac;
            --fg-tertiary-hover: #d4d4d4;
            --fg-tertiary: #a4a4a4;
            --fg-warning-primary: #fbbf24;
            --fg-warning-secondary: #fcd34d;
            --fg-white: #ffffff;

            /* Text semantic tokens - for text content only.
               These have different contrast values optimized for readability. */
            --text-blue-light: #7dd3fc;
            --text-blue: #93c5fd;
            --text-brand-primary: var(--brand-200);
            --text-brand-secondary-hover: var(--brand-400);
            --text-brand-secondary: var(--brand-500);
            --text-brand-tertiary-alt: var(--brand-400);
            --text-brand-tertiary: var(--brand-500);
            --text-danger: #f87171;
            --text-disabled: #525252;
            --text-error-primary-hover: #fecaca;
            --text-error-primary: #f87171;
            --text-gray-blue: #cbd5e1;
            --text-indigo: #a5b4fc;
            --text-info-primary: #38bdf8;
            --text-orange: #fdba74;
            --text-pink: #f9a8d4;
            --text-placeholder-subtle: #404040;
            --text-placeholder: #737373;
            --text-primary-on-brand: #ffffff;
            --text-primary: #e4e4e4;
            --text-purple: var(--brand-500);
            --text-quaternary-on-brand: var(--brand-200);
            --text-quaternary: #737373;
            --text-secondary-hover: #e4e4e4;
            --text-secondary-on-brand: #d4d4d4;
            --text-secondary: #a4a4a4;
            --text-success-primary: #4ade80;
            --text-success-secondary: #86efac;
            --text-tertiary-hover: #d4d4d4;
            --text-tertiary-on-brand: #a4a4a4;
            --text-tertiary: #737373;
            --text-warning-primary: #fbbf24;
            --text-warning-secondary: #fcd34d;
            --text-white: #ffffff;

            /* Shadows - dark mode with subtle glow effect */
            --shadow-2xs: 0 1px 2px rgb(0 0 0 / 0.3);
            --shadow-xs: 0 1px 2px rgb(0 0 0 / 0.4);
            --shadow-sm: 0 1px 3px rgb(0 0 0 / 0.4), 0 1px 2px rgb(0 0 0 / 0.3);
            --shadow-md: 0 4px 6px rgb(0 0 0 / 0.4), 0 2px 4px rgb(0 0 0 / 0.3);
            --shadow-lg: 0 10px 15px rgb(0 0 0 / 0.4), 0 4px 6px rgb(0 0 0 / 0.3);
            --shadow-xl: 0 20px 25px rgb(0 0 0 / 0.4), 0 8px 10px rgb(0 0 0 / 0.3);
            --shadow-2xl: 0 25px 50px rgb(0 0 0 / 0.5);
            --shadow-3xl: 0 35px 60px rgb(0 0 0 / 0.6);
            --shadow-inner: inset 0 2px 4px rgb(0 0 0 / 0.3);
        }
        """;
}

public static class Helper
{
    public static string Join(params string?[] parts)
        => string.Join(' ', parts.Where(p => !string.IsNullOrWhiteSpace(p)));
}

public static class State
{
    public const string Focusable = "focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-focus-ring focus-visible:ring-offset-2 ring-offset-primary";
    public const string Disabled = "disabled:cursor-not-allowed disabled:opacity-50";
    public const string Pressable = "active:scale-[.98] transition-transform";
    public const string Loading = "opacity-70 cursor-wait";
    public const string Selected = "data-[state=selected]:bg-active data-[state=selected]:text-primary";
    public const string Checked = "data-[state=checked]:bg-brand-solid data-[state=checked]:text-primary-foreground";
    public const string Invalid = "border-error focus-visible:ring-error";
    public const string Readonly = "read-only:bg-tertiary read-only:cursor-default read-only:focus-visible:ring-0";
    public const string Indeterminate = "data-[state=indeterminate]:bg-tertiary data-[state=indeterminate]:after:absolute data-[state=indeterminate]:after:content-[''] data-[state=indeterminate]:after:h-0.5 data-[state=indeterminate]:after:w-2/3 data-[state=indeterminate]:after:bg-current";
    public const string Validating = "data-[validating]:opacity-70 data-[validating]:cursor-wait data-[validating]:animate-pulse";
    public const string Empty = "data-[empty]:text-tertiary data-[empty]:italic";
    public const string Pending = "data-[pending]:opacity-70 data-[pending]:pointer-events-none";
    public const string Success = "data-[success]:border-success data-[success]:focus-visible:ring-success";
    public const string Warning = "data-[warning]:border-warning data-[warning]:focus-visible:ring-warning";
}

public static class Interaction
{
    public const string HoverLift = "transition-transform duration-200 hover:-translate-y-0.5 motion-reduce:hover:translate-y-0";
    public const string HoverGlow = "transition-shadow duration-200 hover:shadow-md motion-reduce:transition-none";
    public const string HoverCard = $"{HoverLift} {HoverGlow}";
}

public static class ZIndex
{
    public const string Dropdown = "z-40";
    public const string Sticky = "z-40";
    public const string Modal = "z-50";
    public const string Popover = "z-50";
    public const string Tooltip = "z-50";
    public const string Toast = "z-[100]";
}

public static class Tokens
{
    public static class Opacity
    {
        public const string O5 = "/5";
        public const string O10 = "/10";
        public const string O15 = "/15";
        public const string O20 = "/20";
        public const string O25 = "/25";
        public const string O30 = "/30";
        public const string O40 = "/40";
        public const string O50 = "/50";
        public const string GlassSm = "/[0.04]";
        public const string GlassMd = "/10";
        public const string GlassLg = "/40";
    }

    public static class Blur
    {
        public const string Sm = "backdrop-blur-sm";
        public const string Md = "backdrop-blur-md";
        public const string Lg = "backdrop-blur-lg";
    }

    public static class Width
    {
        public const string Popover = "w-72";
        public const string Dialog = "max-w-lg";
        public const string DialogSm = "max-w-sm";
        public const string DialogMd = "max-w-md";
        public const string DialogLg = "max-w-lg";
        public const string DialogXl = "max-w-xl";
        public const string Toast = "max-w-[420px]";
        public const string Sheet = "w-full sm:max-w-sm";
        public const string Drawer = "max-w-sm";
    }

    public static class FocusRing
    {
        public const string Default = "ring-2 ring-ring ring-offset-2 ring-offset-background";
        public const string Subtle = "ring-1 ring-ring/50 ring-offset-2 ring-offset-background";
        public const string Strong = "ring-2 ring-ring ring-offset-4 ring-offset-background";
    }

    public static class Radius
    {
        public const string None = "rounded-none";
        public const string Sm = "rounded-sm";
        public const string Md = "rounded-md";
        public const string Lg = "rounded-lg";
        public const string Xl = "rounded-xl";
        public const string Xl2 = "rounded-2xl";
        public const string Full = "rounded-full";
    }

    public static class Duration
    {
        public const string Instant = "duration-0";
        public const string Fast = "duration-150";
        public const string Normal = "duration-200";
        public const string Slow = "duration-300";
        public const string Slower = "duration-500";
    }

    public static class Shadow
    {
        public const string None = "shadow-none";
        public const string Sm = "shadow-sm";
        public const string Md = "shadow-md";
        public const string Lg = "shadow-lg";
        public const string Xl = "shadow-xl";
        public const string Xl2 = "shadow-2xl";
    }
}

public static class Tone
{
    public const string Primary = "border-0 bg-brand-solid text-primary-foreground hover:bg-brand-solid-hover";
    public const string Secondary = "border-0 bg-quaternary text-secondary-foreground hover:bg-secondary-hover";
    public const string Muted = "border-0 bg-quaternary text-muted-foreground hover:bg-secondary-hover";
    public const string Success = "border-0 bg-success-solid text-primary-foreground hover:bg-success-solid-hover";
    public const string Warning = "border-0 bg-warning-solid text-primary-foreground hover:bg-warning-solid-hover";
    public const string Danger = "border-0 bg-error-solid text-primary-foreground hover:bg-error-solid-hover";
    public const string Info = "border-0 bg-info-solid text-primary-foreground hover:bg-info-solid-hover";
    public const string Ghost = "border-0 bg-transparent text-primary hover:bg-secondary-hover";
    public const string Outline = "border border-input bg-transparent text-primary hover:bg-secondary-hover";
    public const string Link = "border-0 bg-transparent text-brand-primary underline-offset-4 hover:underline";
    public const string Subtle = "border-0 bg-muted text-tertiary";
}

public static class Text
{
    public const string Display = "block text-4xl font-bold tracking-tight";
    public const string H1 = "block text-3xl font-semibold tracking-tight";
    public const string H2 = "block text-xl font-semibold tracking-tight";
    public const string H3 = "block text-lg font-medium";
    public const string H4 = "block text-base font-medium";
    public const string Body = "block text-sm leading-relaxed";
    public const string BodyStrong = "block text-sm font-medium leading-relaxed";
    public const string Caption = "block text-xs text-quaternary";
    public const string Code = "font-mono text-sm bg-quaternary px-1.5 py-0.5 rounded";
    public const string Muted = "text-sm text-quaternary";
    public const string Small = "text-xs";
    public const string Link = "text-sm text-primary hover:underline cursor-pointer";
    public const string Label = "text-sm font-medium leading-none";
}

public static class Surface
{
    public const string Background = "bg-background text-foreground";
    public const string Card = "rounded-lg border border-secondary bg-card text-card-foreground shadow-sm";
    public const string CardElevated = "rounded-lg border border-secondary bg-card text-card-foreground shadow-md";
    public const string Popover = "rounded-lg border border-secondary bg-popover text-popover-foreground shadow-lg";
    public const string Floating = "rounded-md border border-secondary bg-popover text-popover-foreground shadow-xl";
    public const string Overlay = "fixed inset-0 bg-black/70 backdrop-blur-sm";
    public const string Glass = "bg-white/10 dark:bg-black/20 backdrop-blur-md border border-white/20";
    public const string GlassCard = $"rounded-lg {Glass} text-foreground shadow-sm";
}

public static class Layout
{
    public const string Page = "mx-auto flex max-w-5xl flex-col gap-6 p-6";
    public const string Section = "flex flex-col gap-4";
    public const string SectionHeader = "flex items-center justify-between gap-2";
    public const string SectionBody = "flex flex-col gap-3";

    public static class Row
    {
        public const string Xs = "flex flex-row items-center gap-1";
        public const string Sm = "flex flex-row items-center gap-2";
        public const string Md = "flex flex-row items-center gap-3";
        public const string Lg = "flex flex-row items-center gap-4";
        public const string Xl = "flex flex-row items-center gap-6";
        public const string Default = Sm;
        public const string InlineCenter = "flex items-center gap-2";
        public const string SpaceBetween = "flex items-center justify-between";
    }

    public static class Column
    {
        public const string Xs = "flex flex-col gap-1";
        public const string Sm = "flex flex-col gap-2";
        public const string Md = "flex flex-col gap-3";
        public const string Lg = "flex flex-col gap-4";
        public const string Xl = "flex flex-col gap-6";
        public const string Default = Sm;
        public const string Center = "flex flex-col items-center gap-2";
    }

    public static class Grid
    {
        public const string Cols2 = "grid grid-cols-2 gap-3";
        public const string Cols3 = "grid grid-cols-3 gap-3";
        public const string Cols4 = "grid grid-cols-4 gap-3";
    }

    public const string RowWrap = "flex flex-wrap items-center gap-3";
    public const string Center = "flex items-center justify-center";
    public const string Stretch = "w-full h-full";
}

public static class Page
{
    public const string Base = "min-h-screen bg-background text-foreground";
    public const string Gradient = "bg-[radial-gradient(ellipse_at_top_left,rgba(124,111,249,0.15)_0%,transparent_45%),radial-gradient(ellipse_at_top_right,rgba(95,214,225,0.15)_0%,transparent_50%),radial-gradient(ellipse_at_bottom,rgba(255,111,183,0.12)_0%,transparent_55%)]";
    public const string Default = $"{Base} {Gradient}";
    public const string Plain = Base;
}

public static class Icon
{
    public static class Size
    {
        public const string Xs = "w-4 h-4 shrink-0";
        public const string Sm = "w-5 h-5 shrink-0";
        public const string Md = "w-6 h-6 shrink-0";
        public const string Lg = "w-8 h-8 shrink-0";
    }

    public const string Default = Size.Sm;
    public const string Spinner = "inline-block animate-spin rounded-full border-2 border-muted-foreground/40 border-t-muted-foreground h-4 w-4";
    public const string SpinnerSm = "inline-block animate-spin rounded-full border-2 border-muted-foreground/40 border-t-muted-foreground h-3 w-3";
    public const string SpinnerLg = "inline-block animate-spin rounded-full border-2 border-muted-foreground/40 border-t-muted-foreground h-5 w-5";
}

public static class Separator
{
    public const string Base = "shrink-0 bg-quaternary";

    public static class Orientation
    {
        public const string Horizontal = "h-[1px] w-full";
        public const string Vertical = "w-[1px] h-full";
    }

    public static class Variant
    {
        public const string Default = "bg-quaternary";
        public const string Subtle = "bg-tertiary";
        public const string Strong = "bg-secondary-solid/20";
    }

    public const string Horizontal = $"{Base} {Orientation.Horizontal}";
    public const string Vertical = $"{Base} {Orientation.Vertical}";
}

public static class OnSurface
{
    public static class Default
    {
        public const string Text = "text-foreground";
        public const string Muted = "text-quaternary";
        public const string Caption = "text-quaternary";
        public const string Subtle = "text-quaternary/80";
    }

    public static class Card
    {
        public const string Text = "text-card-foreground";
        public const string Muted = "text-quaternary";
        public const string Caption = "text-quaternary";
        public const string Subtle = "text-quaternary/80";
    }

    public static class Popover
    {
        public const string Text = "text-popover-foreground";
        public const string Muted = "text-quaternary";
        public const string Caption = "text-quaternary";
        public const string Subtle = "text-quaternary/80";
    }
}

public static class Button
{
    public const string Base = $"inline-flex items-center justify-center whitespace-nowrap rounded-md text-sm font-medium ring-offset-background transition-colors cursor-pointer {State.Focusable} disabled:pointer-events-none disabled:opacity-50";

    public static class Variant
    {
        public const string Primary = Tone.Primary;
        public const string Secondary = Tone.Secondary;
        public const string Outline = Tone.Outline;
        public const string Ghost = Tone.Ghost;
        public const string Danger = Tone.Danger;
        public const string Link = Tone.Link;
    }

    public static class Size
    {
        public const string Sm = "h-9 px-3 rounded-md";
        public const string Md = "h-10 px-4 py-2";
        public const string Lg = "h-11 px-8 rounded-md";
        public const string Icon = "h-10 w-10";
    }

    public const string PrimarySm = $"{Base} {Variant.Primary} {Size.Sm} {State.Pressable}";
    public const string PrimaryMd = $"{Base} {Variant.Primary} {Size.Md} {State.Pressable}";
    public const string PrimaryLg = $"{Base} {Variant.Primary} {Size.Lg} {State.Pressable}";
    public const string Default = PrimaryMd;
    public const string SecondarySm = $"{Base} {Variant.Secondary} {Size.Sm} {State.Pressable}";
    public const string SecondaryMd = $"{Base} {Variant.Secondary} {Size.Md} {State.Pressable}";
    public const string SecondaryLg = $"{Base} {Variant.Secondary} {Size.Lg} {State.Pressable}";
    public const string OutlineSm = $"{Base} {Variant.Outline} {Size.Sm} {State.Pressable}";
    public const string OutlineMd = $"{Base} {Variant.Outline} {Size.Md} {State.Pressable}";
    public const string OutlineLg = $"{Base} {Variant.Outline} {Size.Lg} {State.Pressable}";
    public const string GhostSm = $"{Base} {Variant.Ghost} {Size.Sm} {State.Pressable}";
    public const string GhostMd = $"{Base} {Variant.Ghost} {Size.Md} {State.Pressable}";
    public const string GhostLg = $"{Base} {Variant.Ghost} {Size.Lg} {State.Pressable}";
    public const string DangerSm = $"{Base} {Variant.Danger} {Size.Sm} {State.Pressable}";
    public const string DangerMd = $"{Base} {Variant.Danger} {Size.Md} {State.Pressable}";
    public const string DangerLg = $"{Base} {Variant.Danger} {Size.Lg} {State.Pressable}";
    public const string LinkSm = $"{Base} {Variant.Link} {Size.Sm}";
    public const string LinkMd = $"{Base} {Variant.Link} {Size.Md}";
    public const string LinkLg = $"{Base} {Variant.Link} {Size.Lg}";
}

public static class Input
{
    public const string Base = $"flex w-full rounded-md border bg-background text-foreground transition-colors ring-offset-background placeholder:text-quaternary cursor-text {State.Focusable} {State.Disabled} file:border-0 file:bg-transparent file:text-sm file:font-medium";

    public static class Size
    {
        public const string Sm = "h-8 px-2 text-xs";
        public const string Md = "h-10 px-3 text-sm";
        public const string Lg = "h-12 px-4 text-base";
    }

    public static class Variant
    {
        public const string Default = "border-input";
        public const string Success = "border-success focus-visible:ring-success/50";
        public const string Warning = "border-warning focus-visible:ring-warning/50";
        public const string Error = "border-danger focus-visible:ring-danger/50";
    }

    public const string Default = $"{Base} {Variant.Default} {Size.Md}";
    public const string DefaultSm = $"{Base} {Variant.Default} {Size.Sm}";
    public const string DefaultLg = $"{Base} {Variant.Default} {Size.Lg}";
    public const string Invalid = $"{Default} {State.Invalid}";
    public const string InvalidSm = $"{DefaultSm} {State.Invalid}";
    public const string InvalidLg = $"{DefaultLg} {State.Invalid}";
    public const string Ghost = $"{Base} bg-transparent border-transparent {Size.Md}";

    public static class Password
    {
        public const string Wrapper = "relative";
        public const string Input = "pr-10";
        public const string Toggle = "absolute right-2 top-1/2 -translate-y-1/2 cursor-pointer text-quaternary hover:text-foreground transition-colors";
    }
}

public static class Textarea
{
    public const string Base = $"w-full rounded-md border border-secondary bg-background text-foreground transition-colors ring-offset-background placeholder:text-quaternary cursor-text {State.Focusable} {State.Disabled}";

    public static class Size
    {
        public const string Sm = "min-h-[60px] px-2 py-1.5 text-xs";
        public const string Md = "min-h-[80px] px-3 py-2 text-sm";
        public const string Lg = "min-h-[120px] px-4 py-3 text-base";
    }

    public static class Variant
    {
        public const string Default = "border-input";
        public const string Success = "border-success focus-visible:ring-success/50";
        public const string Warning = "border-warning focus-visible:ring-warning/50";
        public const string Error = "border-danger focus-visible:ring-danger/50";
    }

    public const string Default = $"{Base} {Variant.Default} {Size.Md}";
    public const string DefaultSm = $"{Base} {Variant.Default} {Size.Sm}";
    public const string DefaultLg = $"{Base} {Variant.Default} {Size.Lg}";
    public const string Invalid = $"{Default} {State.Invalid}";
}

public static class Card
{
    public const string Base = "rounded-lg border border-secondary bg-card text-card-foreground";

    public static class Variant
    {
        public const string Default = "shadow-sm";
        public const string Elevated = "shadow-md";
        public const string Strong = "shadow-lg";
        public const string Outline = "shadow-none border-2";
        public const string Ghost = "shadow-none border-transparent bg-transparent";
        public const string Interactive = "shadow-sm hover:shadow-md hover:border-primary/50 transition-all cursor-pointer";
        public const string Glass = "bg-white/10 dark:bg-black/20 backdrop-blur-md border border-white/20 shadow-sm";
        public const string GlassSubtle = "bg-white/5 dark:bg-black/10 backdrop-blur-sm border border-white/10";
    }

    public const string Sm = $"{Base} shadow-sm";
    public const string Md = $"{Base} shadow-md";
    public const string Lg = $"{Base} shadow-lg";
    public const string Default = $"{Base} {Variant.Default}";
    public const string Elevated = $"{Base} {Variant.Elevated}";
    public const string Interactive = $"{Base} {Variant.Interactive}";
    public const string Glass = $"{Base} {Variant.Glass}";
    public const string GlassSubtle = $"{Base} {Variant.GlassSubtle}";
    public const string Header = "flex flex-col gap-1.5 p-6";
    public const string Content = "p-6 pt-0";
    public const string Footer = "flex items-center gap-2 p-6 pt-0";
    public const string HeaderRow = "flex justify-between items-center mb-2";
}

public static class Badge
{
    public const string Base = $"inline-flex items-center rounded-full border border-secondary font-semibold transition-colors {State.Focusable}";

    public static class Size
    {
        public const string Sm = "px-2 py-0.5 text-[10px]";
        public const string Md = "px-2.5 py-0.5 text-xs";
        public const string Lg = "px-3 py-1 text-sm";
    }

    public static class Variant
    {
        public const string Default = $"border-transparent {Tone.Primary}";
        public const string Secondary = $"border-transparent {Tone.Secondary}";
        public const string Danger = $"border-transparent {Tone.Danger}";
        public const string Subtle = $"border-transparent {Tone.Subtle}";
        public const string Outline = "border-border bg-transparent text-foreground";
    }

    public const string DefaultSm = $"{Base} {Size.Sm} {Variant.Default}";
    public const string DefaultMd = $"{Base} {Size.Md} {Variant.Default}";
    public const string DefaultLg = $"{Base} {Size.Lg} {Variant.Default}";
    public const string Default = DefaultMd;
    public const string Secondary = $"{Base} {Size.Md} {Variant.Secondary}";
    public const string Danger = $"{Base} {Size.Md} {Variant.Danger}";
    public const string Subtle = $"{Base} {Size.Md} {Variant.Subtle}";
    public const string Outline = $"{Base} {Size.Md} {Variant.Outline}";
}

public static class Dialog
{
    public const string Overlay = "fixed inset-0 z-50 bg-black/70 backdrop-blur-sm";
    public const string Content = "fixed left-1/2 top-1/2 z-50 w-full max-w-lg -translate-x-1/2 -translate-y-1/2 rounded-lg border border-secondary bg-popover text-popover-foreground shadow-lg p-6 font-sans";
    public const string Header = "flex flex-col gap-2 text-center sm:text-left";
    public const string Title = "text-lg font-semibold tracking-tight";
    public const string Description = "text-sm text-quaternary";
    public const string Footer = "mt-6 flex flex-col-reverse gap-2 sm:flex-row sm:justify-end";
    public const string CloseButton = $"absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 {State.Focusable} disabled:pointer-events-none";
}

public static class DropdownMenu
{
    public const string Content = "z-50 min-w-[8rem] overflow-hidden rounded-md border border-secondary bg-popover text-popover-foreground shadow-md";
    public const string Label = "px-2 py-1.5 text-sm font-semibold";
    public const string Separator = "h-px bg-quaternary";
    public const string Group = "p-1";
    public const string Item = "relative flex cursor-default select-none items-center gap-2 rounded-sm px-2 py-1.5 text-sm outline-none [&_svg]:size-3.5 [&_svg]:shrink-0 transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50";
    public const string CheckboxItem = "relative flex cursor-default select-none items-center gap-2 rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none [&_svg]:size-3.5 [&_svg]:shrink-0 transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50";
    public const string RadioItem = "relative flex cursor-default select-none items-center gap-2 rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none [&_svg]:size-3.5 [&_svg]:shrink-0 transition-colors focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50";
    public const string Shortcut = "ml-auto text-xs tracking-widest text-quaternary";
    public const string SubTrigger = "flex cursor-default select-none items-center gap-2 rounded-sm px-2 py-1.5 text-sm outline-none [&_svg]:size-3.5 [&_svg]:shrink-0 focus:bg-accent focus:text-accent-foreground data-[state=open]:bg-accent data-[state=open]:text-accent-foreground";
    public const string SubContent = "z-50 min-w-[8rem] overflow-hidden rounded-md border border-secondary bg-popover text-popover-foreground shadow-md";
}

public static class Tabs
{
    public const string List = "inline-flex min-h-10 items-center justify-center rounded-md bg-quaternary p-1 gap-1 text-tertiary";
    public const string ListVertical = "flex flex-col h-auto bg-quaternary rounded-md p-1";
    public const string Trigger = $"inline-flex items-center justify-center whitespace-nowrap rounded-sm px-3 py-1.5 text-sm font-medium text-muted-foreground ring-offset-primary transition-all cursor-pointer {State.Focusable} disabled:pointer-events-none disabled:opacity-50 data-[state=active]:bg-brand-solid data-[state=active]:text-primary-foreground data-[state=active]:shadow-sm";
    public const string TriggerDisabled = $"{Trigger} opacity-50 cursor-not-allowed";
    public const string Content = $"mt-2 ring-offset-primary {State.Focusable}";
}

public static class Alert
{
    public const string Base = "relative w-full rounded-lg border border-secondary p-4";
    public const string Title = "block mb-1 font-medium leading-none tracking-tight";
    public const string Description = "block text-sm text-quaternary";

    public static class Variant
    {
        public const string Default = "bg-background text-foreground";
        public const string Danger = "border-error/50 bg-error-primary text-error-primary";
        public const string Success = "border-success/50 bg-success-primary text-success-primary";
        public const string Warning = "border-warning/50 bg-warning-primary text-warning-primary";
        public const string Info = "border-info/50 bg-info-solid/10 text-info-primary";
    }

    public const string Default = $"{Base} {Variant.Default}";
    public const string Danger = $"{Base} {Variant.Danger}";
    public const string Success = $"{Base} {Variant.Success}";
    public const string Warning = $"{Base} {Variant.Warning}";
    public const string Info = $"{Base} {Variant.Info}";
}

public static class Toggle
{
    public const string Base = $"inline-flex items-center justify-center rounded-md text-sm font-medium text-foreground transition-colors cursor-pointer {State.Focusable} disabled:pointer-events-none disabled:opacity-50 data-[state=on]:bg-secondary data-[state=on]:text-secondary-foreground";

    public static class Size
    {
        public const string Sm = "h-9 px-2.5";
        public const string Md = "h-10 px-3";
        public const string Lg = "h-11 px-5";
    }

    public static class Variant
    {
        public const string Default = "border border-secondary bg-transparent hover:bg-secondary-hover";
    }

    public const string DefaultSm = $"{Base} {Size.Sm} {Variant.Default}";
    public const string DefaultMd = $"{Base} {Size.Md} {Variant.Default}";
    public const string DefaultLg = $"{Base} {Size.Lg} {Variant.Default}";
    public const string Default = DefaultMd;
}

public static class Select
{
    public const string TriggerBase = $"flex w-full items-center justify-between rounded-md border border-input bg-background text-foreground placeholder:text-quaternary cursor-pointer {State.Focusable} {State.Disabled}";

    public static class Size
    {
        public const string Sm = "h-8 px-2 text-xs";
        public const string Md = "h-10 px-3 text-sm";
        public const string Lg = "h-12 px-4 text-base";
    }

    public static class Group
    {
        public const string Root = "py-1";
        public const string Label = "px-2 py-1.5 text-xs font-semibold text-quaternary";
    }

    public const string Trigger = $"{TriggerBase} {Size.Md}";
    public const string Content = $"{ZIndex.Popover} max-h-96 min-w-[8rem] overflow-hidden rounded-md border border-secondary bg-popover text-popover-foreground shadow-lg font-sans";
    public const string Item = "relative flex w-full cursor-default select-none items-center rounded-sm py-1.5 pl-8 pr-2 text-sm outline-none focus:bg-accent focus:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50";
    public const string ItemIndicator = "absolute left-2 inset-y-0 flex items-center";
    public const string Label = "py-1.5 pl-8 pr-2 text-sm font-semibold";
    public const string Separator = "h-px bg-quaternary";
    public const string ScrollButton = "flex items-center justify-center py-1 cursor-default text-muted-foreground";
    public const string Default = Trigger;
}

public static class Slider
{
    public const string Root = "relative flex w-full touch-none select-none items-center";
    public const string RootVertical = "relative flex flex-col touch-none select-none items-center";
    public const string Track = "relative h-2 w-full grow overflow-hidden rounded-full bg-quaternary";
    public const string TrackVertical = "relative w-2 h-full grow overflow-hidden rounded-full bg-quaternary";
    public const string Range = "absolute h-full bg-brand-solid";
    public const string Thumb = $"block h-5 w-5 rounded-full border-2 border-brand-solid bg-background shadow-lg transition-colors cursor-grab active:cursor-grabbing {State.Focusable} {State.Disabled}";
    public const string Default = Root;
}

public static class Checkbox
{
    public const string Root = $"peer h-4 w-4 p-0 shrink-0 rounded-sm border border-input bg-background flex items-center justify-center cursor-pointer {State.Focusable} {State.Disabled} data-[state=checked]:border-brand-solid data-[state=checked]:bg-brand-solid data-[state=checked]:text-primary-on-brand data-[state=indeterminate]:border-brand-solid data-[state=indeterminate]:bg-brand-solid data-[state=indeterminate]:text-primary-on-brand";
    public const string Indicator = "flex items-center justify-center text-current h-full w-full [&>*]:size-full";
    public const string Default = Root;
}

public static class Switch
{
    public const string Root = $"peer inline-flex h-5 w-9 shrink-0 cursor-pointer items-center rounded-full border p-0.5 transition-colors {State.Focusable} {State.Disabled} data-[state=checked]:bg-brand-solid data-[state=checked]:border-brand-solid data-[state=unchecked]:bg-quaternary data-[state=unchecked]:border-input";
    public const string Thumb = "pointer-events-none block size-4 rounded-full bg-background shadow-lg transition-transform data-[state=checked]:translate-x-3 data-[state=unchecked]:translate-x-0";
    public const string Default = Root;
}

public static class RadioGroup
{
    public const string Root = "grid gap-2";
    public const string RootHorizontal = "flex flex-row gap-4";
    public const string Item = $"aspect-square h-4 w-4 p-0 rounded-full border border-input bg-background cursor-pointer data-[state=checked]:border-brand-solid data-[state=checked]:bg-brand-solid {State.Focusable} {State.Disabled}";
    public const string Indicator = "hidden";
    public const string Default = Root;
}

public static class Popover
{
    public const string Content = "z-50 w-72 rounded-lg border border-secondary bg-popover p-4 text-popover-foreground shadow-xl font-sans";
    public const string Default = Content;
}

public static class Tooltip
{
    public const string Content = "z-50 rounded-lg border border-secondary bg-popover px-3 py-1.5 text-sm text-popover-foreground shadow-xl font-sans";
    public const string Default = Content;
}

public static class HoverCard
{
    public const string Content = "z-50 w-64 rounded-lg border border-secondary bg-popover p-4 text-popover-foreground shadow-xl font-sans";
    public const string Default = Content;
}

public static class Toast
{
    public const string Viewport = "fixed top-0 left-0 right-0 z-[100] flex max-h-screen flex-col-reverse p-4 sm:left-auto sm:bottom-0 sm:top-auto sm:flex-col sm:max-w-[420px]";
    public const string ViewportBottomCenter = "fixed bottom-4 left-1/2 -translate-x-1/2 z-[100] flex flex-col gap-2 w-full max-w-[420px] p-4";
    public const string Base = "group pointer-events-auto relative flex w-full items-center justify-between space-x-4 overflow-hidden rounded-lg border border-secondary bg-background text-foreground p-6 pr-8 shadow-lg";
    public const string Title = "text-sm font-semibold";
    public const string Description = "text-sm text-quaternary";
    public const string Action = $"{Button.OutlineMd} h-8 px-3";
    public const string Close = "absolute right-2 top-2 rounded-md p-1 text-quaternary hover:text-foreground";
    public const string Default = Base;
}

public static class AlertDialog
{
    public const string Overlay = Dialog.Overlay;
    public const string Content = Dialog.Content;
    public const string Header = Dialog.Header;
    public const string Footer = "mt-6 flex flex-col-reverse gap-2 sm:flex-row sm:justify-end";
    public const string Title = Dialog.Title;
    public const string Description = Dialog.Description;
    public const string Cancel = Button.SecondaryMd;
    public const string Action = Button.Default;
    public const string Default = Content;
}

public static class Accordion
{
    public const string Root = "w-full border-0";
    public const string Item = "border-0 border-b border-secondary";
    public const string Header = "flex m-0 p-0";
    public const string Trigger = $"flex flex-1 w-full items-center justify-between py-4 text-sm font-medium text-foreground transition-all cursor-pointer hover:underline {State.Focusable} [&[data-state=open]>svg]:rotate-180";
    public const string Content = "overflow-hidden text-sm";
    public const string ContentInner = "pb-4 pt-0";
    public const string ChevronIcon = "ml-auto transition-transform duration-200 [&[data-state=open]]:rotate-180";
    public const string Default = Root;
}

public static class Collapsible
{
    public const string Root = "w-full";
    public const string Trigger = "flex items-center justify-between w-full cursor-pointer";
    public const string Content = "overflow-hidden";
    public const string TriggerIcon = "transition-transform duration-200 group-data-[state=open]:rotate-90";
    public const string Default = Root;
}

public static class NavigationMenu
{
    public const string Root = "relative z-10 flex max-w-max flex-1 items-center justify-center";
    public const string List = "group flex flex-1 list-none items-center justify-center gap-1";
    public const string ListVertical = "flex flex-col list-none gap-1";
    public const string Trigger = $"group inline-flex h-10 w-max items-center justify-center rounded-md bg-background text-foreground px-4 py-2 text-sm font-medium transition-colors cursor-pointer hover:bg-accent hover:text-accent-foreground {State.Focusable} {State.Disabled} data-[state=open]:bg-accent data-[state=open]:text-accent-foreground";
    public const string TriggerIcon = "shrink-0 transition-transform [&_svg]:size-3 [&_svg]:shrink-0";
    public const string TriggerIconRotate180 = $"{TriggerIcon} group-data-[state=open]:rotate-180";
    public const string TriggerIconRotate90 = $"{TriggerIcon} group-data-[state=open]:rotate-90";
    public const string Content = "left-0 top-0 w-full text-popover-foreground md:absolute md:w-auto";
    public const string ContentWide = $"{Content} w-[500px]";
    public const string ContentNarrow = $"{Content} w-[400px]";
    public const string ContentPopover = "absolute top-full left-0 p-4 bg-popover border border-secondary rounded-md shadow-lg";
    public const string ContentPopoverSide = "absolute left-full top-0 ml-2 p-2 bg-popover border border-secondary rounded-md shadow-lg";
    public const string Link = "block select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors text-foreground hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground";
    public const string LinkCompact = "block p-2 rounded-md text-foreground hover:bg-tertiary transition-colors";
    public const string Indicator = "top-full z-[1] flex h-1.5 items-end justify-center overflow-hidden";
    public const string Default = Root;
}

public static class Menubar
{
    public const string Root = "flex h-10 items-center space-x-1 rounded-lg border border-secondary bg-background p-1";
    public const string Trigger = "flex cursor-default select-none items-center rounded-sm px-3 py-1.5 text-sm font-medium text-foreground outline-none focus:bg-accent data-[state=open]:bg-accent";
    public const string Content = DropdownMenu.Content;
    public const string Item = DropdownMenu.Item;
    public const string Separator = DropdownMenu.Separator;
    public const string Default = Root;
}

public static class Toolbar
{
    public const string Root = "flex w-full min-w-max rounded-lg border border-secondary bg-background p-1";
    public const string IconStyle = "[&_svg]:size-4 [&_svg]:shrink-0 [&_svg]:translate-y-0.5";
    public const string Button = $"flex-shrink-0 flex-grow-0 basis-auto rounded px-2.5 py-1.5 text-sm text-foreground outline-none hover:bg-accent focus:relative focus:shadow-[0_0_0_2px] focus:shadow-ring {IconStyle}";
    public const string ToggleGroup = "flex items-center gap-1";
    public const string ToggleItem = $"{Toggle.Default} {IconStyle}";
    public const string Separator = "mx-2.5 w-px bg-quaternary";
    public const string Default = Root;
}

public static class Progress
{
    public const string Base = "relative w-full overflow-hidden rounded-full bg-quaternary";

    public static class Size
    {
        public const string Xs = "h-1";
        public const string Sm = "h-2";
        public const string Md = "h-4";
        public const string Lg = "h-6";
    }

    public static class Variant
    {
        public const string Default = "bg-brand-solid";
        public const string Success = "bg-success-solid";
        public const string Warning = "bg-warning-solid";
        public const string Error = "bg-danger";
    }

    public const string Indeterminate = "!w-full relative overflow-hidden before:content-[''] before:absolute before:inset-0 before:bg-[linear-gradient(90deg,transparent,rgba(255,255,255,0.5)_25%,transparent_50%,rgba(255,255,255,0.5)_75%,transparent)] dark:before:bg-[linear-gradient(90deg,transparent,rgba(0,0,0,0.3)_25%,transparent_50%,rgba(0,0,0,0.3)_75%,transparent)] before:w-[200%] before:shimmer:motion-[0:translate-x-[-50%],100:translate-x-[0%]] before:shimmer:motion-duration-1000ms before:shimmer:motion-ease-linear before:shimmer:motion-loop";
    public const string Root = $"{Base} {Size.Md}";
    public const string Indicator = $"h-full w-full flex-1 transition-transform {Variant.Default}";
    public const string Default = Root;

    public static string IndicatorTransform(double value)
        => $"[transform:translateX(-{100 - Math.Clamp(value, 0, 100)}%)]";

    public static string ComposeIndicator(string? variant = null, bool indeterminate = false, params string?[] overrides)
        => Helper.Join("h-full w-full flex-1 transition-transform", variant ?? Variant.Default, indeterminate ? Indeterminate : null, Helper.Join(overrides));
}

public static class Avatar
{
    public const string Base = "relative flex shrink-0 overflow-hidden";

    public static class Size
    {
        public const string Xs = "h-6 w-6";
        public const string Sm = "h-8 w-8";
        public const string Md = "h-10 w-10";
        public const string Lg = "h-12 w-12";
        public const string Xl = "h-16 w-16";
        public const string Xl2 = "h-20 w-20";
    }

    public static class Shape
    {
        public const string Circle = "rounded-full";
        public const string Square = "rounded-md";
    }

    public const string Root = $"{Base} {Size.Md} {Shape.Circle}";
    public const string Image = "aspect-square h-full w-full";
    public const string Fallback = "flex h-full w-full items-center justify-center rounded-[inherit] bg-quaternary text-foreground";
    public const string Default = Root;
}

public static class ScrollArea
{
    public const string Root = "relative overflow-hidden";
    public const string Bordered = "relative overflow-hidden rounded-md border border-secondary";
    public const string Viewport = "h-full w-full rounded-[inherit]";
    public const string Scrollbar = "flex touch-none select-none transition-colors data-[orientation=vertical]:h-full data-[orientation=vertical]:w-2.5 data-[orientation=horizontal]:h-2.5 data-[orientation=horizontal]:flex-col";
    public const string Thumb = "relative flex-1 rounded-full bg-quaternary";
    public const string Default = Root;
}

public static class OtpField
{
    public const string Root = "flex gap-2";
    public const string Input = $"flex h-10 w-10 items-center justify-center rounded-md border border-input bg-background text-foreground text-center text-sm font-medium {State.Focusable} {State.Disabled}";
    public const string Default = Root;
}

public static class Skeleton
{
    public const string Base = "animate-pulse bg-quaternary";

    public static class Shape
    {
        public const string Rectangle = "rounded-md";
        public const string Circle = "rounded-full";
        public const string Square = "rounded-md aspect-square";
    }

    public static class Size
    {
        public const string Xs = "h-2";
        public const string Sm = "h-3";
        public const string Md = "h-4";
        public const string Lg = "h-6";
        public const string Xl = "h-8";
    }

    public const string Default = $"{Base} {Shape.Rectangle}";
    public const string Text = $"{Default} h-4 w-3/4";
    public const string TextSm = $"{Default} h-3 w-1/2";
    public const string TextLg = $"{Default} h-6 w-2/3";
    public const string Avatar = $"{Base} {Shape.Circle} h-12 w-12";
    public const string AvatarSm = $"{Base} {Shape.Circle} h-8 w-8";
    public const string AvatarLg = $"{Base} {Shape.Circle} h-16 w-16";
    public const string Card = $"{Default} h-[200px] w-full rounded-lg";
    public const string Button = $"{Default} h-10 w-24";
    public const string Input = $"{Default} h-10 w-full";
}

public static class Accessibility
{
    public const string ScreenReaderOnly = "sr-only";
    public const string NotScreenReaderOnly = "not-sr-only";
    public const string SkipLink = "absolute left-0 top-0 z-[9999] px-4 py-2 bg-brand-solid text-primary-foreground -translate-y-full focus:translate-y-0 transition-transform";

    public static class Motion
    {
        public const string Safe = "motion-safe:transition-all motion-safe:duration-200";
        public const string Reduce = "motion-reduce:transition-none motion-reduce:animate-none";
        public const string Respectful = $"{Safe} {Reduce}";
        public const string ReduceFade = "motion-reduce:opacity-100 motion-reduce:transform-none";
    }

    public static class Aria
    {
        public const string Expanded = "aria-expanded:rotate-180 transition-transform";
        public const string Selected = "aria-selected:bg-accent aria-selected:text-accent-foreground";
        public const string Checked = "aria-checked:bg-brand-solid aria-checked:text-primary-foreground";
        public const string Disabled = "aria-disabled:opacity-50 aria-disabled:cursor-not-allowed aria-disabled:pointer-events-none";
        public const string Invalid = "aria-[invalid=true]:border-danger aria-[invalid=true]:focus-visible:ring-danger";
        public const string Required = "aria-required:after:content-['*'] aria-required:after:ml-0.5 aria-required:after:text-danger";
        public const string Busy = "aria-busy:opacity-70 aria-busy:cursor-wait";
        public const string CurrentPage = "aria-[current=page]:bg-accent aria-[current=page]:text-accent-foreground aria-[current=page]:font-medium";
        public const string CurrentStep = "aria-[current=step]:bg-brand-solid aria-[current=step]:text-primary-foreground";
    }

    public static class Focus
    {
        public const string HighContrast = "focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary";
        public const string Within = "focus-within:ring-2 focus-within:ring-ring focus-within:ring-offset-2";
        public const string None = "focus:outline-none focus-visible:ring-0";
        public const string Sentinel = "absolute h-px w-px p-0 -m-px overflow-hidden whitespace-nowrap border-0 focus:outline-none";
    }

    public static string RequiredLabel(string baseLabel)
        => $"{baseLabel} after:content-['*'] after:ml-0.5 after:text-danger";
}

public static class Container
{
    public const string Xs = "mx-auto max-w-xs";
    public const string Sm = "mx-auto max-w-sm";
    public const string Md = "mx-auto max-w-md";
    public const string Lg = "mx-auto max-w-lg";
    public const string Xl = "mx-auto max-w-xl";
    public const string Xl2 = "mx-auto max-w-2xl";
    public const string Xl3 = "mx-auto max-w-3xl";
    public const string Xl4 = "mx-auto max-w-4xl";
    public const string Xl5 = "mx-auto max-w-5xl";
    public const string Xl6 = "mx-auto max-w-6xl";
    public const string Xl7 = "mx-auto max-w-7xl";
    public const string Full = "mx-auto max-w-full";
    public const string Prose = "mx-auto max-w-prose";
    public const string Screen = "mx-auto max-w-screen-xl";
}

public static class Panel
{
    public const string Sidebar = "w-1/4 min-w-48 flex-shrink-0";
    public const string SidebarNarrow = "w-1/5 min-w-40 flex-shrink-0";
    public const string Side = "w-1/3 min-w-48 flex-shrink-0";
    public const string Wide = "w-2/5 min-w-64 flex-shrink-0";
    public const string Fill = "flex-1 min-w-0";
}

public static class Breadcrumb
{
    public const string Root = "flex items-center gap-2 text-sm";
    public const string List = "flex items-center gap-2";
    public const string Item = "text-quaternary";
    public const string Link = $"text-foreground hover:text-primary transition-colors cursor-pointer {State.Focusable}";
    public const string Separator = "text-quaternary";
    public const string Page = "font-medium text-foreground";
    public const string Ellipsis = "text-quaternary";
}

public static class FormField
{
    public const string Root = "flex flex-col gap-1.5";
    public const string Label = "text-sm font-medium leading-none";
    public const string LabelRequired = $"{Label} after:content-['*'] after:ml-1 after:text-danger";
    public const string HelpText = "text-xs text-quaternary";
    public const string ErrorText = "block text-xs text-error-primary";
    public const string SuccessText = "block text-xs text-success-primary";
    public const string WarningText = "block text-xs text-warning-primary";
    public const string ParamRow = "flex items-center gap-2 mb-1";
}

public static class Transition
{
    public const string None = "transition-none";
    public const string Fast = "transition-all duration-150 ease-in-out";
    public const string Normal = "transition-all duration-200 ease-in-out";
    public const string Slow = "transition-all duration-300 ease-in-out";
    public const string Slower = "transition-all duration-500 ease-in-out";

    public static class Property
    {
        public const string All = "transition-all duration-200";
        public const string Colors = "transition-colors duration-200";
        public const string Transform = "transition-transform duration-200";
        public const string Opacity = "transition-opacity duration-200";
        public const string Shadow = "transition-shadow duration-200";
    }

    public static class Ease
    {
        public const string Linear = "ease-linear";
        public const string In = "ease-in";
        public const string Out = "ease-out";
        public const string InOut = "ease-in-out";
    }
}

public static class Responsive
{
    public const string HiddenMobile = "hidden sm:block";
    public const string HiddenTablet = "hidden md:block";
    public const string HiddenDesktop = "lg:hidden";
    public const string VisibleMobile = "sm:hidden";
    public const string VisibleTablet = "md:hidden lg:block";
    public const string ColToRow = "flex flex-col sm:flex-row";
    public const string RowToCol = "flex flex-row sm:flex-col";
    public const string ColToRowMd = "flex flex-col md:flex-row";
    public const string CenterToLeft = "text-center sm:text-left";
    public const string LeftToCenter = "text-left sm:text-center";
    public const string CenterToEnd = "justify-center sm:justify-end";
    public const string CenterToStart = "justify-center sm:justify-start";
    public const string CenterToSpaceBetween = "justify-center sm:justify-between";
}

public static class Pagination
{
    public const string Root = "flex items-center justify-center gap-1";
    public const string List = "flex items-center gap-1";
    public const string Item = $"inline-flex items-center justify-center w-10 h-10 rounded-md border border-input text-foreground text-sm font-medium cursor-pointer hover:bg-accent hover:text-accent-foreground {Transition.Property.Colors} {State.Focusable}";
    public const string Active = "inline-flex items-center justify-center w-10 h-10 rounded-md bg-brand-solid text-primary-foreground text-sm font-medium";
    public const string Disabled = "pointer-events-none opacity-50 cursor-not-allowed";
    public const string Ellipsis = "px-2 text-quaternary";
    public const string IconStyle = "[&_svg]:size-4 [&_svg]:shrink-0 [&_svg]:translate-y-0.5";
    public const string Previous = $"{Item} {IconStyle}";
    public const string Next = $"{Item} {IconStyle}";
}

public static class Sheet
{
    public const string Overlay = Surface.Overlay;
    public const string Base = $"fixed {ZIndex.Modal} bg-background text-foreground p-6 shadow-lg transition ease-in-out data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:duration-300 data-[state=open]:duration-500";

    public static class Side
    {
        public const string Top = "inset-x-0 top-0 border-b data-[state=closed]:slide-out-to-top data-[state=open]:slide-in-from-top";
        public const string Bottom = "inset-x-0 bottom-0 border-t data-[state=closed]:slide-out-to-bottom data-[state=open]:slide-in-from-bottom";
        public const string Left = "inset-y-0 left-0 h-full w-3/4 border-r sm:max-w-sm data-[state=closed]:slide-out-to-left data-[state=open]:slide-in-from-left";
        public const string Right = "inset-y-0 right-0 h-full w-3/4 border-l sm:max-w-sm data-[state=closed]:slide-out-to-right data-[state=open]:slide-in-from-right";
    }

    public const string Header = "flex flex-col gap-2 text-center sm:text-left";
    public const string Footer = "flex flex-col-reverse sm:flex-row sm:justify-end sm:gap-2";
    public const string Title = "text-lg font-semibold text-foreground";
    public const string Description = "text-sm text-quaternary";
    public const string CloseButton = $"absolute right-4 top-4 rounded-sm opacity-70 ring-offset-background transition-opacity hover:opacity-100 {State.Focusable}";
    public const string Default = $"{Base} {Side.Right}";
}

public static class Drawer
{
    public const string Overlay = $"fixed inset-0 {ZIndex.Modal} bg-black/80";
    public const string Content = $"fixed inset-x-0 bottom-0 {ZIndex.Modal} mt-24 flex h-auto flex-col rounded-t-[10px] border border-secondary bg-background text-foreground";
    public const string Handle = "mx-auto mt-4 h-2 w-[100px] rounded-full bg-quaternary";
    public const string Header = "grid gap-1.5 p-4 text-center sm:text-left";
    public const string Footer = "mt-auto flex flex-col gap-2 p-4";
    public const string Title = "text-lg font-semibold leading-none tracking-tight";
    public const string Description = "text-sm text-quaternary";

    public static class Snap
    {
        public const string Quarter = "max-h-[25vh]";
        public const string Half = "max-h-[50vh]";
        public const string ThreeQuarter = "max-h-[75vh]";
        public const string Full = "max-h-[calc(100vh-2rem)]";
    }

    public const string Default = Content;
}

public static class Command
{
    public const string Root = "flex h-full w-full flex-col overflow-hidden rounded-md bg-popover text-popover-foreground border border-secondary";
    public const string Dialog = "overflow-hidden p-0 shadow-lg [&_[cmdk-group-heading]]:px-2 [&_[cmdk-group-heading]]:font-medium [&_[cmdk-group-heading]]:text-quaternary [&_[cmdk-group]:not([hidden])_~[cmdk-group]]:pt-0 [&_[cmdk-group]]:px-2 [&_[cmdk-input-wrapper]_svg]:h-5 [&_[cmdk-input-wrapper]_svg]:w-5 [&_[cmdk-input]]:h-12 [&_[cmdk-item]]:px-2 [&_[cmdk-item]]:py-3 [&_[cmdk-item]_svg]:h-5 [&_[cmdk-item]_svg]:w-5";
    public const string InputWrapper = "flex items-center border-b border-secondary px-3";
    public const string Input = "flex h-11 w-full rounded-md bg-transparent py-3 text-sm outline-none placeholder:text-quaternary disabled:cursor-not-allowed disabled:opacity-50";
    public const string List = "max-h-[300px] overflow-y-auto overflow-x-hidden";
    public const string Empty = "py-6 text-center text-sm text-quaternary";
    public const string Group = "overflow-hidden p-1 text-foreground";
    public const string GroupHeading = "px-2 py-1.5 text-xs font-medium text-quaternary";
    public const string Item = "relative flex cursor-default select-none items-center gap-2 rounded-sm px-2 py-1.5 text-sm outline-none [&_svg]:size-3.5 [&_svg]:shrink-0 aria-selected:bg-accent aria-selected:text-accent-foreground data-[disabled]:pointer-events-none data-[disabled]:opacity-50";
    public const string Shortcut = "ml-auto text-xs tracking-widest text-quaternary";
    public const string Separator = "h-px bg-quaternary";
    public const string Default = Root;
}

public static class AspectRatio
{
    public const string Base = "relative w-full overflow-hidden";

    public static class Ratio
    {
        public const string Square = "aspect-square";
        public const string Video = "aspect-video";
        public const string Portrait = "aspect-[3/4]";
        public const string Wide = "aspect-[2/1]";
        public const string Photo = "aspect-[4/3]";
    }

    public const string PlaceholderContent = "bg-quaternary rounded-md w-full h-full flex items-center justify-center";
    public const string Default = $"{Base} {Ratio.Video}";
}

public static class Label
{
    public const string Base = "text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70";
    public const string Required = $"{Base} after:content-['*'] after:ml-0.5 after:text-danger";
    public const string Optional = $"{Base} after:content-['(optional)'] after:ml-1 after:text-quaternary after:text-xs after:font-normal";
    public const string Error = $"{Base} text-danger";
    public const string Default = Base;
}

public static class DragDrop
{
    public static class Item
    {
        public const string Base = "p-3 border border-secondary rounded-md bg-quaternary text-foreground cursor-grab active:cursor-grabbing hover:bg-secondary-hover transition-colors";
        public const string Dashed = "p-4 border-2 border-dashed border-brand-solid rounded-md bg-secondary text-foreground cursor-grab active:cursor-grabbing hover:bg-tertiary transition-colors";
        public const string Dragging = "opacity-50 cursor-grabbing shadow-lg";
        public const string Disabled = "opacity-50 cursor-not-allowed";
        public const string Default = Base;
    }

    public static class Draggable
    {
        public const string Base = "p-4 border border-secondary rounded-md bg-quaternary text-foreground cursor-grab active:cursor-grabbing hover:bg-secondary-hover transition-colors";
        public const string Dashed = "p-4 border-2 border-dashed border-brand-solid rounded-md bg-secondary text-foreground cursor-grab active:cursor-grabbing hover:bg-tertiary transition-colors";
        public const string Disabled = "p-4 border-2 border-dashed border-input rounded-md bg-muted text-muted-foreground opacity-50 cursor-not-allowed";
        public const string Default = Base;
    }

    public static class Droppable
    {
        public const string Base = "p-8 border-2 border-dashed rounded-md min-h-[100px] flex items-center justify-center transition-colors";
        public const string Default = $"{Base} border-secondary bg-muted text-foreground";
        public const string Success = $"{Base} border-success bg-success-primary text-success-primary";
        public const string Info = $"{Base} border-info bg-info-solid/10 text-info-primary";
        public const string Disabled = $"{Base} border-input bg-muted text-muted-foreground opacity-50";
    }

    public const string Container = "flex flex-col gap-2";
    public const string ContainerHorizontal = "flex flex-row gap-2 flex-wrap";
    public const string Overlay = "bg-popover text-popover-foreground border border-secondary rounded-md shadow-xl p-3 cursor-grabbing";
    public const string OverlayContent = "p-4 border-2 border-brand-solid rounded-md bg-brand-solid/20 text-foreground shadow-lg";
    public const string DropZone = "border-2 border-dashed border-secondary bg-muted text-foreground rounded-lg p-4 transition-colors";
    public const string DropZoneActive = "border-brand-solid bg-brand-solid/10";
}

public static class FileUpload
{
    public static class Zone
    {
        public const string Base = "border-2 border-dashed border-secondary bg-muted text-foreground rounded-lg p-8 text-center cursor-pointer hover:border-tertiary transition-colors";
        public const string Compact = "border-2 border-dashed border-secondary bg-muted text-foreground rounded-lg p-4 text-center cursor-pointer hover:border-tertiary transition-colors";
        public const string Active = "border-brand-solid bg-brand-solid/10";
        public const string ActiveRing = "ring-2 ring-brand-solid ring-offset-2 ring-offset-background";
        public const string Disabled = "opacity-50 cursor-not-allowed hover:border-secondary";
        public const string Wrapper = "relative";
        public const string DragOverlay = "absolute inset-0 bg-brand-solid/10 border-2 border-dashed border-brand-solid rounded-md flex items-center justify-center pointer-events-none z-10";
        public const string Default = Base;

        public const string Images = "border-2 border-dashed border-success bg-success-primary text-success-primary rounded-lg p-4 text-center cursor-pointer hover:border-success-solid transition-colors";
        public const string Documents = "border-2 border-dashed border-error bg-error-primary text-error-primary rounded-lg p-4 text-center cursor-pointer hover:border-error-solid transition-colors";
        public const string Code = "border-2 border-dashed border-brand bg-brand-primary-alt text-brand-primary rounded-lg p-4 text-center cursor-pointer hover:border-brand-solid transition-colors";
    }

    public static class Icon
    {
        public const string Base = "w-8 h-8 mx-auto text-quaternary";
        public const string Success = "w-8 h-8 mx-auto text-success-primary";
        public const string Error = "w-8 h-8 mx-auto text-error-primary";
        public const string Brand = "w-8 h-8 mx-auto text-brand-primary";
        public const string Info = "w-8 h-8 mx-auto text-info-primary";
        public const string Disabled = "w-8 h-8 mx-auto text-muted-foreground";
    }

    public const string FileList = "flex flex-col gap-2 mt-4";
    public const string FileItem = "flex items-center gap-3 p-3 rounded-md border border-secondary bg-quaternary text-foreground";
    public const string FileName = "flex-1 text-sm truncate";
    public const string FileSize = "text-xs text-quaternary";
    public const string RemoveButton = "p-1 rounded hover:bg-tertiary text-quaternary hover:text-foreground transition-colors";
    public const string TypeIcon = "w-8 h-8 mx-auto";
}

public static class Media
{
    public const string VideoContainer = "w-full aspect-video rounded-lg overflow-hidden bg-black flex items-center justify-center";
    public const string EmptyState = "w-full aspect-video rounded-lg bg-quaternary text-foreground flex items-center justify-center";
    public const string ImageEmptyState = "w-full h-64 rounded-lg bg-quaternary text-foreground flex items-center justify-center";
    public const string PlaceholderIcon = "w-12 h-12 text-quaternary";
    public const string PlaceholderText = "text-quaternary";
    public const string PlaceholderHint = $"{Text.Caption} text-quaternary";
    public const string Fill = "w-full h-full object-contain";
    public const string CanvasFill = "block max-w-full max-h-full";
    public const string Mirror = "-scale-x-100";
    public const string Default = VideoContainer;
}

public static class ContentGrid
{
    public const string Default = "grid gap-px";
    public const string Bordered = "grid gap-px rounded-lg border border-secondary overflow-hidden";
    public const string Header = "bg-muted/50 text-muted-foreground text-xs font-medium uppercase tracking-wider px-4 py-2.5";
    public const string Cell = "px-4 py-2.5 text-sm";
    public const string CellMuted = "px-4 py-2.5 text-sm text-muted-foreground";
}

public static class DataTable
{
    public const string Default = "rounded-lg border border-secondary bg-card text-card-foreground shadow-sm overflow-hidden";
    public const string Header = "bg-muted/50 text-muted-foreground text-xs font-medium uppercase tracking-wider";
    public const string Row = "border-b border-secondary/20 hover:bg-muted/30 transition-colors";
    public const string RowClickable = "border-b border-secondary/20 hover:bg-muted/30 transition-colors cursor-pointer";
    public const string Cell = "px-4 py-3 text-sm";
    public const string HeaderCell = "px-4 py-3";
    public const string DataCell = "overflow-hidden text-ellipsis whitespace-nowrap";
    public const string Pagination = "flex items-center justify-between px-4 py-3 border-t border-secondary/20 text-sm text-muted-foreground";
    public const string PaginationButton = "px-2 py-1 rounded text-sm bg-transparent border-0 cursor-pointer text-inherit disabled:opacity-50 disabled:cursor-default hover:bg-muted/30";
    public const string PageNumber = "px-2 py-1 rounded text-sm bg-transparent border-0 cursor-pointer text-inherit min-w-[2rem]";
    public const string PageNumberActive = "px-2 py-1 rounded text-sm border-0 cursor-pointer min-w-[2rem] bg-brand-solid text-primary-foreground font-semibold";
    public const string EmptyState = "flex flex-col items-center justify-center py-12 text-muted-foreground";
}

public static class Chart
{
    public const string Container = "w-full h-full";
    public const string ContainerSm = "w-full h-48";
    public const string ContainerMd = "w-full h-64";
    public const string ContainerLg = "w-full h-80";
    public const string ContainerXl = "w-full h-96";
    public const string Default = Container;
}
