using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public abstract float Range { get; }
	public abstract float Power { get; }
	public abstract float Interval { get; }

	protected Timer timer;
	protected Transform enemies;

	private void Awake()
	{
		timer = gameObject.AddComponent<Timer>();

		timer.Interval = Interval;
		timer.Tick += Timer_Tick;
		timer.TimerStart();

		enemies = GameObject.FindWithTag("SpawnPoint").transform;
	}

	private void Timer_Tick(object sender, System.EventArgs e)
	{
		foreach (Transform enemy in enemies)
		{
			var distance = Vector3.Distance(transform.position, enemy.position);

			if(distance <= Range)
			{
				enemy.GetComponent<EnemyBase>().DamageFrom(this);
				break;
			}
		}
	}
}
