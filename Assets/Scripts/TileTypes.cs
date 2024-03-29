﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTypes : MonoBehaviour
{
	public static TileBase Wall { get; private set; }

	public static TileBase Base { get; private set; }

	private void Awake()
	{
		Wall = Resources.Load<TileBase>("Tiles/Wall");
		Base = Resources.Load<TileBase>("Tiles/Base");
	}
}
