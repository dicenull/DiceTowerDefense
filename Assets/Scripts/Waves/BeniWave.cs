using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeniWave : WaveBase
{
	public override IEnumerator Wave
	{
		get
		{
			for (var i = 0; i < 10; i++)
			{
				var enemy = Instantiate(EnemyPrefabManager.Enemies["Benisasori"], transform);
				enemy.SetActive(true);

				yield return new WaitForSeconds(2);
			}

			yield break;
		}
	}
}
