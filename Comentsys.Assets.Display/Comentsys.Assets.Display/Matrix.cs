namespace Comentsys.Assets.Display;

/// <summary>
/// Matrix Display representing a Five-by-Seven Dot Matrix Display
/// </summary>
public class Matrix : AssetBase<Matrix>
{
    private const int rows = 7;
    private const int cols = 5;
    private const int width = 87;
    private const int height = 121;
    private const string none = "none";
    private const string asset = "Matrix";
    private const string format = "r{0}-c{1}";
    private const string root = "Comentsys.Assets.Display.Resources";
    private static readonly Color source = Color.FromArgb(255, 33, 33, 33);
    private static readonly byte[][] layout =
    [
        [
            // Zero
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            1, 0, 0, 1, 1,
            1, 0, 1, 0, 1,
            1, 1, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // One
            0, 0, 1, 0, 0,
            0, 1, 1, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0,
            1, 1, 1, 1, 1
        ],
        [
            // Two
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            0, 0, 0, 0, 1,
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            1, 1, 1, 1, 1
        ],
        [
            // Three
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            0, 0, 0, 0, 1,
            0, 1, 1, 1, 0,
            0, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // Four
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 1,
            0, 0, 0, 0, 1,
            0, 0, 0, 0, 1,
            0, 0, 0, 0, 1
        ],
        [
            // Five
            1, 1, 1, 1, 1,
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            1, 1, 1, 1, 0,
            0, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // Six
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            1, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // Seven
            1, 1, 1, 1, 1,
            0, 0, 0, 0, 1,
            0, 0, 0, 0, 1,
            0, 0, 0, 1, 0,
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 1, 0, 0
        ],
        [
            // Eight
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // Nine
            0, 1, 1, 1, 0,
            1, 0, 0, 0, 1,
            1, 0, 0, 0, 1,
            0, 1, 1, 1, 1,
            0, 0, 0, 0, 1,
            0, 0, 0, 0, 1,
            0, 1, 1, 1, 0
        ],
        [
            // Dash
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 1, 1, 1, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        [
            // Colon
            0, 0, 0, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 1, 0, 0,
            0, 0, 0, 0, 0
        ],
        [
            // Blank
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0
        ],
        [
            // Filled
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1
        ]
    ];

    /// <summary>
    /// Get Asset Resource String
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="fill">Fill Colours</param>
    /// <returns>Asset Resource String</returns>
    private static string GetAssetResourceString(Value value, Color[]? fill = null)
    {
        var index = 0;
        var matrix = layout[(int)value];
        var content = AsString(root, Helpers.Path(asset, Value.Filled));
        var svg = Helpers.GetSvgDocument(content, out XmlNamespaceManager manager);
        var colours = Helpers.Pad(fill, source, matrix.Length);        
        for(var row = 0; row < rows; row++)
        {
            for(var col = 0; col < cols; col++)
            {
                var id = string.Format(format, row + 1, col + 1);
                var node = Helpers.GetSvgNode(svg, id, manager);
                node.Value = matrix[index] == 1 ? 
                    AsString(node.Value, source, colours[index]) : 
                    none;
                index++;
            }
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
