using JetBrains.Annotations;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class SphereColliderEx
{
    public static void DrawGizmos(this SphereCollider col, BasePlayer player, float duration, Color color)
    {
        OxideGizmos.Sphere(player, col.transform.position, col.radius, color, duration);
    }

    public static void DrawGizmos(this SphereCollider col, IEnumerable<BasePlayer> players, float duration, Color color)
    {
        OxideGizmos.Sphere(players, col.transform.position, col.radius, color, duration);
    }
}