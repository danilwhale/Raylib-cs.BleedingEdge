using System.Numerics;
using System.Runtime.InteropServices;

namespace Raylib_cs.BleedingEdge;

/// <summary>
/// Model, meshes, materials and animation data
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Model
{
    /// <summary>
    /// Local transform matrix
    /// </summary>
    public Matrix4x4 Transform;

    /// <summary>
    /// Number of meshes
    /// </summary>
    public int MeshCount;

    /// <summary>
    /// Number of materials
    /// </summary>
    public int MaterialCount;

    /// <summary>
    /// Meshes array
    /// </summary>
    public Mesh* Meshes;

    /// <summary>
    /// Materials array
    /// </summary>
    public Material* Materials;

    /// <summary>
    /// Mesh material number
    /// </summary>
    public int* MeshMaterial;

    /// <summary>
    /// Number of bones
    /// </summary>
    public int BoneCount;

    /// <summary>
    /// Bones information (skeleton)
    /// </summary>
    public BoneInfo* Bones;

    /// <summary>
    /// Bones base transformation (pose)
    /// </summary>
    public Transform* BindPose;

    public override string ToString()
    {
        return $"<Transform:{Transform} MeshCount:{MeshCount} MaterialCount:{MaterialCount} BoneCount:{BoneCount}>";
    }
}