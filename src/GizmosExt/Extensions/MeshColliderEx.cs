using JetBrains.Annotations;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class MeshColliderEx
{
    public static void DrawGizmos(this MeshCollider collider, BasePlayer player, float duration, Color color)
    {
        Mesh mesh = collider.sharedMesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 a = vertices[triangles[i]];
            Vector3 b = vertices[triangles[i + 1]];
            Vector3 c = vertices[triangles[i + 2]];

            a = collider.transform.TransformPoint(a);
            b = collider.transform.TransformPoint(b);
            c = collider.transform.TransformPoint(c);

            OxideGizmos.Line(player, duration, color, a, b);
            OxideGizmos.Line(player, duration, color, b, c);
            OxideGizmos.Line(player, duration, color, c, a);
        }
    }

    public static void DrawGizmos(this MeshCollider collider, IEnumerable<BasePlayer> players, float duration, Color color)
    {
        Mesh mesh = collider.sharedMesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 a = vertices[triangles[i]];
            Vector3 b = vertices[triangles[i + 1]];
            Vector3 c = vertices[triangles[i + 2]];

            a = collider.transform.TransformPoint(a);
            b = collider.transform.TransformPoint(b);
            c = collider.transform.TransformPoint(c);

            OxideGizmos.Line(players, duration, color, a, b);
            OxideGizmos.Line(players, duration, color, b, c);
            OxideGizmos.Line(players, duration, color, c, a);
        }
    }
}