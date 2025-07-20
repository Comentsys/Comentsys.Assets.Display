namespace Comentsys.Assets.Display.Tests;

[TestClass]
public class DisplayTests
{
    /// <summary>
    /// Values
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> Values() => 
        Enum.GetValues<Value>().Select(value => new object[] { value });

    /// <summary>
    /// Multiple
    /// </summary>
    public static readonly Color[] Multiple = 
    [
        Color.Red,
        Color.Orange,
        Color.Yellow,
        Color.Green,
        Color.Blue,
        Color.Indigo,
        Color.Violet,
        Color.Pink,
        Color.Turquoise,
        Color.Brown,
        Color.Gray,
        Color.Black,
        Color.WhiteSmoke,
        Color.Cyan,
        Color.Magenta,
        Color.Lime,
        Color.Maroon,
        Color.Navy,
        Color.Olive,
        Color.Teal
    ];

    /// <summary>
    /// Single Colour
    /// </summary>
    public static readonly Color Single = Color.FromArgb(255, 33, 33, 33);

    /// <summary>
    /// Output
    /// </summary>
    /// <param name="value">Test Value</param>
    /// <param name="display">Display Type</param>
    /// <param name="test">Test Type</param>
    /// <param name="output">Display Output</param>
    private static void Output(Value value, string display, string test, string? output)
    {
        Directory.CreateDirectory($@"C:\\Test\\Display\\{display}\\{test}\\");
        File.WriteAllText($@"C:\\Test\\Display\\{display}\\{test}\\{value}.svg", output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Segment_Colours_Test(Value value)
    {        
        var output = Segment.Get(value, Multiple).ToSvgString();
        Output(value, nameof(Segment), nameof(Multiple), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Square_Colours_Test(Value value)
    {
        var output = Matrix.Get(value, Multiple, Style.Square).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Square}", nameof(Multiple), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Circle_Colours_Test(Value value)
    {
        var output = Matrix.Get(value, Multiple, Style.Circle).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Circle}", nameof(Multiple), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Hexagon_Colours_Test(Value value)
    {
        var output = Matrix.Get(value, Multiple, Style.Hexagon).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Hexagon}", nameof(Multiple), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Octagon_Colours_Test(Value value)
    {
        var output = Matrix.Get(value, Multiple, Style.Octagon).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Octagon}", nameof(Multiple), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Segment_Normal_Test(Value value)
    {
        var output = Segment.Get(value, Single).ToSvgString();
        Output(value, nameof(Segment), nameof(Single), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Square_Normal_Test(Value value)
    {
        var output = Matrix.Get(value, Single, Style.Square).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Square}", nameof(Single), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Circle_Normal_Test(Value value)
    {
        var output = Matrix.Get(value, [Single], Style.Circle).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Circle}", nameof(Single), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Hexagon_Normal_Test(Value value)
    {
        var output = Matrix.Get(value, Single, Style.Hexagon).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Hexagon}", nameof(Single), output);
    }

    [DataTestMethod]
    [DynamicData(nameof(Values), DynamicDataSourceType.Method)]
    public void Matrix_Octagon_Normal_Test(Value value)
    {
        var output = Matrix.Get(value, Single, Style.Octagon).ToSvgString();
        Output(value, $"{nameof(Matrix)}_{Style.Octagon}", nameof(Single), output);
    }
}