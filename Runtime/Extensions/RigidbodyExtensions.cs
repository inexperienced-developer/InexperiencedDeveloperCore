using ID.Utils;
using UnityEngine;

namespace ID.Extensions
{
    public static class RigidbodyExtensions
    {
        /// <summary>
        ///  Aligns a Rigidbody to a target vector using torque. Adjusting the multiplier value can affect how quickly or smoothly the alignment occurs.
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="alignment"></param>
        /// <param name="target"></param>
        /// <param name="spring"></param>
        /// <param name="maxTorque"></param>
        /// <param name="multiplier"></param>
        public static void AlignToVector(this Rigidbody rb, Vector3 alignment, Vector3 target, float spring, float maxTorque, float multiplier = 0.1f)
        {
            //Rotate the alignment by the magnitude of the angular velocity
            Quaternion rotationFromAngularVelocity = Quaternion.AngleAxis(rb.angularVelocity.magnitude * MathUtils.DEG2RAD * multiplier, rb.angularVelocity);
            //Get cross between normalized alignment and normalized target
            Vector3 alignmentCross = Vector3.Cross((rotationFromAngularVelocity * alignment.normalized).normalized, target.normalized);
            //Calculate the alignment force based on the magnitude of the cross product
            Vector3 alignmentForce = alignmentCross.normalized * Mathf.Asin(Mathf.Clamp01(alignmentCross.magnitude));
            //Scale the alignment force by the specified spring value
            alignmentForce *= spring;
            //Apply the alignment force to the rigidbody as torque, clamped to the specified maximum torque
            rb.SafeAddTorque(Vector3.ClampMagnitude(alignmentForce, maxTorque));
        }

        /// <summary>
        /// Only adds torque if the number is a real number avoiding crazy physics errors at the sacrifice of missing some force additions.
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="torque"></param>
        /// <param name="mode"></param>
        public static void SafeAddTorque(this Rigidbody rb, Vector3 torque, ForceMode mode = ForceMode.Force)
        {
            if (float.IsNaN(torque.x) || float.IsNaN(torque.y) || float.IsNaN(torque.z) || torque.sqrMagnitude > 1E+10f)
            {
                Debug.LogWarning($"Invalid torque ({torque}) for {rb.name}.");
            }
            else
            {
                rb.AddTorque(torque, mode);
            }
        }

        /// <summary>
        /// Only adds force if the number is a real number avoiding crazy physics errors at the sacrifice of missing some force additions.
        /// </summary>
        /// <param name="rb"></param>
        /// <param name="force"></param>
        /// <param name="mode"></param>
        public static void SafeAddForce(this Rigidbody rb, Vector3 force, ForceMode mode = ForceMode.Force)
        {
            if (float.IsNaN(force.x) || float.IsNaN(force.y) || float.IsNaN(force.z) || force.sqrMagnitude > 2.5E+11f)
            {
                Debug.LogWarning($"Invalid force ({force}) for {rb.name}.");
            }
            else
            {
                rb.AddForce(force, mode);
            }
        }

        public static float GetForwardVelocity(this Rigidbody rb)
        {
            return Vector3.Dot(rb.velocity, rb.transform.forward);
        }
    }
}
