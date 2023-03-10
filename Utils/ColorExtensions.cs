// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>Provides several static extension methods for the Unity <see cref="Color"/> object.</summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Makes a copy of the Color with changed r/g/b/a values, keeping all undefined values as they were before. Can be
        /// called with named parameters like color.Change(g: 0, a: 0.5), for example, only changing the g and a components.
        /// </summary>
        /// <param name="color">The Color to be copied with changed values.</param>
        /// <param name="r">If this is not null, the r component is set to this value.</param>
        /// <param name="g">If this is not null, the g component is set to this value.</param>
        /// <param name="b">If this is not null, the b component is set to this value.</param>
        /// <param name="a">If this is not null, the a component is set to this value.</param>
        /// <returns>A copy of the Color with changed values.</returns>
        public static Color Change(this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
        {
            if (r.HasValue) color.r = r.Value;
            if (g.HasValue) color.g = g.Value;
            if (b.HasValue) color.b = b.Value;
            if (a.HasValue) color.a = a.Value;
            return color;
        }

        /// <summary>
        /// Makes a copy of the vector with a changed alpha value.
        /// </summary>
        /// <param name="color">The Color to copy.</param>
        /// <param name="a">The new a component.</param>
        /// <returns>A copy of the Color with a changed alpha.</returns>
        public static Color ChangeAlpha(this Color color, float a)
        {
            color.a = a;
            return color;
        }

        /// <summary>
        /// Framerate-independent eased lerping to a target value, slowing down the closer it is.
        /// 
        /// If you call
        /// 
        ///     currentValue = UnityHelper.EasedLerpVector3(currentValue, Color.white, 0.75f);
        /// 
        /// each frame (e.g. in Update()), starting with a currentValue of Color.black, then after 1 second
        /// it will be approximately (0.75|0.75|0.75) - which is 75% of the way between Color.white and Color.black.
        /// 
        /// Adjusting the target or the percentPerSecond between calls is also possible.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The target value.</param>
        /// <param name="percentPerSecond">How much of the distance between current and target should be covered per second?</param>
        /// <param name="deltaTime">How much time passed since the last call.</param>
        /// <returns>The interpolated value from current to target.</returns>
        public static Color EasedLerpColor(Color current, Color target, float percentPerSecond, float deltaTime = 0f)
        {
            var t = MathUtils.EasedLerpFactor(percentPerSecond, deltaTime);
            return Color.Lerp(current, target, t);
        }

    }
}
