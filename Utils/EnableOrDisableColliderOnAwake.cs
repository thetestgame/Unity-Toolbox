// Copyright Jordan Maxwell, All Rights Reserved

namespace UnityToolbox.Utils
{
    using UnityEngine;

    public class EnableOrDisableColliderOnAwake : MonoBehaviour
    {
        [SerializeField] private Collider collider;
        [SerializeField] private bool enableStateOnAwake;

        private void Awake()
        {
            this.collider.enabled = this.enableStateOnAwake;
        }
    }
}
