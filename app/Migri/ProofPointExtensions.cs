using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public static class ProofPointExtensions
{
    public static void ProofPoint(
        this UIView view,
        string? pdfUrl = null,
        string? pdfData = null,
        string? searchText = null,
        Func<string, Task>? onSearchContent = null,
        string[]? style = null,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        string? onSearchContentActionId = null;

        if (onSearchContent != null)
        {
            onSearchContentActionId = view.CreateAction<string>(args => onSearchContent(args.Value));
        }

        view.AddNode(
            "proof-point",
            new Dictionary<string, object?>
            {
                ["pdfUrl"] = pdfUrl,
                ["pdfData"] = pdfData,
                ["searchText"] = searchText,
                ["onSearchContent"] = onSearchContentActionId
            },
            style: style,
            file: file,
            line: line);
    }
}
