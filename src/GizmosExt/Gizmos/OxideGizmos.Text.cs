using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

public static partial class OxideGizmos
{
    /// <summary>
    /// Render a text at a given position.
    /// </summary>
    public static void Text(BasePlayer player, Vector3 pos, string text, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.text", duration, color, pos, text, visibleDistance);
    }

    public static void Text([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, string text, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Text(player, pos, text, color, duration, visibleDistance);
    }

    public static void Text([NotNull] List<Connection> connections, Vector3 pos, string text, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Text(players, pos, text, color, duration, visibleDistance);
    }
}