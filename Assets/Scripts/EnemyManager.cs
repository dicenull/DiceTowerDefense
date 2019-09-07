using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	public static Dictionary<string, GameObject> Enemies { get; } = new Dictionary<string, GameObject>();

	private void Start()
	{
		var prefab = Resources.Load<GameObject>("Prefabs/EnemyPrefab");

		foreach (var name in new[]
		{
			"Benisasori",
			"Pmite"
		})
		{
			Enemies[name] = Instantiate(prefab, transform);
			Enemies[name].AddComponent(Type.GetType($"E{name}"));
			Enemies[name].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"Images/{name}");
		}
	}
}
