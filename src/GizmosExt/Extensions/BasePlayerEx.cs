using Network;

namespace Oxide.Ext.GizmosExt;

internal static class BasePlayerEx
{
    internal static void SendAdminCommand(this BasePlayer player, string cmd, params object[] args)
    {
        Connection connection = player.Connection;
        if (connection == null)
            return;

        bool wasAdmin = player.ValidateIsAdmin();
        ConsoleNetwork.SendClientCommand(connection, cmd, args);
        player.RevertAdminState(wasAdmin);
    }

    /// <returns>
    /// Whether the player was an admin or not.
    /// </returns>
    private static bool ValidateIsAdmin(this BasePlayer player)
    {
        if (player.IsAdmin)
            return true;

        player.InvalidateNetworkCache();

        player.SetPlayerFlag(BasePlayer.PlayerFlags.IsAdmin, true);
        player.SendAsSnapshot(player.Connection);

        return false;
    }

    private static void RevertAdminState(this BasePlayer player, bool wasAdmin)
    {
        if (wasAdmin)
            return;

        if (!player.IsAdmin)
            return;

        player.InvalidateNetworkCache();

        player.SetPlayerFlag(BasePlayer.PlayerFlags.IsAdmin, false);
        player.SendAsSnapshot(player.Connection);
    }
}