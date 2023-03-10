// Copyright Jordan Maxwell, All Rights Reserved

namespace UnityToolbox.Utils
{
    using UnityEngine;
    using Random = UnityEngine.Random;

    /// <summary>Utility functions for working with the unity <see cref="UnityEngine.Random"/> object.</summary>
    public static class RandomUtils
    {
        /// <summary>Gets a random Vector2 of length 1 pointing in a random direction.</summary>
        public static Vector2 RandomOnUnitCircle
        {
            get
            {
                var angle = Random.Range(0f, Mathf.PI * 2);
                return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            }
        }

        /// <summary>Returns -1 or 1 with equal change.</summary>
        public static int RandomSign => (Random.value < 0.5f) ? -1 : 1;

        /// <summary>Returns true or false with equal chance.</summary>
        public static bool RandomBool => Random.value < 0.5f;
    }
}
