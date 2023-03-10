// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>Provides several static extension methods for <see cref="Camera"/> objects.</summary>
    public static class CameraExtensions
    {
        /// <summary>Calculates the size of the viewport at a given distance from a perspective camera.</summary>
        /// <param name="camera">The Camera.</param>
        /// <param name="distance">The positive distance from the camera.</param>
        /// <param name="aspectRatio">Optionally: An aspect ratio to use. If 0 is set, camera.aspect is used.</param>
        /// <returns>The size of the viewport at the given distance.</returns>
        public static Vector2 CalculateViewportWorldSizeAtDistance(this Camera camera, float distance, float aspectRatio = 0)
        {
            if (aspectRatio == 0)
                aspectRatio = camera.aspect;

            var viewportHeightAtDistance = 2.0f * Mathf.Tan(0.5f * camera.fieldOfView * Mathf.Deg2Rad) * distance;
            var viewportWidthAtDistance = viewportHeightAtDistance * aspectRatio;

            return new Vector2(viewportWidthAtDistance, viewportHeightAtDistance);
        }
    }
}
