using JetBrains.Annotations;
using Network;
using UnityEngine;

namespace Oxide.Ext.GizmosExt
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class OxideGizmos
    {
        /// <summary>
        /// Can be used by plugins to reference gizmos between them.
        /// </summary>
        public static readonly List<IGizmosDrawer> AllGizmos = new();

        private static void SendCommandToPlayers(IEnumerable<BasePlayer> players, string cmd, params object[] args)
        {
            List<Connection> con = players.GetOnlineConnectionsPooled();
            SendCommandToPlayers(con, cmd, args);
            Facepunch.Pool.FreeList(ref con);
        }

        private static void SendCommandToPlayers(List<Connection> connections, string cmd, params object[] args)
        {
            if (connections.Count > 0)
                ConsoleNetwork.SendClientCommand(connections, cmd, args);
        }

        public static void Line(BasePlayer player, float duration, Color color, Vector3 from, Vector3 to)
        {
            Line(new[] { player }, duration, color, from, to);
        }

        public static void Line(IEnumerable<BasePlayer> players, float duration, Color color, Vector3 from, Vector3 to)
        {
            SendCommandToPlayers(players, "ddraw.line", duration, color, from, to);
        }

        public static void Line(List<Connection> connections, float duration, Color color, Vector3 from, Vector3 to)
        {
            SendCommandToPlayers(connections, "ddraw.line", duration, color, from, to);
        }

        public static void Box(BasePlayer player, Vector3 pos, float size, Color color, float duration)
        {
            Box(new[] { player }, pos, size, color, duration);
        }

        public static void Box(IEnumerable<BasePlayer> players, Vector3 pos, float size, Color color, float duration)
        {
            SendCommandToPlayers(players, "ddraw.box", duration, color, pos, size);
        }

        public static void Sphere(BasePlayer player, Vector3 pos, float radius, Color color, float duration)
        {
            Sphere(new[] { player }, pos, radius, color, duration);
        }

        public static void Sphere(IEnumerable<BasePlayer> players, Vector3 pos, float radius, Color color, float duration)
        {
            SendCommandToPlayers(players, "ddraw.sphere", duration, color, pos, radius);
        }

        public static void Arrow(BasePlayer player, Vector3 from, Vector3 to, float headSize, Color color, float duration)
        {
            Arrow(new[] { player }, from, to, headSize, color, duration);
        }

        public static void Arrow(IEnumerable<BasePlayer> players, Vector3 from, Vector3 to, float headSize, Color color, float duration)
        {
            SendCommandToPlayers(players, "ddraw.arrow", duration, color, from, to, headSize);
        }

        public static void TopDownArrow(BasePlayer player, Vector3 pos, float yPos, Color color, float duration, float height = 50, float headSize = 15)
        {
            TopDownArrow(new[] { player }, pos, yPos, color, duration, height, headSize);
        }

        public static void TopDownArrow(IEnumerable<BasePlayer> players, Vector3 pos, float yPos, Color color, float duration,
            float height = 50, float headSize = 15)
        {
            var to = new Vector3(pos.x, yPos, pos.z);
            Vector3 from = to + new Vector3(0, height, 0);
            Arrow(players, from, to, headSize, color, duration);
        }

        public static void Text(BasePlayer player, Vector3 pos, string text, Color color, float duration)
        {
            Text(new[] { player }, pos, text, color, duration);
        }

        public static void Text(IEnumerable<BasePlayer> players, Vector3 pos, string text, Color color, float duration)
        {
            SendCommandToPlayers(players, "ddraw.text", duration, color, pos, text);
        }

        public static void Box(BasePlayer player, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration)
        {
            Box(new[] { player }, pos, rot, size, color, duration);
        }

        public static void Box(IEnumerable<BasePlayer> players, Vector3 pos, Quaternion rot, Vector3 size, Color color, float duration)
        {
            List<Connection> con = players.GetOnlineConnectionsPooled();

            float halfWidth = size.x / 2f;
            float halfHeight = size.y / 2f;
            float halfDepth = size.z / 2f;

            //TODO Can be optimize by calculating 8 points instead of 16
            Vector3 corner01 = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y + halfHeight, pos.z - halfDepth), rot);
            Line(con, duration, color, corner01, corner01.RotateAround(new Vector3(corner01.x + size.x, corner01.y, corner01.z), rot));
            Line(con, duration, color, corner01, corner01.RotateAround(new Vector3(corner01.x, corner01.y, corner01.z + size.z), rot));
            Line(con, duration, color, corner01, corner01.RotateAround(new Vector3(corner01.x, corner01.y - size.y, corner01.z), rot));

            Vector3 corner02 = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y + halfHeight, pos.z + halfDepth), rot);
            Line(con, duration, color, corner02, corner02.RotateAround(new Vector3(corner02.x - size.x, corner02.y, corner02.z), rot));
            Line(con, duration, color, corner02, corner02.RotateAround(new Vector3(corner02.x, corner02.y, corner02.z - size.z), rot));
            Line(con, duration, color, corner02, corner02.RotateAround(new Vector3(corner02.x, corner02.y - size.y, corner02.z), rot));

            Vector3 corner03 = pos.RotateAround(new Vector3(pos.x + halfWidth, pos.y - halfHeight, pos.z - halfDepth), rot);
            Line(con, duration, color, corner03, corner03.RotateAround(new Vector3(corner03.x - size.x, corner03.y, corner03.z), rot));
            Line(con, duration, color, corner03, corner03.RotateAround(new Vector3(corner03.x, corner03.y, corner03.z + size.z), rot));
            Line(con, duration, color, corner03, corner03.RotateAround(new Vector3(corner03.x, corner03.y + size.y, corner03.z), rot));

            Vector3 corner04 = pos.RotateAround(new Vector3(pos.x - halfWidth, pos.y - halfHeight, pos.z + halfDepth), rot);
            Line(con, duration, color, corner04, corner04.RotateAround(new Vector3(corner04.x + size.x, corner04.y, corner04.z), rot));
            Line(con, duration, color, corner04, corner04.RotateAround(new Vector3(corner04.x, corner04.y, corner04.z - size.z), rot));
            Line(con, duration, color, corner04, corner04.RotateAround(new Vector3(corner04.x, corner04.y + size.y, corner04.z), rot));

            Facepunch.Pool.FreeList(ref con);
        }
    }
}