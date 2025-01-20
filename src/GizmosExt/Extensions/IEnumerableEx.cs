using JetBrains.Annotations;
using Network;

namespace Oxide.Ext.GizmosExt;

// ReSharper disable once InconsistentNaming
[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
internal static class IEnumerableEx
{
    public static List<Connection> GetOnlineConnectionsPooled(this IEnumerable<BasePlayer> players)
    {
        var list = Facepunch.Pool.Get<List<Connection>>();
        list.AddRange(from player in players where player != null select player.Connection into con where con != null select con);
        return list;
    }
}