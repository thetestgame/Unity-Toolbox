// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>Provides several static extension methods for <see cref="Vector2"/> objects.</summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// Makes a copy of the Vector2 with changed x/y values, keeping all undefined values as they were before. Can be
        /// called with named parameters like vector.Change2(y: 5), for example, only changing the y component.
        /// </summary>
        /// <param name="vector">The Vector2 to be copied with changed values.</param>
        /// <param name="x">If this is not null, the x component is set to this value.</param>
        /// <param name="y">If this is not null, the y component is set to this value.</param>
        /// <returns>A copy of the Vector2 with changed values.</returns>
        public static Vector2 Change2(this Vector2 vector, float? x = null, float? y = null)
        {
            if (x.HasValue) vector.x = x.Value;
            if (y.HasValue) vector.y = y.Value;
            return vector;
        }

        /// <summary>Rotates a Vector2.</summary>
        /// <param name="v">The Vector2 to rotate.</param>
        /// <param name="angleRad">How far to rotate the Vector2 in radians.</param>
        /// <returns>The rotated Vector2.</returns>
        public static Vector2 RotateRad(this Vector2 v, float angleRad)
        {
            // http://answers.unity3d.com/questions/661383/whats-the-most-efficient-way-to-rotate-a-vector2-o.html
            var sin = Mathf.Sin(angleRad);
            var cos = Mathf.Cos(angleRad);

            var tx = v.x;
            var ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);

            return v;
        }

        /// <summary>Rotates a Vector2.</summary>
        /// <param name="v">The Vector2 to rotate.</param>
        /// <param name="angleDeg">How far to rotate the Vector2 in degrees.</param>
        /// <returns>The rotated Vector2.</returns>
        public static Vector2 RotateDeg(this Vector2 v, float angleDeg) => v.RotateRad(angleDeg * Mathf.Deg2Rad);

        /// <summary>Gets the rotation of a Vector2.</summary>
        /// <param name="vector">The Vector2.</param>
        /// <returns>The rotation of the Vector2 in radians.</returns>
        public static float GetAngleRad(this Vector2 vector) => Mathf.Atan2(vector.y, vector.x);

        /// <summary>Gets the rotation of a Vector2.</summary>
        /// <param name="vector">The Vector2.</param>
        /// <returns>The rotation of the Vector2 in degrees.</returns>
        public static float GetAngleDeg(this Vector2 vector) => vector.GetAngleRad() * Mathf.Rad2Deg;

        /// <summary>
        /// Framerate-independent eased lerping to a target value, slowing down the closer it is.
        /// 
        /// If you call
        /// 
        ///     currentValue = UnityHelper.EasedLerpVector3(currentValue, Vector2.one, 0.75f);
        /// 
        /// each frame (e.g. in Update()), starting with a currentValue of Vector2.zero, then after 1 second
        /// it will be approximately (0.75|0.75) - which is 75% of the way between Vector2.zero and Vector2.one.
        /// 
        /// Adjusting the target or the percentPerSecond between calls is also possible.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The target value.</param>
        /// <param name="percentPerSecond">How much of the distance between current and target should be covered per second?</param>
        /// <param name="deltaTime">How much time passed since the last call.</param>
        /// <returns>The interpolated value from current to target.</returns>
        public static Vector2 EasedLerpVector2(Vector2 current, Vector2 target, float percentPerSecond, float deltaTime = 0f)
        {
            var t = MathUtils.EasedLerpFactor(percentPerSecond, deltaTime);
            return Vector2.Lerp(current, target, t);
        }

        /// <summary>Calculates the average position of an array of Vector2.</summary>
        /// <param name="array">The input array.</param>
        /// <returns>The average position.</returns>
        public static Vector2 CalculateCentroid(this Vector2[] array)
        {
            var sum = new Vector2();
            var count = array.Length;
            for (var i = 0; i < count; i++)
            {
                sum += array[i];
            }
            return sum / count;
        }

        /// <summary>Calculates the average position of a List of Vector2.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The average position.</returns>
        public static Vector2 CalculateCentroid(this List<Vector2> list)
        {
            var sum = new Vector2();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                sum += list[i];
            }
            return sum / count;
        }
    }
}
