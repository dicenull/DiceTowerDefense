using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
	public static MoneyController Instance { get; } = new MoneyController();

	public int Money { get; private set; } = 100;
    
	private MoneyController()
	{
		MoneyChanged?.Invoke(this, EventArgs.Empty);
	}

	public bool SettableTower(TowerBase tower)
	{
		return tower.Cost <= Money;
	}

	/// <summary>
	/// お金を払う
	/// </summary>
	/// <param name="money">払う金額</param>
	public void Pay(int money)
	{
		if(Money < money)
		{
			throw new ArgumentException("使用できる金額以上の額が指定されています");
		}

		Money -= money;
		MoneyChanged?.Invoke(this, EventArgs.Empty);
	}

	/// <summary>
	/// お金を受け取る
	/// </summary>
	/// <param name="money">受け取る金額</param>
	public void Recieve(int money)
	{
		Money += money;
		MoneyChanged?.Invoke(this, EventArgs.Empty);
	}

	public event EventHandler MoneyChanged;
}
