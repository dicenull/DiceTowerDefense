using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Entend
{
	public static float GetAim(Vector2 p1, Vector2 p2)
	{
		float dx = p2.x - p1.x;
		float dy = p2.y - p1.y;
		float rad = Mathf.Atan2(dy, dx);
		return rad * Mathf.Rad2Deg;
	}
}
