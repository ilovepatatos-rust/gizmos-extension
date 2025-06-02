using JetBrains.Annotations;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class CapsuleColliderEx
{
    public static void DrawGizmos(this CapsuleCollider col, BasePlayer player, float duration, Color color)
    {
        Transform transform = col.transform;
        OxideGizmos.Capsule(player, transform.position, transform.rotation, col.radius, col.height, color, duration);
    }

    public static void DrawGizmos(this CapsuleCollider col, IEnumerable<BasePlayer> players, float duration, Color color)
    {
        Transform transform = col.transform;
        OxideGizmos.Capsule(players, transform.position, transform.rotation, col.radius, col.height, color, duration);
    }
}