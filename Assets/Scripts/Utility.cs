using UnityEngine;

public static class Utility
{
	public static LaunchData CalculateLaunchData(Vector3 target, Vector3 origin, float h)
	{
		float displacementY = target.y - origin.y;
		Vector3 displacementXZ = new Vector3(target.x - origin.x, 0, target.z - origin.z);
		float time = Mathf.Sqrt(-2 * h / Physics.gravity.y) + Mathf.Sqrt(2 * (displacementY - h) / Physics.gravity.y);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y), time);
	}
	public struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}
	}
}
    
