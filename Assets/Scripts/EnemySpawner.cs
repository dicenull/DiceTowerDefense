using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	private bool onWave = false;
	private bool endSpawn = false;

	[SerializeField]
	private Slider waitSlider = null;

	public int Wave { get; private set; } = 1;

	private void Update()
	{
		if (endSpawn && transform.childCount == 0)
		{
			onWave = false;
			endSpawn = false;
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
		var time = 1;
		var endTime = Time.time + time;

		waitSlider.maxValue = time;
		waitSlider.gameObject.SetActive(true);

		while(true)
		{
			var diff = endTime - Time.time;

			if (diff <= 0)
			{
				break;
			}

			waitSlider.value = diff;

			yield return null;
		}
		waitSlider.gameObject.SetActive(false);

		Wave++;
		StartCoroutine(enemyWave());
		yield break;
	}
	
	IEnumerator enemyWave()
	{
		switch (Wave)
		{
			case 1:
				for (var i = 0; i < 10; i++)
				{
					var enemy = Instantiate(EnemyPrefabManager.Enemies["Benisasori"], transform);
					enemy.SetActive(true);

					yield return new WaitForSeconds(2);
				}
				break;

			case 2:
				for(var i = 0;i < 15; i++)
				{
					var enemy = Instantiate(EnemyPrefabManager.Enemies["Benisasori"], transform);
					enemy.SetActive(true);

					yield return new WaitForSeconds(1.5f);
				}
				break;

			case 3:
				for(var i = 0; i < 20;i++)
				{
					var enemy = Instantiate(EnemyPrefabManager.Enemies["Pmite"], transform);
					enemy.SetActive(true);

					yield return new WaitForSeconds(1f);
				}
				break;

			default:
				// CLEAR
				break;
		}

		endWave();
		yield break;
	}


}
