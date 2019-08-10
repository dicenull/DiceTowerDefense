using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBenisasori : EnemyBase
{
	public override float Speed => 1f;

	protected override float hp { get; set; } = 10f;
}
