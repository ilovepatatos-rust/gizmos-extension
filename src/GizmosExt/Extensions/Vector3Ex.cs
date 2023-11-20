using UnityEngine;

namespace Oxide.Ext.GizmosExt
{
    internal static class Vector3Ex
    {
        public static Vector3 RotateAround(this Vector3 pivot, Vector3 point, Quaternion angle)
        {
            return angle * (point - pivot) + pivot;
        }
    }
}