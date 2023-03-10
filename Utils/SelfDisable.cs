// Copyright Jordan Maxwell, All Rights Reserved

namespace Unity.BossRoom.Utils
{
    using UnityEngine;

    /// <summary>
    /// Will Disable this game object once active after the delay duration has passed.
    /// </summary>
    public class SelfDisable : MonoBehaviour
    {
        [SerializeField]
        private float disabledDelay;
        private float disableTimestamp;

        private void Update()
        {
            if (Time.time >= this.disableTimestamp)
                this.gameObject.SetActive(false);
        }

        private void OnEnable() => this.disableTimestamp = Time.time + this.disabledDelay;
    }
}
