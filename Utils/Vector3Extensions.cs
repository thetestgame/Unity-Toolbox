﻿// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>Utility functions for working with Unity <see cref="Vector3"/> objects.</summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Makes a copy of the Vector3 with changed x/y/z values, keeping all undefined values as they were before. Can be
        /// called with named parameters like vector.Change3(x: 5, z: 10), for example, only changing the x and z components.
        /// </summary>
        /// <param name="vector">The Vector3 to be copied with changed values.</param>
        /// <param name="x">If this is not null, the x component is set to this value.</param>
        /// <param name="y">If this is not null, the y component is set to this value.</param>
        /// <param name="z">If this is not null, the z component is set to this value.</param>
        /// <returns>A copy of the Vector3 with changed values.</returns>
        public static Vector3 Change3(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            if (x.HasValue) vector.x = x.Value;
            if (y.HasValue) vector.y = y.Value;
            if (z.HasValue) vector.z = z.Value;
            return vector;
        }

        /// <summary>
        /// Framerate-independent eased lerping to a target value, slowing down the closer it is.
        /// 
        /// If you call
        /// 
        ///     currentValue = UnityHelper.EasedLerpVector3(currentValue, Vector3.one, 0.75f);
        /// 
        /// each frame (e.g. in Update()), starting with a currentValue of Vector3.zero, then after 1 second
        /// it will be approximately (0.75|0.75|0.75) - which is 75% of the way between Vector3.zero and Vector3.one.
        /// 
        /// Adjusting the target or the percentPerSecond between calls is also possible.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The target value.</param>
        /// <param name="percentPerSecond">How much of the distance between current and target should be covered per second?</param>
        /// <param name="deltaTime">How much time passed since the last call.</param>
        /// <returns>The interpolated value from current to target.</returns>
        public static Vector3 EasedLerpVector3(Vector3 current, Vector3 target, float percentPerSecond, float deltaTime = 0f)
        {
            var t = MathUtils.EasedLerpFactor(percentPerSecond, deltaTime);
            return Vector3.Lerp(current, target, t);
        }

        /// <summary>Calculates the average position of an array of Vector3.</summary>
        /// <param name="array">The input array.</param>
        /// <returns>The average position.</returns>
        public static Vector3 CalculateCentroid(this Vector3[] array)
        {
            var sum = new Vector3();
            var count = array.Length;
            for (var i = 0; i < count; i++)
            {
                sum += array[i];
            }
            return sum / count;
        }

        /// <summary>Calculates the average position of a List of Vector3.</summary>
        /// <param name="list">The input list.</param>
        /// <returns>The average position.</returns>
        public static Vector3 CalculateCentroid(this List<Vector3> list)
        {
            var sum = new Vector3();
            var count = list.Count;
            for (var i = 0; i < count; i++)
            {
                sum += list[i];
            }
            return sum / count;
        }
    }
}
