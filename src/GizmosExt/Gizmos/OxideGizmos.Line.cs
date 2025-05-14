using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

public static partial class OxideGizmos
{
    /// <summary>
    /// Render a line from point A to point B.
    /// </summary>
    public static void Line(BasePlayer player, float duration, Color color, Vector3 from, Vector3 to,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.line", duration, color, from, to, visibleDistance, zTest);
    }

    public static void Line([NotNull] IEnumerable<BasePlayer> players, float duration, Color color, Vector3 from, Vector3 to,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Line(player, duration, color, from, to, visibleDistance, zTest);
    }

    public static void Line([NotNull] List<Connection> connections, float duration, Color color, Vector3 from, Vector3 to,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Line(players, duration, color, from, to, visibleDistance, zTest);
    }
}