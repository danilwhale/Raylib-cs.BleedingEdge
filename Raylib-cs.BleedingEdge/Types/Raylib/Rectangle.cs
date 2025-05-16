using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Rectangle, 4 components
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Rectangle(float x, float y, float width, float height) : IEquatable<Rectangle>
{
    /// <summary>
    /// Rectangle top-left corner position x
    /// </summary>
    public float X = x;

    /// <summary>
    /// Rectangle top-left corner position y
    /// </summary>
    public float Y = y;

    /// <summary>
    /// Rectangle width
    /// </summary>
    public float Width = width;

    /// <summary>
    /// Rectangle height
    /// </summary>
    public float Height = height;

    /// <summary>
    /// Rectangle top-left corner position
    /// </summary>
    public Vector2 Position
    {
        readonly get => new(X, Y);
        set => (X, Y) = (value.X, value.Y);
    }

    /// <summary>
    /// Rectangle width and height
    /// </summary>
    public Vector2 Size
    {
        readonly get => new(Width, Height);
        set => (Width, Height) = (value.X, value.Y);
    }

    /// <summary>
    /// Rectangle, 4 components
    /// </summary>
    public Rectangle(Vector2 position, float width, float height)
        : this(position.X, position.Y, width, height)
    {
    }

    /// <summary>
    /// Rectangle, 4 components
    /// </summary>
    public Rectangle(float x, float y, Vector2 size)
        : this(x, y, size.X, size.Y)
    {
    }

    /// <summary>
    /// Rectangle, 4 components
    /// </summary>
    public Rectangle(Vector2 position, Vector2 size)
        : this(position.X, position.Y, size.X, size.Y)
    {
    }

    public override string ToString()
    {
        return $"<Position:{Position} Size:{Size}>";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Width, Height);
    }

    public bool Equals(Rectangle other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);
    }

    public override bool Equals(object? obj)
    {
        return obj is Rectangle other && Equals(other);
    }

    public static bool operator ==(Rectangle left, Rectangle right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Rectangle left, Rectangle right)
    {
        return !left.Equals(right);
    }
}