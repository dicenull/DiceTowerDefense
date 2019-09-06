using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
	protected abstract float basicRange { get; }
	protected abstract float basicPower { get; }
	protected abstract float basicInterval { get; }

	public float Range => basicRange * Mathf.Pow(1.25f, Level - 1);
	public float Power => basicPower * Mathf.Pow(1.4f, Level - 1);
	public float Interval => basicInterval * Mathf.Pow(0.95f, Level - 1);
	public int UpgradeCost => (int)(Cost * 0.5f * Level);
	public int Refund => sumCost / 2;
	
	public int Level { get; private set; } = 1;

	public abstract int Cost { get; }

	protected abstract void attack();

	protected Timer timer;
	protected Transform enemies;
	protected Transform rangeCircle;
	protected bool canAttack = true;
	protected int sumCost = 0;

	public void LevelUp()
	{
		sumCost += UpgradeCost;
		Level++;

		rangeCircle.localScale = new Vector3(Range, Range) * 2;
	}

	private void Awake()
	{
		timer = gameObject.AddComponent<Timer>();

		timer.Interval = Interval;
		timer.Tick += Timer_Tick;
		timer.TimerStart();

		enemies = GameObject.FindWithTag("SpawnPoint").transform;
		rangeCircle = transform.Find("RangeCircle");
		// 範囲を直径で設定
		rangeCircle.localScale = new Vector3(Range, Range) * 2;

		sumCost += Cost;
	}

	private void Update()
	{
		attack();
	}

	private void OnMouseEnter()
	{
		rangeCircle.gameObject.SetActive(true);
	}

	private void OnMouseExit()
	{
		rangeCircle.gameObject.SetActive(false);
	}

	private void Timer_Tick(object sender, System.EventArgs e)
	{
		canAttack = true;
	}

}
