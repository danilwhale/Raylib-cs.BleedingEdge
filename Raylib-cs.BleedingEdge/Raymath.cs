using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Raylib_cs.BleedingEdge;

namespace Raylib_cs.BleedingEdge;

[SuppressUnmanagedCodeSecurity]
public static unsafe partial class Raymath
{
    private const string LibName = "raylib";

    /// <summary>
    /// Clamp float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Clamp(float value, float min, float max);

    /// <summary>
    /// Calculate linear interpolation between two floats
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Lerp(float start, float end, float amount);

    /// <summary>
    /// Normalize input value within input range
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Normalize(float value, float start, float end);

    /// <summary>
    /// Remap input value within input range to output range
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Remap(float value, float inputStart, float inputEnd, float outputStart, float outputEnd);

    /// <summary>
    /// Wrap input value from min to max
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Wrap(float value, float min, float max);

    /// <summary>
    /// Check whether two given floats are almost equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int FloatEquals(float x, float y);

    /// <summary>
    /// Vector with components value 0.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Zero();

    /// <summary>
    /// Vector with components value 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2One();

    /// <summary>
    /// Add two vectors (v1 + v2)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Add(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Add vector and float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2AddValue(Vector2 v, float add);

    /// <summary>
    /// Subtract two vectors (v1 - v2)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Subtract(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Subtract vector by float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2SubtractValue(Vector2 v, float sub);

    /// <summary>
    /// Calculate vector length
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2Length(Vector2 v);

    /// <summary>
    /// Calculate vector square length
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2LengthSqr(Vector2 v);

    /// <summary>
    /// Calculate two vectors dot product
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2DotProduct(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Calculate two vectors cross product
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2CrossProduct(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Calculate distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2Distance(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Calculate square distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2DistanceSqr(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Calculate the signed angle from v1 to v2, relative to the origin (0, 0).
    /// </summary>
    /// <remarks>
    /// NOTE: In Raylib's 2D coordinate system (positive X right, positive Y down),
    /// positive angles appear clockwise, and negative angles appear counterclockwise.
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2Angle(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Calculate angle defined by a two vectors line
    /// </summary>
    /// <remarks>
    /// NOTE: Parameters need to be normalized <br/>
    /// Current implementation should be aligned with glm::angle
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector2LineAngle(Vector2 start, Vector2 end);

    /// <summary>
    /// Scale vector (multiply by value)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Scale(Vector2 v, float scale);

    /// <summary>
    /// Multiply vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Multiply(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Negate vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Negate(Vector2 v);

    /// <summary>
    /// Divide vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Divide(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Normalize provided vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Normalize(Vector2 v);

    /// <summary>
    /// Transforms a Vector2 by a given Matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Transform(Vector2 v, Matrix4x4 mat);

    /// <summary>
    /// Calculate linear interpolation between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Lerp(Vector2 v1, Vector2 v2, float amount);

    /// <summary>
    /// Calculate reflected vector to normal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Reflect(Vector2 v, Vector2 normal);

    /// <summary>
    /// Get min value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Min(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Get max value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Max(Vector2 v1, Vector2 v2);

    /// <summary>
    /// Rotate vector by angle
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Rotate(Vector2 v, float angle);

    /// <summary>
    /// Move Vector towards target
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2MoveTowards(Vector2 v, Vector2 target, float maxDistance);

    /// <summary>
    /// Invert the given vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Invert(Vector2 v);

    /// <summary>
    /// Clamp the components of the vector between
    /// min and max values specified by the given vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Clamp(Vector2 v, Vector2 min, Vector2 max);

    /// <summary>
    /// Clamp the magnitude of the vector between two min and max values
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2ClampValue(Vector2 v, float min, float max);

    /// <summary>
    /// Check whether two given vectors are almost equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Vector2Equals(Vector2 p, Vector2 q);

    /// <summary>
    /// Compute the direction of a refracted ray
    /// </summary>
    /// <param name="v">normalized direction of the incoming ray</param>
    /// <param name="n">normalized normal vector of the interface of two optical media</param>
    /// <param name="r">ratio of the refractive index of the medium from where the ray comes to the refractive index of the medium on the other side of the surface</param>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector2 Vector2Refract(Vector2 v, Vector2 n, float r);

    /// <summary>
    /// Vector with components value 0.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Zero();

    /// <summary>
    /// Vector with components value 1.0f
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3One();

    /// <summary>
    /// Add two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Add(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Add vector and float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3AddValue(Vector3 v, float add);

    /// <summary>
    /// Subtract two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Subtract(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Subtract vector by float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3SubtractValue(Vector3 v, float sub);

    /// <summary>
    /// Multiply vector by scalar
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Scale(Vector3 v, float scalar);

    /// <summary>
    /// Multiply vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Multiply(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate two vectors cross product
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3CrossProduct(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate one vector perpendicular vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Perpendicular(Vector3 v);

    /// <summary>
    /// Calculate vector length
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3Length(Vector3 v);

    /// <summary>
    /// Calculate vector square length
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3LengthSqr(Vector3 v);

    /// <summary>
    /// Calculate two vectors dot product
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3DotProduct(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3Distance(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate square distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3DistanceSqr(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate angle between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector3Angle(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Negate provided vector (invert direction)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Negate(Vector3 v);

    /// <summary>
    /// Divide vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Divide(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Normalize provided vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Normalize(Vector3 v);

    /// <summary>
    /// Calculate the projection of the vector v1 on to v2
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Project(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Calculate the rejection of the vector v1 on to v2
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Reject(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Orthonormalize provided vectors <br/>
    /// Makes vectors normalized and orthogonal to each other <br/>
    /// Gram-Schmidt function implementation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Vector3OrthoNormalize(Vector3* v1, Vector3* v2);

    /// <summary>
    /// Transforms a Vector3 by a given Matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Transform(Vector3 v, Matrix4x4 mat);

    /// <summary>
    /// Transform a vector by quaternion rotation
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3RotateByQuaternion(Vector3 v, Quaternion q);

    /// <summary>
    /// Rotates a vector around an axis
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3RotateByAxisAngle(Vector3 v, Vector3 axis, float angle);

    /// <summary>
    /// Move Vector towards target
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3MoveTowards(Vector3 v, Vector3 target, float maxDistance);

    /// <summary>
    /// Calculate linear interpolation between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float amount);

    /// <summary>
    /// Calculate cubic hermite interpolation between two vectors and their tangents
    /// as described in the GLTF 2.0 specification: https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html#interpolation-cubic
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3CubicHermite(Vector3 v1, Vector3 tangent1, Vector3 v2, Vector3 tangent2, float amount);

    /// <summary>
    /// Calculate reflected vector to normal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Reflect(Vector3 v, Vector3 normal);

    /// <summary>
    /// Get min value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Min(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Get max value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Max(Vector3 v1, Vector3 v2);

    /// <summary>
    /// Compute barycenter coordinates (u, v, w) for point p with respect to triangle (a, b, c)
    /// </summary>
    /// <remarks>
    /// NOTE: Assumes P is on the plane of the triangle
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Barycenter(Vector3 p, Vector3 a, Vector3 b, Vector3 c);

    /// <summary>
    /// Projects a Vector3 from screen space into object space
    /// </summary>
    /// <remarks>
    /// NOTE: We are avoiding calling other raymath functions despite available
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Unproject(Vector3 source, Matrix4x4 projection, Matrix4x4 view);

    /// <summary>
    /// Get Vector3 as float array
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Float3 Vector3ToFloatV(Vector3 v);

    /// <summary>
    /// Invert the given vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Invert(Vector3 v);

    /// <summary>
    /// Clamp the components of the vector between
    /// min and max values specified by the given vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Clamp(Vector3 v, Vector3 min, Vector3 max);

    /// <summary>
    /// Clamp the magnitude of the vector between two values
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3ClampValue(Vector3 v, float min, float max);

    /// <summary>
    /// Check whether two given vectors are almost equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Vector3Equals(Vector3 p, Vector3 q);

    /// <summary>
    /// Compute the direction of a refracted ray
    /// </summary>
    /// <param name="v">normalized direction of the incoming ray</param>
    /// <param name="n">normalized normal vector of the interface of two optical media</param>
    /// <param name="r">ratio of the refractive index of the medium from where the ray comes to the refractive index of the medium on the other side of the surface</param>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 Vector3Reflect(Vector3 v, Vector3 n, float r);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Zero();

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4One();

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Add(Vector4 v1, Vector4 v2);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4AddValue(Vector4 v, float add);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Subtract(Vector4 v1, Vector4 v2);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4SubtractValue(Vector4 v, float add);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector4Length(Vector4 v);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector4LengthSqr(Vector4 v);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector4DotProduct(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Calculate distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector4Distance(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Calculate square distance between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float Vector4DistanceSqr(Vector4 v1, Vector4 v2);

    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Scale(Vector4 v, float scale);

    /// <summary>
    /// Multiply vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Multiply(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Negate vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Negate(Vector4 v);

    /// <summary>
    /// Divide vector by vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Divide(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Normalize provided vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Normalize(Vector4 v);

    /// <summary>
    /// Get min value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Min(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Get max value for each pair of components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Max(Vector4 v1, Vector4 v2);

    /// <summary>
    /// Calculate linear interpolation between two vectors
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Lerp(Vector4 v1, Vector4 v2, float amount);

    /// <summary>
    /// Move Vector towards target
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4MoveTowards(Vector4 v, Vector4 target, float maxDistance);

    /// <summary>
    /// Invert the given vector
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector4 Vector4Invert(Vector4 v);

    /// <summary>
    /// Check whether two given vectors are almost equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Vector4Equals(Vector4 p, Vector4 q);

    /// <summary>
    /// Compute matrix determinant
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float MatrixDeterminant(Matrix4x4 mat);

    /// <summary>
    /// Get the trace of the matrix (sum of the values along the diagonal)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float MatrixTrace(Matrix4x4 mat);

    /// <summary>
    /// Transposes provided matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixTranspose(Matrix4x4 mat);

    /// <summary>
    /// Invert provided matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixInvert(Matrix4x4 mat);

    /// <summary>
    /// Get identity matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixIdentity();

    /// <summary>
    /// Add two matrices
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixAdd(Matrix4x4 left, Matrix4x4 right);

    /// <summary>
    /// Subtract two matrices (left - right)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixSubtract(Matrix4x4 left, Matrix4x4 right);

    /// <summary>
    /// Get two matrix multiplication
    /// </summary>
    /// <remarks>
    /// NOTE: When multiplying matrices... the order matters!
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixMultiply(Matrix4x4 left, Matrix4x4 right);

    /// <summary>
    /// Get translation matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixTranslate(float x, float y, float z);

    /// <summary>
    /// Create rotation matrix from axis and angle
    /// </summary>
    /// <remarks>
    /// NOTE: Angle should be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotate(Vector3 axis, float angle);

    /// <summary>
    /// Get x-rotation matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotateX(float angle);

    /// <summary>
    /// Get y-rotation matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotateY(float angle);

    /// <summary>
    /// Get z-rotation matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotateZ(float angle);

    /// <summary>
    /// Get xyz-rotation matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotateXYZ(Vector3 angle);

    /// <summary>
    /// Get zyx-rotation matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixRotateZYX(Vector3 angle);

    /// <summary>
    /// Get scaling matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixScale(float x, float y, float z);

    /// <summary>
    /// Get perspective projection matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixFrustum(double left, double right, double bottom, double top, double nearPlane, double farPlane);

    /// <summary>
    /// Get perspective projection matrix
    /// </summary>
    /// <remarks>
    /// NOTE: Fovy angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixPerspective(double fovY, double aspect, double nearPlane, double farPlane);

    /// <summary>
    /// Get orthographic projection matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixOrtho(double left, double right, double bottom, double top, double nearPlane, double farPlane);

    /// <summary>
    /// Get camera look-at matrix (view matrix)
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 MatrixLookAt(Vector3 eye, Vector3 target, Vector3 up);

    /// <summary>
    /// Get float array of matrix data
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Float16 MatrixToFloatV(Matrix4x4 mat);

    /// <summary>
    /// Add two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionAdd(Quaternion q1, Quaternion q2);

    /// <summary>
    /// Add quaternion and float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionAddValue(Quaternion q, float add);

    /// <summary>
    /// Subtract two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionSubtract(Quaternion q1, Quaternion q2);

    /// <summary>
    /// Subtract quaternion and float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionSubtractValue(Quaternion q, float sub);

    /// <summary>
    /// Get identity quaternion
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionIdentity();

    /// <summary>
    /// Computes the length of a quaternion
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float QuaternionLength(Quaternion q);

    /// <summary>
    /// Normalize provided quaternio
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionNormalize(Quaternion q);

    /// <summary>
    /// Invert provided quaternion
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionInvert(Quaternion q);

    /// <summary>
    /// Calculate two quaternion multiplication
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionMultiply(Quaternion q1, Quaternion q2);

    /// <summary>
    /// Scale quaternion by float value
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionScale(Quaternion q, float mul);

    /// <summary>
    /// Divide two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionDivide(Quaternion q1, Quaternion q2);

    /// <summary>
    /// Calculate linear interpolation between two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionLerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>
    /// Calculate slerp-optimized interpolation between two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionNlerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>
    /// Calculates spherical linear interpolation between two quaternions
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionSlerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>
    /// Calculate quaternion cubic spline interpolation using Cubic Hermite Spline algorithm
    /// as described in the GLTF 2.0 specification: https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html#interpolation-cubic
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionCubicHermiteSpline(Quaternion q1, Quaternion outTangent1, Quaternion q2, Quaternion inTangent2, float t);

    /// <summary>
    /// Calculate quaternion based on the rotation from one vector to another
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionFromVector3ToVector3(Vector3 from, Vector3 to);

    /// <summary>
    /// Get a quaternion for a given rotation matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionFromMatrix(Matrix4x4 mat);

    /// <summary>
    /// Get a matrix for a given quaternion
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Matrix4x4 QuaternionToMatrix(Quaternion q);

    /// <summary>
    /// Get rotation quaternion for an angle and axis
    /// </summary>
    /// <remarks>
    /// NOTE: Angle must be provided in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionFromAxisAngle(Vector3 axis, float angle);

    /// <summary>
    /// Get the rotation angle and axis for a given quaternion
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void QuaternionToAxisAngle(Quaternion q, Vector3* outAxis, float* outAngle);

    /// <summary>
    /// Get the quaternion equivalent to Euler angles
    /// </summary>
    /// <remarks>
    /// NOTE: Rotation order is ZYX
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionFromEuler(float pitch, float yaw, float roll);

    /// <summary>
    /// Get the Euler angles equivalent to quaternion (roll, pitch, yaw)
    /// </summary>
    /// <remarks>
    /// NOTE: Angles are returned in a Vector3 struct in radians
    /// </remarks>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Vector3 QuaternionToEuler(Quaternion q);

    /// <summary>
    /// Transform a quaternion given a transformation matrix
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Quaternion QuaternionTransform(Quaternion q, Matrix4x4 mat);

    /// <summary>
    /// Check whether two given quaternions are almost equal
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int QuaternionEquals(Quaternion p, Quaternion q);

    /// <summary>
    /// Decompose a transformation matrix into its rotational, translational and scaling components
    /// </summary>
    [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void MatrixDecompose(Matrix4x4 mat, Vector3* translation, Quaternion* rotation, Vector3* scale);
}