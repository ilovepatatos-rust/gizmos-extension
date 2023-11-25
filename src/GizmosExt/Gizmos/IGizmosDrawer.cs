using JetBrains.Annotations;

namespace Oxide.Ext.GizmosExt
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public interface IGizmosDrawer
    {
        void DrawGizmos(BasePlayer player, float duration);
        void DrawGizmos(IEnumerable<BasePlayer> players, float duration);
    }
}