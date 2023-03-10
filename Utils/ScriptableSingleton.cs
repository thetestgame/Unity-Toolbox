// Copyright Jordan Maxwell, All Rights Reserved

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>
    /// Singleton variation of the Unity <see cref="ScriptableObject"/>
    /// </summary>
    /// <typeparam name="T">Type this singleton object represents</typeparam>
    public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
    {
        /// <inheritdoc cref="Instance"/>
        private static T instance;

        /// <summary>
        /// This object's singleton instance
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = Resources.Load<T>(typeof(T).ToString());
                    (instance as ScriptableSingleton<T>).OnInitialize();
                }
                return instance;
            }
        }

        /// <summary>
        /// Called when the singleton object is initiaqlized
        /// </summary>
        protected virtual void OnInitialize() { }
    }
}
