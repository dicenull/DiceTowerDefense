﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPmite : EnemyBase
{
	public override float Speed => 1f;

	public override int Money => 15;

	protected override float hp { get; set; } = 20f;

}
