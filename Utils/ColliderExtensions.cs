// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>Provides several static extension methods for the Unity <see cref="Collider"/> object.</summary>
    public static class ColliderExtensions
    {
        /// <summary>Creates a Bounds encapsulating all given colliders bounds.</summary>
        /// <param name="colliders">The colliders.</param>
        /// <returns>A Bounds encapsulating all given colliders bounds.</returns>
        public static Bounds CombineColliderBounds(Collider[] colliders)
        {
            var bounds = colliders[0].bounds;
            foreach (var colliderComponent in colliders)
                bounds.Encapsulate(colliderComponent.bounds);
            return bounds;
        }
    }
}
