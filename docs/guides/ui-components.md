# UI Components

## UI Components

All UI components are called as methods on `UIView` (the `view` parameter in content lambdas). Never reference the `UIView` type directly — just use the `view` parameter provided by content lambdas. There is no `IView` interface. Style is always the first parameter, using an array of theme constants and/or Crosswind classes.

### Layout

```csharp
view.Box([Card.Default, "p-6"], content: view => { ... });
view.Row([Layout.Row.Md, "flex-wrap"], content: view => { ... });
view.Column([Layout.Column.Lg], content: view => { ... });
view.Flex(["flex gap-4"], content: view => { ... });
view.ScrollArea(rootStyle: ["h-[400px]"], content: view => { ... });
view.Separator(["my-4"]);
view.AspectRatio(["w-full"], ratio: 16.0 / 9.0, content: view => { ... });

// Complete chat interface pattern:
view.Column(["h-screen"], content: view =>
{
    // Header
    view.Text([Text.H2, "p-4 flex-shrink-0"], "Chat");

    // Scrollable message area with auto-scroll
    view.ScrollArea(
        autoScroll: true,
        autoScrollKey: _messages.Value.Count.ToString(),
        rootStyle: ["flex-1 min-h-0 px-4"],
        content: view =>
        {
            foreach (var msg in _messages.Value)
            {
                view.Box(["py-2"], content: view =>
                {
                    view.Text([Text.Caption, "text-muted-foreground"], msg.Author);
                    view.Text([Text.Body], msg.Text);
                });
            }
        });

    // Input area — Enter submits, auto-clears
    view.Row(["p-4 gap-2 flex-shrink-0"], content: view =>
    {
        view.TextField([Input.Default, "flex-1"],
            placeholder: "Type a message...",
            value: _input.Value,
            onValueChange: async v => _input.Value = v,
            onSubmit: async _ =>
            {
                if (!string.IsNullOrWhiteSpace(_input.Value))
                {
                    _messages.Value.Add(new Message("User", _input.Value));
                    _messages.NotifyUpdate();
                }
            },
            clearOnSubmit: true);
    });
});
```

### Text & Content

```csharp
view.Text([Text.Display], "Large Title");
view.Text([Text.H2], "Section Heading");
view.Text([Text.Body], "Body text");
view.Text([Text.Caption, "text-muted-foreground"], "Small caption");
view.Heading([Text.H3], "Heading component");
view.Markdown(content: "**Bold** and `code`");
```

### Input

```csharp
view.Button([Button.PrimaryMd], label: "Click", onClick: async () => { ... });
view.Button([Button.OutlineMd], label: "Secondary", disabled: isLoading, onClick: async () => { ... });
view.Button([Button.GhostMd, Button.Size.Icon], onClick: async () => { ... },
    content: v => v.Icon([Icon.Default], name: "settings"));
view.TextField([Input.Default], placeholder: "Enter text", value: _text.Value,
    onValueChange: async v => _text.Value = v,
    onSubmit: async _ => { await HandleSubmit(); });  // Enter submits; input auto-clears after submit
view.TextArea([Input.Default, "min-h-[100px]"], placeholder: "Type a message...", value: _text.Value,
    onValueChange: async v => _text.Value = v,
    onSubmit: async _ => { await HandleSubmit(); });  // Ctrl+Enter submits; input auto-clears after submit
// Note: clearOnSubmit defaults to true when onSubmit is set. Pass clearOnSubmit: false to keep the value.
view.Checkbox([Checkbox.Default], checked: _checked.Value,
    onCheckedChange: async v => _checked.Value = v ?? false);
view.Switch([Switch.Default], checked: _enabled.Value,
    onCheckedChange: async v => _enabled.Value = v ?? false);
view.Slider([Slider.Default], value: [_slider.Value], min: 0, max: 100, step: 1,
    onValueChange: async values => _slider.Value = values[0],
    content: view =>
    {
        view.SliderTrack([Slider.Track], content: view => { view.SliderRange([Slider.Range]); });
        view.SliderThumb([Slider.Thumb]);
    });
view.Select([Select.Trigger], value: _selected.Value, placeholder: "Choose...",
    onValueChange: async v => _selected.Value = v ?? "",
    content: view =>
    {
        view.SelectContent([Select.Content], content: view =>
        {
            view.SelectItem([Select.Item], value: "a", label: "Option A");
            view.SelectItem([Select.Item], value: "b", label: "Option B");
        });
    });
view.RadioGroup(value: _radio.Value, onValueChange: async v => _radio.Value = v ?? "",
    content: view =>
    {
        view.RadioGroupItem([RadioGroup.Item], value: "opt1", label: "Option 1");
        view.RadioGroupItem([RadioGroup.Item], value: "opt2", label: "Option 2");
    });
view.FileUpload(
    onUploadComplete: async args => { /* args.UploadId, args.FileName, args.MimeType, args.Size, args.LocalTempFilePath, args.AssetUri */ },
    onUploadProgress: async args => { /* args.ProgressPercentage (0-100), args.BytesUploaded, args.Size */ },
    accept: [".jpg", ".png", ".pdf"],  // optional file type filter
    maxFileSize: 10 * 1024 * 1024);    // optional max size in bytes

// FileUploadZone wraps any content with drag-drop + paste upload capability
view.FileUploadZone(
    accept: ["video/*"],
    onUploadComplete: async args => { /* args.FileName, args.MimeType, args.Size, args.LocalTempFilePath, args.AssetUri */ },
    onUploadProgress: async args => { /* args.ProgressPercentage, args.BytesUploaded */ },
    onDragActiveChange: async isDragging => { _isDragging.Value = isDragging; },
    zoneStyle: [FileUpload.Zone.Base],
    activeStyle: [FileUpload.Zone.Active],
    content: v => v.Text([Text.Caption], "Drop files here"));
```

### Display

```csharp
view.Icon([Icon.Default], name: "check");          // Lucide icon names
view.Box([Icon.Spinner, "w-4 h-4"]);              // CSS-only spinning loader (use Box, not Icon)
view.Icon([Icon.Spinner], name: "loader-2");       // Spinning icon (spinner animation + Lucide icon)
view.Image(["max-w-full h-auto"], src: imageUrl);   // From URL
view.Image(["rounded-lg"], data: bytes, mimeType: MimeTypes.ImageJpeg);  // From bytes
```

### Overlays

```csharp
// Dialog
view.Dialog(open: _open.Value, onOpenChange: async o => _open.Value = o ?? false,
    overlayStyle: [Dialog.Overlay], contentStyle: [Dialog.Content],
    trigger: view => view.Button([Button.OutlineMd], label: "Open"),
    content: view =>
    {
        view.Box([Dialog.Header], content: view =>
        {
            view.Text([Dialog.Title], "Title");
            view.Text([Dialog.Description], "Description");
        });
        view.Text([Text.Body, "my-4"], "Content");
        view.Box([Dialog.Footer], content: view =>
        {
            view.Button([Button.OutlineMd], label: "Cancel", onClick: async () => _open.Value = false);
            view.Button([Button.PrimaryMd], label: "Confirm", onClick: async () => _open.Value = false);
        });
    });

// AlertDialog
view.AlertDialog(open: _alertOpen.Value, onOpenChange: async o => _alertOpen.Value = o ?? false,
    overlayStyle: [AlertDialog.Overlay], contentStyle: [AlertDialog.Content],
    trigger: view => view.Button([Button.DangerMd], label: "Delete"),
    title: "Are you sure?", titleStyle: [AlertDialog.Title],
    description: "This action cannot be undone.", descriptionStyle: [AlertDialog.Description],
    footerStyle: [AlertDialog.Footer], cancelLabel: "Cancel", cancelStyle: [AlertDialog.Cancel],
    actionLabel: "Delete", actionStyle: [Button.DangerMd]);

// Popover, Tooltip, HoverCard
view.Popover(open: _popOpen.Value, onOpenChange: async o => _popOpen.Value = o ?? false,
    contentStyle: [Popover.Content],
    trigger: view => view.Button([Button.OutlineMd], label: "Open"),
    content: view => { ... });
view.Tooltip(contentStyle: [Tooltip.Content],
    trigger: view => view.Button([Button.OutlineMd], label: "Hover me"),
    content: view => view.Text(text: "Tooltip text"));
view.HoverCard(contentStyle: [HoverCard.Content],
    trigger: view => view.Text([Text.Link], "@user"),
    contentSlot: view => { ... });

// Toast
view.Toast(open: _toastOpen.Value, onOpenChange: async o => _toastOpen.Value = o ?? false,
    viewportStyle: [Toast.ViewportBottomCenter], toastStyle: [Toast.Base],
    title: "Success", titleStyle: [Toast.Title],
    description: "Action completed", descriptionStyle: [Toast.Description],
    durationMs: 3000, showClose: true, closeStyle: [Toast.Close]);
```

### Navigation & Data

```csharp
// Tabs with routing
view.Tabs(value: _tab.Value, onValueChange: async v =>
    {
        _tab.Value = v ?? "home";
        await app.Navigation.SetPathAsync($"/{v}");
    },
    listContainerStyle: [Card.Default, "p-2 mb-4"],
    listStyle: [Tabs.List], triggerStyle: [Tabs.Trigger], contentStyle: [Tabs.Content],
    tabs: [
        new TabItem("home", "Home", RenderHome),
        new TabItem("settings", "Settings", RenderSettings),
    ]);

// Accordion
view.Accordion(value: _accordionValue.Value,
    onValueChange: async v => _accordionValue.Value = v ?? "",
    content: view =>
    {
        view.AccordionItem(value: "item1", triggerLabel: "Section 1",
            content: view => view.Text(text: "Content 1"));
    });

// Collapsible
view.Collapsible(open: _open.Value, onOpenChange: async o => _open.Value = o ?? false,
    trigger: view => view.Button(label: "Toggle"),
    content: view => { ... });

// InfiniteScrollView
view.InfiniteScrollView(["h-[400px]"],
    hasMore: _hasMore.Value,
    isLoading: _loading.Value,
    onLoadMore: async () => { await LoadMoreItems(); },
    content: view => { foreach (var item in _items.Value) { view.Text(text: item); } });
```

### Interactive

```csharp
// KeyboardListener
view.KeyboardListener(global: true,
    onKeyDown: async args => { /* args.Key, args.ShiftKey, args.CtrlKey */ },
    content: view => { ... });
```

### Drag and Drop

**Sortable List** — simplest case, reorder items within a single list:

```csharp
view.SortableList(
    items: _items.Value,
    onReorder: async args => _items.Value = args.NewOrder.ToList(),
    itemContent: (v, id) => v.Text([Text.Body], id));
```

**Cross-Container DnD (Kanban pattern):**

```csharp
// Reactive state for drag tracking (lightweight, only IDs)
private readonly Reactive<string?> _activeDragId = new(null);
private readonly Reactive<string?> _dragOverColumnId = new(null);

// DndContext wraps the entire drag area
view.DndContext(
    collisionDetection: CollisionDetection.RectIntersection,
    onDragStart: async args => { _activeDragId.Value = args.ActiveId; },
    onDragOver: async args => { _dragOverColumnId.Value = args.OverId; },
    onDragEnd: async args =>
    {
        _activeDragId.Value = null;
        _dragOverColumnId.Value = null;
        if (args.OverId != null) { await HandleDrop(args.ActiveId, args.OverId); }
    },
    onDragCancel: async () => { _activeDragId.Value = null; _dragOverColumnId.Value = null; },
    content: view =>
    {
        // Each column is a Droppable
        view.Droppable(["min-h-[100px]"], id: "column-1", content: v =>
        {
            foreach (var item in GetColumnItems("column-1"))
            {
                // Each card is a Draggable with hideOnDrag
                v.Draggable(["p-2 cursor-grab"], id: item.Id, hideOnDrag: true,
                    content: card => card.Text(text: item.Title));
            }
        });

        // DragOverlay renders the floating drag preview
        view.DragOverlay(["shadow-lg opacity-90"], dropAnimation: true,
            activeDragId: _activeDragId.Value,
            content: v =>
            {
                if (_activeDragId.Value != null) { v.Text(text: GetItem(_activeDragId.Value).Title); }
            });
    });
```

**Key rules:**
- Use `hideOnDrag: true` on Draggable when using DragOverlay (hides original during drag)
- Use `dropAnimation: true` on DragOverlay (animates to drop target, flies back on cancel)
- Use `activeDragId: _activeDragId.Value` on DragOverlay to prevent stale content from previous drag showing briefly
- Use `CollisionDetection.RectIntersection` for multi-column layouts
- Only mutate data in `onDragEnd` — `onDragStart`/`onDragOver` should only set lightweight tracking state
- Guard `onDragEnd`: `OverId` may be a Draggable id (another card) instead of a Droppable (column)
- Show optimistic preview by filtering rendered lists based on `_activeDragId`/`_dragOverColumnId` (no actual data mutation until drop)

### ActionButton & CaptureButton

ActionButton triggers client-side actions that require user gesture:

```csharp
view.ActionButton([Button.PrimaryMd],
    action: ActionKind.CopyToClipboard,
    options: new CopyToClipboardActionOptions { Text = "Copied text!" },
    onActionComplete: async e => { /* e.Success */ },
    content: v => { v.Icon([Icon.Default, "mr-2"], name: "clipboard-copy"); v.Text(text: "Copy"); });
```

Available ActionKinds: `CaptureImage`, `CopyToClipboard`, `DownloadFile`, `ExitFullscreen`, `GetLocation`, `PickContacts`, `RequestFullscreen`, `Share`, `ShowNotification`

CaptureButton starts audio/video capture from the client:

```csharp
view.CaptureButton([Button.OutlineMd, Button.Size.Icon],
    kind: MediaCaptureKind.Audio,
    captureMode: MediaCaptureButtonMode.Toggle,  // or Hold
    audioOptions: new ClientAudioCaptureOptions { ... },
    onCaptureStart: async args => { _streamId.Value = args.StreamId; },
    onCaptureStop: async args => { _streamId.Value = null; },
    content: v => v.Icon([Icon.Default], name: "mic"));
```
