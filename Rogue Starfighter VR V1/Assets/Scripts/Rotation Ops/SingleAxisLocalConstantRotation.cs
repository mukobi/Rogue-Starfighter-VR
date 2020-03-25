using UnityEngine;
using System.Collections;

public class SingleAxisLocalConstantRotation : MonoBehaviour
{
	public enum Axis_t
	{
		XAxis,
		YAxis,
		ZAxis
	};

	public float TargetRotation { get; set; }

	private float CurrentRotation 
	{ 
		get 
		{
			float value;
			if (axis == Axis_t.XAxis) value = transform.localEulerAngles.x;
			else if (axis == Axis_t.YAxis) value = transform.localEulerAngles.y;
			else value = transform.localEulerAngles.z;

			if (value > 180) value -= 360;
			if (value< -180) value += 360;
			return value;
		} 
		set 
		{
			if (value > 180) value -= 360;
			if (value < -180) value += 360;
			if (axis == Axis_t.XAxis) transform.localEulerAngles = new Vector3(value, 0, 0);
			else if (axis == Axis_t.YAxis) transform.localEulerAngles = new Vector3(0, value, 0);
			else transform.localEulerAngles = new Vector3(0, 0, value);
		} 
	}

	[SerializeField] private Axis_t axis = default;

	[SerializeField] private float snapAngle = default;
	[SerializeField] private float rotationSpeed = default;

	private void Update()
	{
		Debug.Log(CurrentRotation);
		if (Mathf.Abs(CurrentRotation - TargetRotation) < snapAngle)
		{
			CurrentRotation = TargetRotation;
		}
		else
		{
			float delta = rotationSpeed * Time.deltaTime;
			if (TargetRotation < CurrentRotation) delta = -delta;
			CurrentRotation = CurrentRotation + delta;
		}
	}

}
