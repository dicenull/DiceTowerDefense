using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3IntExtend
{
	
    public static Vector3Int RotatedRight(this Vector3Int vector)
	{
		return Vector3Int.RoundToInt(Quaternion.Euler(0, 0, 90) * vector);
	}

	public static Vector3Int RotatedLeft(this Vector3Int vector)
	{
		return Vector3Int.RoundToInt(Quaternion.Euler(0, 0, -90) * vector);
	}

	public static void RotateRight(this ref Vector3Int vector)
	{
		vector = vector.RotatedRight();
	}

	public static void RotateLeft(this ref Vector3Int vector)
	{
		vector = vector.RotatedLeft();
	}
}
