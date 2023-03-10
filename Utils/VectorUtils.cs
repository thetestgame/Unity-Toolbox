// Copyright Jordan Maxwell, All Rights Reserved

namespace DD.BoilerEngine.CMF
{
    using UnityEngine;

    /// <summary>
    /// Static utility methods for Unity's vector objects.
    /// </summary>
    public static class VectorUtils
    {
        /// <summary>Creates a Vector2 with a length of 1 pointing towards a certain angle.</summary>
        /// <param name="angleRad">The angle in radians.</param>
        /// <returns>The Vector2 pointing towards the angle.</returns>
        public static Vector2 CreateVector2AngleRad(float angleRad) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        /// <summary>Creates a Vector2 with a length of 1 pointing towards a certain angle.</summary>
        /// <param name="angleDeg">The angle in degrees.</param>
        /// <returns>The Vector2 pointing towards the angle.</returns>
        public static Vector2 CreateVector2AngleDeg(float angleDeg) => CreateVector2AngleRad(angleDeg * Mathf.Deg2Rad);

        /// <summary>
        /// Calculate signed angle (ranging from -180 to +180) between 'vector1' and 'vector2';
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <param name="planeNormal"></param>
        /// <returns></returns>
        public static float GetAngle(Vector3 vector1, Vector3 vector2, Vector3 planeNormal)
        {
            // Calculate angle and sign;
            float angle = Vector3.Angle(vector1, vector2);
            float sign = Mathf.Sign(Vector3.Dot(planeNormal, Vector3.Cross(vector1, vector2)));

            // Combine angle and sign;
            float signedAngle = angle * sign;

            return signedAngle;
        }

        /// <summary>
        /// Returns the length of the part of a vector that points in the same direction as 'direction' (i.e., the dot product);
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static float GetDotProduct(Vector3 vector, Vector3 direction)
        {
            // Normalize vector if necessary;
            if (direction.sqrMagnitude != 1)
                direction.Normalize();

            float length = Vector3.Dot(vector, direction);

            return length;
        }

        /// <summary>
        /// Remove all parts from a vector that are pointing in the same direction as 'direction';
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector3 RemoveDotVector(Vector3 vector, Vector3 direction)
        {
            // Normalize vector if necessary;
            if (direction.sqrMagnitude != 1)
                direction.Normalize();

            float amount = Vector3.Dot(vector, direction);
            vector -= direction * amount;
            return vector;
        }

        /// <summary>
        /// Extract and return parts from a vector that are pointing in the same direction as 'direction'
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static Vector3 ExtractDotVector(Vector3 vector, Vector3 direction)
        {
            // Normalize vector if necessary;
            if (direction.sqrMagnitude != 1)
                direction.Normalize();

            float amount = Vector3.Dot(vector, direction);
            return direction * amount;
        }

        /// <summary>
        /// Rotate a vector onto a plane defined by 'planeNormal'
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="planeNormal"></param>
        /// <param name="upDirection"></param>
        /// <returns></returns>
        public static Vector3 RotateVectorOntoPlane(Vector3 vector, Vector3 planeNormal, Vector3 upDirection)
        {
            // Calculate rotation;
            Quaternion rotation = Quaternion.FromToRotation(upDirection, planeNormal);

            // Apply rotation to vector;
            vector = rotation * vector;

            return vector;
        }

        /// <summary>
        /// Project a point onto a line defined by 'lineStartPosition' and 'lineDirection';
        /// </summary>
        /// <param name="lineStartPosition"></param>
        /// <param name="lineDirection"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 ProjectPointOntoLine(Vector3 lineStartPosition, Vector3 lineDirection, Vector3 point)
        {
            // Caclculate vector pointing from 'lineStartPosition' to 'point';
            Vector3 projectLine = point - lineStartPosition;

            float dotProduct = Vector3.Dot(projectLine, lineDirection);

            return lineStartPosition + lineDirection * dotProduct;
        }

        /// <summary>
        /// Increments a vector toward a target vector, using 'speed' and 'deltaTime';
        /// </summary>
        /// <param name="currentVector"></param>
        /// <param name="speed"></param>
        /// <param name="deltaTime"></param>
        /// <param name="targetVector"></param>
        /// <returns></returns>
        public static Vector3 IncrementVectorTowardTargetVector(Vector3 currentVector, float speed, float deltaTime, Vector3 targetVector) =>
            Vector3.MoveTowards(currentVector, targetVector, speed * deltaTime);
    }
}