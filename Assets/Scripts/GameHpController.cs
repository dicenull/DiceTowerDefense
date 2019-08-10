using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHpController : MonoBehaviour
{
	public static GameHpController Instance { get; } = new GameHpController();

	private GameHpController()
	{
		HpChanged?.Invoke(this, EventArgs.Empty);
	}

	public int Hp { get; private set; } = 10;
    
	public void Damage()
	{
		Hp--;
		HpChanged?.Invoke(this, EventArgs.Empty);
	}

	public event EventHandler HpChanged;
}
