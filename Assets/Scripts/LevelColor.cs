using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelColor
{
	public static Color ColorOf(int level)
	{
		switch (level)
		{
			case 1:
				return Color.white;
			case 2:
				return Color.green;
			case 3:
				return Color.cyan;
			case 4:
				return Color.blue;
			case 5:
				return Color.yellow;
			case 6:
				return Color.red;
			default:
				return Color.magenta;
		}
	}
}
