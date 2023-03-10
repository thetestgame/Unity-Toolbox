// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using System;
    using UnityEngine;

    /// <summary>Provides several static extension methods for <see cref="GameObject"/> objects.</summary>
    public static class GameObjectExtensions
    {
        /// <summary>Assigns a layer to this GameObject and all its children recursively.</summary>
        /// <param name="gameObject">The GameObject to start at.</param>
        /// <param name="layer">The layer to set.</param>
        public static void AssignLayerToHierarchy(this GameObject gameObject, int layer)
        {
            var transforms = gameObject.GetComponentsInChildren<Transform>();
            for (var i = 0; i < transforms.Length; i++)
                transforms[i].gameObject.layer = layer;
        }

        /// <summary>
        /// When <see cref="UnityEngine.Object.Instantiate(UnityEngine.Object)"/> is called on a prefab named
        /// "Original", the resulting instance will be named "Original(Clone)". This method changes the name
        /// back to "Original" by stripping everything after and including the first "(Clone)" it finds. If no
        /// "(Clone)" is found, the name is left unchanged.
        /// </summary>
        /// <param name="gameObject">The GameObject to change the name of.</param>
        public static void StripCloneFromName(this GameObject gameObject) => gameObject.name = gameObject.GetNameWithoutClone();

        /// <summary>
        /// When <see cref="UnityEngine.Object.Instantiate(UnityEngine.Object)"/> is called on a prefab named
        /// "Original", the resulting instance will be named "Original(Clone)". This method returns the name
        /// without "(Clone)" by stripping everything after and including the first "(Clone)" it finds. If no
        /// "(Clone)" is found, the name is returned unchanged.
        /// </summary>
        /// <param name="gameObject">The GameObject to return the original name of.</param>
        public static string GetNameWithoutClone(this GameObject gameObject)
        {
            var gameObjectName = gameObject.name;

            var clonePartIndex = gameObjectName.IndexOf("(Clone)", StringComparison.Ordinal);
            if (clonePartIndex == -1)
                return gameObjectName;

            return gameObjectName.Substring(0, clonePartIndex);
        }

    }
}
