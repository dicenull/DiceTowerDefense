using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
	private List<WaveBase> Waves = new List<WaveBase>();

	public int CurrentPos { get; private set; } = 0;

	public bool IsEnd { get; private set; } = false;

    // Start is called before the first frame update
    void Awake()
    {
		Waves.AddRange(new WaveBase[]
		{
			gameObject.AddComponent<BeniWave>(),
			gameObject.AddComponent<BeniWave2>(),
			gameObject.AddComponent<PmiteWave>()
		});

		CurrentPos = 0;
	}

	public IEnumerator Wave()
	{
		var coroutine = Waves[CurrentPos].Wave;

		yield return StartCoroutine(coroutine);

		CurrentPos++;

		if(CurrentPos >= Waves.Count)
		{
			IsEnd = true;
			OnClear?.Invoke(this, EventArgs.Empty);
			yield break;
		}

		OnEndWave?.Invoke(Waves[CurrentPos], EventArgs.Empty);
	}

	public event EventHandler OnEndWave;

	public event EventHandler OnClear;
}
