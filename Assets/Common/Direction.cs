using System;
using UnityEngine;

[Flags]
public enum Direction : byte
{
	None = 0,
	Up = 1,
	Down = 2,
	North = 4,
	South = 8,
	East = 16,
	West = 32,
	AllHorizontal = North | South | East | West,
	All = Up | Down | North | South | East | West,
}

public static class Vector3Extensions
{
	public static Direction ToDirection(this Vector3 v)
	{
		float ax = Math.Abs(v.x);
		float ay = Math.Abs(v.y);
		float az = Math.Abs(v.z);
		if (ax > ay)
		{
			if (ax > az)
			{
				return v.x > 0 ? Direction.East : Direction.West;
			}
			return v.z > 0 ? Direction.North : Direction.South;
		}

		if (ay > az)
		{
			return v.y > 0 ? Direction.Up : Direction.Down;
		}
		return v.z > 0 ? Direction.North : Direction.South;
	}
}