using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHpController : DataControllerBase
{
	private readonly int initHp = 10;

	protected GameHpController()
	{
		Data = initHp;
	}

	public void Damage()
	{
		Data--;

		if(Data < 0)
		{
			Data = 0;
		}
	}

	public void Reset()
	{
		Data = initHp;
	}
}
