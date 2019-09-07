using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	private GameObject enemyObj;
	private bool onWave = false;
	private bool endSpawn = false;

	public int Wave { get; private set; } = 1;

	private void Awake()
	{
		enemyObj = Resources.Load<GameObject>("Prefabs/Enemy");
	}

	private void Update()
	{
		if (endSpawn && transform.childCount == 0)
		{
			onWave = false;
			StartCoroutine(waitingAndNext());
		}
	}

	public void WaveStart()
	{
		if(onWave)
		{
			return;
		}

		onWave = true;
		endSpawn = false;
		StartCoroutine(enemyWave());
	}

	private void endWave()
	{
		endSpawn = true;
	}

	IEnumerator waitingAndNext()
	{
		yield return new WaitForSeconds(15);

		Wave++;
		StartCoroutine(enemyWave());
	}
	
	IEnumerator enemyWave()
	{
		switch (Wave)
		{
			case 1:
				for (var i = 0; i < 10; i++)
				{
					Instantiate(enemyObj, transform);

					yield return new WaitForSeconds(2);
				}
				break;

			case 2:
				for(var i = 0;i < 15; i++)
				{
					Instantiate(enemyObj, transform);

					yield return new WaitForSeconds(1.5f);
				}
				break;

			default:
				// CLEAR
				break;
		}

		endWave();
	}


}
