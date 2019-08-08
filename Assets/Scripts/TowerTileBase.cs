using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class TowerTileBase : Tile
{
    public abstract float Range { get; }
	public abstract float Damage { get; }
	public abstract float ReloadTime { get; }
}
