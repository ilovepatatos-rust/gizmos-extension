using JetBrains.Annotations;
using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Ext.GizmosExt;

[UsedImplicitly]
public class GizmosExt : Extension
{
    private static readonly VersionNumber s_extensionVersion = new(1, 0, 0);

    public override string Name => "GizmosExt";
    public override string Author => "Ilovepatatos";
    public override VersionNumber Version => s_extensionVersion;

    public override bool SupportsReloading => true;

    public GizmosExt(ExtensionManager manager) : base(manager) { }

    public override IEnumerable<string> GetPreprocessorDirectives()
    {
        yield return "GIZMOS_FRAMEWORK";
    }
}