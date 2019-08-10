using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTile : Tile
{
	private void Awake()
	{
		sprite = Resources.Load<Sprite>("Images/rangeCircle");
	}
}
