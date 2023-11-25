using JetBrains.Annotations;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.GizmosExt;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("(Sample) GizmosExt", "Ilovepatatos", "1.0.0")]
    [Description("Sample commands to test the gizmos extensions.")]
    public class GizmosExtSample : CovalencePlugin
    {
        private const float DURATION = 10f;

#region Commands

        [UsedImplicitly]
        [Command("gizmos.line")]
        private void Line(IPlayer iPlayer, string cmd, string[] args)
        {
            BasePlayer player = iPlayer.Object as BasePlayer;
            if (player == null) return;

            Vector3 from = player.eyes.position;

            const float distance = 10f;
            Vector3 to = from + player.eyes.HeadRay().direction * distance;

            OxideGizmos.Line(player, DURATION, Color.green, from, to);
        }

        [UsedImplicitly]
        [Command("gizmos.box")]
        private void Box(IPlayer iPlayer, string cmd, string[] args)
        {
            BasePlayer player = iPlayer.Object as BasePlayer;
            if (player == null) return;

            Vector3 pos = player.transform.position;
            Quaternion rot = player.GetNetworkRotation();
            Vector3 size = Vector3.one * 3f;

            OxideGizmos.Box(player, pos, rot, size, Color.green, DURATION);
        }

        [UsedImplicitly]
        [Command("gizmos.sphere")]
        private void Sphere(IPlayer iPlayer, string cmd, string[] args)
        {
            BasePlayer player = iPlayer.Object as BasePlayer;
            if (player == null) return;

            const float radius = 3f;
            Vector3 pos = player.transform.position;

            OxideGizmos.Sphere(player, pos, radius, Color.green, DURATION);
        }

        [UsedImplicitly]
        [Command("gizmos.arrow")]
        private void Arrow(IPlayer iPlayer, string cmd, string[] args)
        {
            BasePlayer player = iPlayer.Object as BasePlayer;
            if (player == null) return;

            Vector3 from = player.eyes.position;

            const float distance = 10f;
            Vector3 to = from + player.eyes.HeadRay().direction * distance;

            const float headSize = 10f;
            OxideGizmos.Arrow(player, from, to, headSize, Color.green, DURATION);
        }

        [UsedImplicitly]
        [Command("gizmos.text")]
        private void Text(IPlayer iPlayer, string cmd, string[] args)
        {
            BasePlayer player = iPlayer.Object as BasePlayer;
            if (player == null) return;

            const string text = "<size=20>Hello World!</size>";
            Vector3 pos = player.eyes.position;

            OxideGizmos.Text(player, pos, text, Color.green, DURATION);
        }

#endregion
    }
}