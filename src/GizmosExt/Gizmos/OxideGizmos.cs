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

    /// <summary>
    /// Render a sphere at a given position.
    /// </summary>
    public static void Sphere(BasePlayer player, Vector3 pos, float radius, Color color, float duration,
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
    public static void Box(BasePlayer player, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (player == null)
            return;

        Connection connection = player.Connection;
        if (connection == null)
            return;

        bool wasAdmin = player.ValidateIsAdmin();

        const string command = "ddraw.line";
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;
        float halfDepth = size.z / 2f;

        // Calculate the 8 corners of the box
        var corners = new Vector3[8];
        corners[0] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        corners[1] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        corners[2] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        corners[3] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        corners[4] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        corners[5] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        corners[6] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);
        corners[7] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);

        // Draw the 12 edges of the box
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[0], corners[1], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[1], corners[2], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[2], corners[3], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[3], corners[0], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[4], corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[5], corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[6], corners[7], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[7], corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[0], corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[1], corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[2], corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[3], corners[7], visibleDistance, zTest);

        player.RevertAdminState(wasAdmin);
    }

    public static void Box([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        const string command = "ddraw.line";
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;
        float halfDepth = size.z / 2f;

        // Calculate the 8 corners of the box
        var corners = new Vector3[8];
        corners[0] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        corners[1] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        corners[2] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        corners[3] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        corners[4] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        corners[5] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        corners[6] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);
        corners[7] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);

        foreach (BasePlayer player in players)
        {
            if (player == null)
                continue;

            Connection connection = player.Connection;
            if (connection == null)
                continue;

            bool wasAdmin = player.ValidateIsAdmin();

            // Draw the 12 edges of the box
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[0], corners[1], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[1], corners[2], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[2], corners[3], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[3], corners[0], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[4], corners[5], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[5], corners[6], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[6], corners[7], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[7], corners[4], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[0], corners[4], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[1], corners[5], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[2], corners[6], visibleDistance, zTest);
            ConsoleNetwork.SendClientCommand(connection, command, duration, color, corners[3], corners[7], visibleDistance, zTest);

            player.RevertAdminState(wasAdmin);
        }
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