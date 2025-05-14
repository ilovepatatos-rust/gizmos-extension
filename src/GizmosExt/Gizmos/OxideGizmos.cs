using JetBrains.Annotations;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static partial class OxideGizmos
{
    /// <summary>
    /// Can be used by plugins to reference gizmos between them.
    /// </summary>
    public static readonly List<IGizmosDrawer> AllGizmos = new();
}