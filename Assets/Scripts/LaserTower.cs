using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LaserTower : TowerBase
{
	public override float Range => 3f;

	public override float Damage => 5f;

	public override float ReloadTime => 2.3f;

}
