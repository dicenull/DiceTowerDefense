using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : DataControllerBase
{
	protected MoneyController()
	{
		Data = 150;
	}

	public bool SettableTower(TowerBase tower)
	{
		return tower.Cost <= Data;
	}

	public void Pay(int money)
	{
		if (Data < money)
		{
			throw new ArgumentException("使用できる金額以上の額が指定されています");
		}

		Data -= money;
	}

	public void Recieve(int money)
	{
		Data += money;
	}
}
