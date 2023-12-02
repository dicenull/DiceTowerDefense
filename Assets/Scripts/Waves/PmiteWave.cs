using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmiteWave : WaveBase
{
	public override IEnumerator Wave
	{
		get
		{
			for (var i = 0; i < 20; i++)
			{
				var enemy = Instantiate(EnemyPrefabManager.Enemies["Pmite"], transform);
				enemy.SetActive(true);

				yield return new WaitForSeconds(1f);
			}

			yield break;
		}
	}
}
