using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LaserTower : TowerTileBase
{
	static Sprite laserSprite = Resources.Load<Sprite>("Images/laserTower");

	public override float Range => 3f;

	public override float Damage => 5f;

	public override float ReloadTime => 2.3f;

	private void Awake()
	{
		this.sprite = laserSprite;
	}
}
