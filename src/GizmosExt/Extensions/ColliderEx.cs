using JetBrains.Annotations;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class ColliderEx
{
    public static void DrawGizmos(this Collider col, BasePlayer player, float duration, Color color)
    {
        switch (col)
        {
            case SphereCollider sphere:
                sphere.DrawGizmos(player, duration, color);
                break;
            case BoxCollider box:
                box.DrawGizmos(player, duration, color);
                break;
        }
    }

    public static void DrawGizmos(this Collider col, IEnumerable<BasePlayer> players, float duration, Color color)
    {
        switch (col)
        {
            case SphereCollider sphere:
                sphere.DrawGizmos(players, duration, color);
                break;
            case BoxCollider box:
                box.DrawGizmos(players, duration, color);
                break;
        }
    }
}