using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : TowerBase
{
	protected override float basicRange => 1.5f;

	protected override float basicPower => 5f;

	protected override float basicInterval => 1.5f;

	public override int Cost => 30;

	protected override void attack()
	{
		if (!canAttack)
		{
			return;
		}

		foreach (Transform enemy in enemies)
		{
			var distance = Vector3.Distance(transform.position, enemy.position);

			if (distance <= Range)
			{
				enemy.GetComponent<EnemyBase>().DamageFrom(this);
				canAttack = false;
				timer.ReStart();
				break;
			}
		}
	}

	protected override void aim()
	{
		followingAim();
	}
}
