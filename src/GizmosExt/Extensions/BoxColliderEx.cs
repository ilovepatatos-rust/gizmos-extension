using JetBrains.Annotations;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class BoxColliderEx
{
    public static void DrawGizmos(this BoxCollider col, BasePlayer player, float duration, Color color)
    {
        OxideGizmos.Box(player, col.transform.position, col.transform.rotation, col.size, color, duration);
    }

    public static void DrawGizmos(this BoxCollider col, IEnumerable<BasePlayer> players, float duration, Color color)
    {
        OxideGizmos.Box(players, col.transform.position, col.transform.rotation, col.size, color, duration);
    }
}