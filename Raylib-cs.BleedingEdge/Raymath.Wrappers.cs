using System.Numerics;

namespace Raylib_cs.BleedingEdge;

public static unsafe partial class Raymath
{
    /// <summary>
    /// Orthonormalize provided vectors <br/>
    /// Makes vectors normalized and orthogonal to each other <br/>
    /// Gram-Schmidt function implementation
    /// </summary>
    public static void Vector3OrthoNormalize(ref Vector3 v1, ref Vector3 v2)
    {
        fixed (Vector3* pV1 = &v1)
        {
            fixed (Vector3* pV2 = &v2)
            {
                Vector3OrthoNormalize(pV1, pV2);
            }
        }
    }

    /// <summary>
    /// Get the rotation angle and axis for a given quaternion
    /// </summary>
    public static void QuaternionToAxisAngle(Quaternion q, out Vector3 axis, out float angle)
    {
        fixed (Vector3* pAxis = &axis)
        {
            fixed (float* pAngle = &angle)
            {
                QuaternionToAxisAngle(q, pAxis, pAngle);
            }
        }
    }

    /// <summary>
    /// Decompose a transformation matrix into its rotational, translational and scaling components
    /// </summary>
    public static void MatrixDecompose(Matrix4x4 mat, out Vector3 translation, out Quaternion rotation, out Vector3 scale)
    {
        fixed (Vector3* pTranslation = &translation)
        {
            fixed (Quaternion* pRotation = &rotation)
            {
                fixed (Vector3* pScale = &scale)
                {
                    MatrixDecompose(mat, pTranslation, pRotation, pScale);
                }
            }
        }
    }
}