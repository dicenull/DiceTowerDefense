using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
	public static MoneyController Instance { get; } = new MoneyController();

	public int Money { get; private set; } = 200;
    
	private MoneyController()
	{

	}

	public bool SettableTower(TowerBase tower)
	{
		return tower.Cost <= Money;
	}

	public void UseMoney(int money)
	{
		if(Money < money)
		{
			throw new ArgumentException("使用できる金額以上の額が指定されています");
		}

		Money -= money;
		MoneyChanged?.Invoke(this, EventArgs.Empty);
	}

	public event EventHandler MoneyChanged;
}
