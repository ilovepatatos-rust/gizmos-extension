using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

/// <summary>
/// Render a box using lines at a given position/rotation.
/// </summary>
public static partial class OxideGizmos
{
    private static readonly Vector3[] s_corners = new Vector3[8];

    public static void Box(BasePlayer player, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (player == null)
            return;

        Connection connection = player.Connection;
        if (connection == null)
            return;

        // Calculate the 8 corners of the box
        CalculateCorners(pos, rot, size);

        // Draw the 12 edges of the box
        bool wasAdmin = player.ValidateIsAdmin();

        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[0], s_corners[1], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[1], s_corners[2], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[2], s_corners[3], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[3], s_corners[0], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[4], s_corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[5], s_corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[6], s_corners[7], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[7], s_corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[0], s_corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[1], s_corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[2], s_corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[3], s_corners[7], visibleDistance, zTest);

        player.RevertAdminState(wasAdmin);
    }

    public static void Box(BasePlayer player, Vector3 pos, Quaternion rot, Vector3 size, Vector3 color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (player == null)
            return;

        Connection connection = player.Connection;
        if (connection == null)
            return;

        // Calculate the 8 corners of the box
        CalculateCorners(pos, rot, size);

        // Draw the 12 edges of the box
        bool wasAdmin = player.ValidateIsAdmin();

        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[0], s_corners[1], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[1], s_corners[2], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[2], s_corners[3], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[3], s_corners[0], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[4], s_corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[5], s_corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[6], s_corners[7], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[7], s_corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[0], s_corners[4], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[1], s_corners[5], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[2], s_corners[6], visibleDistance, zTest);
        ConsoleNetwork.SendClientCommand(connection, COMMAND_LINE, duration, color, s_corners[3], s_corners[7], visibleDistance, zTest);

        player.RevertAdminState(wasAdmin);
    }

    public static void Box([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (players == null)
            throw new ArgumentNullException(nameof(players));

        foreach (BasePlayer player in players)
            Box(player, pos, rot, size, color, duration, visibleDistance, zTest);
    }

    public static void Box([NotNull] IEnumerable<BasePlayer> players, Vector3 pos, Quaternion rot, Vector3 size, Vector3 color, float duration,
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

    public static void Box([NotNull] List<Connection> connections, Vector3 pos, Quaternion rot, Vector3 size, Vector3 color, float duration,
        float visibleDistance = float.PositiveInfinity, bool zTest = true)
    {
        if (connections == null)
            throw new ArgumentNullException(nameof(connections));

        IEnumerable<BasePlayer> players = connections.Select(x => x.player as BasePlayer);
        Box(players, pos, rot, size, color, duration, visibleDistance, zTest);
    }

    private static void CalculateCorners(Vector3 pos, Quaternion rot, Vector3 size)
    {
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;
        float halfDepth = size.z / 2f;

        s_corners[0] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        s_corners[1] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
        s_corners[2] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        s_corners[3] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
        s_corners[4] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        s_corners[5] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
        s_corners[6] = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);
        s_corners[7] = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);
    }
}