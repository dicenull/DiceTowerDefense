using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	private bool endSpawn = false;

	[SerializeField]
	private Slider waitSlider = null;

	private WaveManager manager;
	
	private void Start()
	{
		manager = gameObject.AddComponent<WaveManager>();

		manager.OnEndWave += Manager_OnEndWave;
		manager.OnClear += Manager_OnClear;
	}

	private void Manager_OnClear(object sender, System.EventArgs e)
	{
		// Time.timeScale = 0;
		Debug.Log("CLEAR");
	}

	private void Manager_OnEndWave(object sender, System.EventArgs e)
	{
		endSpawn = true;
	}

	private void Update()
	{
		if (endSpawn && transform.childCount == 0)
		{
			if(manager.IsEnd)
			{
				return;
			}

			endSpawn = false;
			StartCoroutine(waitingAndNext());
		}
	}

	public void WaveStart()
	{
		StartCoroutine(manager.Wave());
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

		StartCoroutine(manager.Wave());
		yield break;
	}
}
