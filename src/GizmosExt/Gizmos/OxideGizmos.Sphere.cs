using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

/// <summary>
/// Render a sphere at a given position.
/// </summary>
public static partial class OxideGizmos
{
    private const string COMMAND_SPHERE = "ddraw.sphere";

    public static void Sphere(BasePlayer player, Vector3 pos, float radius, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand(COMMAND_LINE, duration, color, pos, radius, visibleDistance);
    }

    public static void Sphere(BasePlayer player, Vector3 pos, float radius, Vector3 color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand(COMMAND_LINE, duration, color, pos, radius, visibleDistance);
    }

    public static void Sphere([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, float radius, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Sphere(player, pos, radius, color, duration, visibleDistance);
    }

    public static void Sphere([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, float radius, Vector3 color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Sphere(player, pos, radius, color, duration, visibleDistance);
    }

    public static void Sphere([NotNull] List<Connection> connections, Vector3 pos, float radius, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Sphere(players, pos, radius, color, duration, visibleDistance);
    }

    public static void Sphere([NotNull] List<Connection> connections, Vector3 pos, float radius, Vector3 color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Sphere(players, pos, radius, color, duration, visibleDistance);
    }
}