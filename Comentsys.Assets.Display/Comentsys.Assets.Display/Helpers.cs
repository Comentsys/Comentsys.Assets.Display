namespace Comentsys.Assets.Display;

/// <summary>
/// Helpers
/// </summary>
internal static class Helpers
{
    private const string asset_svg_tag = "svg";
    private const string asset_svg_name_space = "http://www.w3.org/2000/svg";
    private const string asset_svg_path_fill = "//svg:path[@id='{0}']/@fill";

    /// <summary>
    /// Path
    /// </summary>
    /// <param name="asset">Asset</param>
    /// <param name="value">Value</param>
    /// <returns>Asset Path</returns>
    internal static string Path(string asset, Value value) =>
        $"{asset}.{Enum.GetName(typeof(Value), value) ?? string.Empty}";

    /// <summary>
    /// Get Value
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Value</returns>
    internal static Value GetValue(int value) =>
        Enum.IsDefined(typeof(Value), value) ? (Value)value : Value.Blank;

    /// <summary>
    /// Pad 
    /// </summary>
    /// <param name="source">Source Colours</param>
    /// <param name="pad">Pad Colour</param>
    /// <param name="total">Total Colours</param>
    /// <returns>Padded Colours</returns>
    internal static Color[] Pad(Color[]? source, Color pad, int total)
    {
        source ??= [];
        var result = new Color[total];
        if(source?.Length < total)
        {
            for (int i = 0; i < source.Length; i++)
                result[i] = source[i];
            for (int i = source.Length; i < total; i++)
                result[i] = pad;
        }
        else
            Array.Copy(source, result, total);
        return result;
    }

    /// <summary>
    /// Get SVG Document
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="manager">XML Namespace Manager</param>
    /// <returns>XML Document</returns>
    internal static XmlDocument GetSvgDocument(string? content, out XmlNamespaceManager manager)
    {
        var svg = new XmlDocument();
        svg.LoadXml(content);
        var navigator = svg.CreateNavigator();
        manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace(asset_svg_tag, asset_svg_name_space);
        return svg;
    }

    /// <summary>
    /// Get SVG Node
    /// </summary>
    /// <param name="svg">SVG Document</param>
    /// <param name="id">Id</param>
    /// <param name="manager">XML Namespace Manager</param>
    /// <returns>XML Node</returns>
    internal static XmlNode GetSvgNode(XmlDocument svg, string id, XmlNamespaceManager manager) => 
        svg.SelectSingleNode(string.Format(asset_svg_path_fill, id), manager);
}
