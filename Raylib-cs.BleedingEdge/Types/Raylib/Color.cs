using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Color, 4 components, R8G8B8A8 (32bit)
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Color(byte r, byte g, byte b, byte a = 255) : IEquatable<Color>
{
    // Some Basic Colors
    // NOTE: Custom raylib color palette for amazing visuals on WHITE background

    /// <summary>
    /// Light Gray
    /// </summary>
    public static readonly Color LightGray = new(200, 200, 200);

    /// <summary>
    /// Gray
    /// </summary>
    public static readonly Color Gray = new(130, 130, 130);

    /// <summary>
    /// Dark Gray
    /// </summary>
    public static readonly Color DarkGray = new(80, 80, 80);

    /// <summary>
    /// Yellow
    /// </summary>
    public static readonly Color Yellow = new(253, 249, 0);

    /// <summary>
    /// Gold
    /// </summary>
    public static readonly Color Gold = new(255, 203, 0);

    /// <summary>
    /// Orange
    /// </summary>
    public static readonly Color Orange = new(255, 161, 0);

    /// <summary>
    /// Pink
    /// </summary>
    public static readonly Color Pink = new(255, 109, 194);

    /// <summary>
    /// Red
    /// </summary>
    public static readonly Color Red = new(230, 41, 55);

    /// <summary>
    /// Maroon
    /// </summary>
    public static readonly Color Maroon = new(190, 33, 55);

    /// <summary>
    /// Green
    /// </summary>
    public static readonly Color Green = new(0, 228, 48);

    /// <summary>
    /// Lime
    /// </summary>
    public static readonly Color Lime = new(0, 158, 47);

    /// <summary>
    /// Dark Green
    /// </summary>
    public static readonly Color DarkGreen = new(0, 117, 44);

    /// <summary>
    /// Sky Blue
    /// </summary>
    public static readonly Color SkyBlue = new(102, 191, 255);

    /// <summary>
    /// Blue
    /// </summary>
    public static readonly Color Blue = new(0, 121, 241);

    /// <summary>
    /// Dark Blue
    /// </summary>
    public static readonly Color DarkBlue = new(0, 82, 172);

    /// <summary>
    /// Purple
    /// </summary>
    public static readonly Color Purple = new(200, 122, 255);

    /// <summary>
    /// Violet
    /// </summary>
    public static readonly Color Violet = new(135, 60, 190);

    /// <summary>
    /// Dark Purple
    /// </summary>
    public static readonly Color DarkPurple = new(112, 31, 126);

    /// <summary>
    /// Beige
    /// </summary>
    public static readonly Color Beige = new(211, 176, 131);

    /// <summary>
    /// Brown
    /// </summary>
    public static readonly Color Brown = new(127, 106, 79);

    /// <summary>
    /// Dark Brown
    /// </summary>
    public static readonly Color DarkBrown = new(76, 63, 47);

    /// <summary>
    /// White
    /// </summary>
    public static readonly Color White = new(255, 255, 255);

    /// <summary>
    /// Black
    /// </summary>
    public static readonly Color Black = new(0, 0, 0);

    /// <summary>
    /// Blank (Transparent)
    /// </summary>
    public static readonly Color Blank = new(0, 0, 0, 0);

    /// <summary>
    /// Magenta
    /// </summary>
    public static readonly Color Magenta = new(255, 0, 255);

    /// <summary>
    /// My own White (raylib logo)
    /// </summary>
    public static readonly Color RayWhite = new(245, 245, 245);

    /// <summary>
    /// Color red value
    /// </summary>
    public byte R = r;

    /// <summary>
    /// Color green value
    /// </summary>
    public byte G = g;

    /// <summary>
    /// Color blue value
    /// </summary>
    public byte B = b;

    /// <summary>
    /// Color alpha value
    /// </summary>
    public byte A = a;

    public bool Equals(Color other)
    {
        return R == other.R && G == other.G && B == other.B && A == other.A;
    }

    public override bool Equals(object? obj)
    {
        return obj is Color other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(R, G, B, A);
    }

    public override string ToString()
    {
        return $"<{R} {G} {B} {A}>";
    }

    public static Color FromNormalized(float r, float g, float b, float a = 1.0f)
    {
        return new Color(
            (byte)(r < 0.0f ? 0.0f : r > 1.0f ? 1.0f : r),
            (byte)(g < 0.0f ? 0.0f : g > 1.0f ? 1.0f : g),
            (byte)(b < 0.0f ? 0.0f : b > 1.0f ? 1.0f : b),
            (byte)(a < 0.0f ? 0.0f : a > 1.0f ? 1.0f : a)
        );
    }

    public static bool operator ==(Color left, Color right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Color left, Color right)
    {
        return !left.Equals(right);
    }
}