using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt;

public static partial class OxideGizmos
{
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
}