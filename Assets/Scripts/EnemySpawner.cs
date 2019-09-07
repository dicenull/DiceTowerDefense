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
	}

	private void Start()
	{
		StartCoroutine(enemyWave());
	}
	
	IEnumerator enemyWave()
	{
		for(var i = 0;i < 10;i++)
		{
			Instantiate(enemyObj, transform);

			yield return new WaitForSeconds(2);
		}
	}
}
