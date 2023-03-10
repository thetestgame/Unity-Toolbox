// Copyright Jordan Maxwell, All Rights Reserved
// Copyright Tobias Wehrum 2016, Modified from https://github.com/TobiasWehrum/unity-utilities

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>Provides several static extension methods for the Unity <see cref="LayerMask"/> object.</summary>
    public static class LayerMaskExtensions
    {
        /// <summary>Is a specific layer actived in the given LayerMask?</summary>
        /// <param name="mask">The LayerMask.</param>
        /// <param name="layer">The layer to check for.</param>
        /// <returns>True if the layer is activated.</returns>
        public static bool ContainsLayer(this LayerMask mask, int layer) => (mask.value & (1 << layer)) != 0;
    }
}
