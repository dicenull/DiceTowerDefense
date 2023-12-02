using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeniWave2 : WaveBase
{
	public override IEnumerator Wave
	{
		get
		{
			for (var i = 0; i < 15; i++)
			{
				var enemy = Instantiate(EnemyPrefabManager.Enemies["Benisasori"], transform);
				enemy.SetActive(true);

				yield return new WaitForSeconds(1.5f);
			}

			yield break;
		}
	}
}
