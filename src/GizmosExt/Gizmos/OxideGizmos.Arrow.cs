using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

public static partial class OxideGizmos
{
    /// <summary>
    /// Render an arrow from point A to point B.
    /// </summary>
    public static void Arrow(BasePlayer player, Vector3 from, Vector3 to, float headSize, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.arrow", duration, color, from, to, headSize, visibleDistance);
    }

    public static void Arrow([NotNull] IEnumerable<BasePlayer> players, Vector3 from, Vector3 to, float headSize, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Arrow(player, from, to, headSize, color, duration, visibleDistance);
    }

    public static void Arrow([NotNull] List<Connection> connections, Vector3 from, Vector3 to, float headSize, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Arrow(players, from, to, headSize, color, duration, visibleDistance);
    }

    /// <summary>
    /// Render a top-down arrow at a given position.
    /// </summary>
    public static void TopDownArrow(BasePlayer player, Vector3 pos, float yPos, Color color, float duration,
        float height = 50, float headSize = 15, float visibleDistance = float.PositiveInfinity)
    {
        var to = new Vector3(pos.x, yPos, pos.z);
        Vector3 from = to + new Vector3(0, height, 0);

        Arrow(player, from, to, headSize, color, duration, visibleDistance);
    }

    public static void TopDownArrow([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, float yPos, Color color, float duration,
        float height = 50, float headSize = 15, float visibleDistance = float.PositiveInfinity)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        var to = new Vector3(pos.x, yPos, pos.z);
        Vector3 from = to + new Vector3(0, height, 0);

        Arrow(players, from, to, headSize, color, duration, visibleDistance);
    }

    public static void TopDownArrow([NotNull] List<Connection> connections, Vector3 pos, float yPos, Color color, float duration,
        float height = 50, float headSize = 15, float visibleDistance = float.PositiveInfinity)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        TopDownArrow(players, pos, yPos, color, duration, height, headSize, visibleDistance);
    }
}