using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class OxideGizmos
{
    /// <summary>
    /// Can be used by plugins to reference gizmos between them.
    /// </summary>
    public static readonly List<IGizmosDrawer> AllGizmos = new();

    /// <summary>
    /// Render a line from point A to point B.
    /// </summary>
    public static void Line([NotNull] BasePlayer player, float duration, Color color, Vector3 from, Vector3 to,
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

    /// <summary>
    /// Render a sphere at a given position.
    /// </summary>
    public static void Sphere([NotNull] BasePlayer player, Vector3 pos, float radius, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.sphere", duration, color, pos, radius, visibleDistance);
    }

    public static void Sphere([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, float radius, Color color, float duration,
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

    /// <summary>
    /// Render a box using lines at a given position/rotation.
    /// </summary>
    public static void Box([NotNull] BasePlayer player, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.box", duration, color, pos, size, rot.eulerAngles, visibleDistance, zTest);
    }

    public static void Box(IEnumerable<BasePlayer> players, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Box(player, pos, rot, size, color, duration, visibleDistance, zTest);
    }

    public static void Box([NotNull] List<Connection> connections, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Box(players, pos, rot, size, color, duration, visibleDistance, zTest);
    }

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

    public static void TopDownArrow(IEnumerable<BasePlayer> players, Vector3 pos, float yPos, Color color, float duration,
        float height = 50, float headSize = 15, float visibleDistance = float.PositiveInfinity)
    {
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

    /// <summary>
    /// Render a text at a given position.
    /// </summary>
    public static void Text(BasePlayer player, Vector3 pos, string text, Color color, float duration,
        float visibleDistance = float.PositiveInfinity)
    {
        if (player != null)
            player.SendAdminCommand("ddraw.text", duration, color, pos, text, visibleDistance);
    }

    public static void Text(IEnumerable<BasePlayer> players, Vector3 pos, string text, Color color, float duration,
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