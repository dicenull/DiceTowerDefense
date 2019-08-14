using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHpController : DataControllerBase
{
	protected GameHpController()
	{
		Data = 10;
	}

	public void Damage()
	{
		Data--;
	}
}
