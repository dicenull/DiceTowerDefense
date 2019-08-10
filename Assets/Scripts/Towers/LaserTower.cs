using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LaserTower : TowerBase
{
	public override float Range => 1.5f;

	public override float Power => 5f;

	public override float Interval => 1.5f;

}
