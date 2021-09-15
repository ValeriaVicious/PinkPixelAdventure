using UnityEngine;


namespace Adventure
{
    internal static class Utils
    {
        public static Vector3 Change(this Vector3 vector, object x = null, object y = null, object z = null)
        {
            return new Vector3(x == null ? vector.x : (float)x, y == null ? vector.y : (float)y,
                z == null ? vector.z : (float)z);
        }

        public static Vector2 Change(this Vector2 vector, object x = null, object y = null, object z = null)
        {
            return new Vector2(x == null ? vector.x : (float)x, y == null ? vector.y : (float)y);
        }
    }
}
