namespace Comentsys.Assets.Display;

/// <summary>
/// Segment Display representing a Seven-Segment Display
/// </summary>
public class Segment : AssetBase<Segment>
{
    private const int width = 87;
    private const int height = 155;
    private const string none = "none";
    private const string asset = "Segment";
    private const string root = "Comentsys.Assets.Display.Resources";
    private static readonly Color source = Color.FromArgb(255, 33, 33, 33);
    private static readonly byte[][] layout =
    {
        // a, b, c, d, e, f, g, h, i
        [1, 1, 1, 1, 1, 1, 0, 0, 0], // 0
        [0, 1, 1, 0, 0, 0, 0, 0, 0], // 1
        [1, 1, 0, 1, 1, 0, 1, 0, 0], // 2
        [1, 1, 1, 1, 0, 0, 1, 0, 0], // 3
        [0, 1, 1, 0, 0, 1, 1, 0, 0], // 4
        [1, 0, 1, 1, 0, 1, 1, 0, 0], // 5
        [1, 0, 1, 1, 1, 1, 1, 0, 0], // 6
        [1, 1, 1, 0, 0, 0, 0, 0, 0], // 7
        [1, 1, 1, 1, 1, 1, 1, 0, 0], // 8
        [1, 1, 1, 0, 0, 1, 1, 0, 0], // 9
        [0, 0, 0, 0, 0, 0, 1, 0, 0], // 10 (Dash)
        [0, 0, 0, 0, 0, 0, 0, 1, 1], // 11 (Colon)
        [0, 0, 0, 0, 0, 0, 0, 0, 0], // 12 (Blank)
        [1, 1, 1, 1, 1, 1, 1, 1, 1], // 13 (Filled)
    };
    private static readonly char[] ids = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'];

    /// <summary>
    /// Get Asset Resource String
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colours</param>
    /// <returns>Asset Resource String</returns>
    private static string GetAssetResourceString(Value value, Color[]? fill = null)
    {
        var segments = layout[(int)value];
        var content = AsString(root, Helpers.Path(asset, Value.Filled));
        var svg = Helpers.GetSvgDocument(content, out XmlNamespaceManager manager);
        var colours = Helpers.Pad(fill, source, ids.Length);
        for (var index = 0; index < segments.Length; index++)
        {
            var id = ids[index].ToString();
            var node = Helpers.GetSvgNode(svg, id, manager);
            node.Value = segments[index] == 1 ? 
                AsString(node.Value, source, colours[index]) : 
                none;
        }
        return svg.OuterXml;
    }

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(Value value) =>
        new(AsStream(root, Helpers.Path(asset, value)) ??
            new MemoryStream(), height, width);

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colour</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(Value value, Color? fill) =>
        new(AsStream(root, Helpers.Path(asset, value), source, fill) ??
            new MemoryStream(), height, width);

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colours</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(Value value, Color[]? fill) =>
        new(FromString(GetAssetResourceString(value, fill)) ??
            new MemoryStream(), height, width);

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(int value) =>
        Get(Helpers.GetValue(value));

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colour</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(int value, Color? fill) =>
        Get(Helpers.GetValue(value), fill);

    /// <summary>
    /// Get Asset Resource
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colours</param>
    /// <returns>Asset Resource</returns>
    public static AssetResource Get(int value, Color[]? fill) =>
        Get(Helpers.GetValue(value), fill);
}
