using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	private GameObject enemyObj;
	private Timer spawnTimer;

	private void Awake()
	{
		enemyObj = Resources.Load<GameObject>("Prefabs/Enemy");

		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.Interval = 2f;

		spawnTimer.Tick += SpawnTimer_Tick;
		spawnTimer.TimerStart();
	}

	private void SpawnTimer_Tick(object sender, System.EventArgs e)
	{
		Instantiate(enemyObj, transform);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
