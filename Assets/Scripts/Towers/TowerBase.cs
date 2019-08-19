using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public abstract float Range { get; }
	public abstract float Power { get; }
	public abstract float Interval { get; }

	public abstract int Cost { get; }

	protected abstract void attack();

	protected Timer timer;
	protected Transform enemies;
	protected Transform rangeCircle;
	protected bool canAttack = true;

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
