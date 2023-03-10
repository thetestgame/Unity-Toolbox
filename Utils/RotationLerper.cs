// Copyright Jordan Maxwell, All Rights Reserved

namespace UnityToolbox.Utils
{
    using UnityEngine;

    /// <summary>
    /// Utility struct to linearly interpolate between two Quaternion values. Allows for flexible linear interpolations
    /// where current and target change over time.
    /// </summary>
    public struct RotationLerper
    {
        // Calculated start for the most recent interpolation
        private Quaternion m_LerpStart;

        // Calculated time elapsed for the most recent interpolation
        private float m_CurrentLerpTime;

        // The duration of the interpolation, in seconds
        private float m_LerpTime;

        public RotationLerper(Quaternion start, float lerpTime)
        {
            this.m_LerpStart = start;
            this.m_CurrentLerpTime = 0f;
            this.m_LerpTime = lerpTime;
        }

        /// <summary>
        /// Linearly interpolate between two Quaternion values.
        /// </summary>
        /// <param name="current"> Start of the interpolation. </param>
        /// <param name="target"> End of the interpolation. </param>
        /// <returns> A Quaternion value between current and target. </returns>
        public Quaternion LerpRotation(Quaternion current, Quaternion target)
        {
            if (current != target)
            {
                this.m_LerpStart = current;
                this.m_CurrentLerpTime = 0f;
            }

            this.m_CurrentLerpTime += Time.deltaTime;
            if (this.m_CurrentLerpTime > this.m_LerpTime)
            {
                this.m_CurrentLerpTime = this.m_LerpTime;
            }

            var lerpPercentage = this.m_CurrentLerpTime / this.m_LerpTime;

            return Quaternion.Slerp(this.m_LerpStart, target, lerpPercentage);
        }
    }
}
