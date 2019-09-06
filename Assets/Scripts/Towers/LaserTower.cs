using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LaserTower : TowerBase
{
	protected override float basicRange => 1f;

	protected override float basicPower => 6f;

	protected override float basicInterval => 5f;

	public override int Cost => 50;

	protected override void attack()
	{
		if (!canAttack)
		{
			return;
		}

		bool attacked = false;
		foreach (Transform enemy in enemies)
		{
			var distance = Vector3.Distance(transform.position, enemy.position);

			if (distance <= Range)
			{
				enemy.GetComponent<EnemyBase>().DamageFrom(this);

				attacked = true;
			}
		}

		if(attacked)
		{
			canAttack = false;
			timer.ReStart();
		}
	}
}
