using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
	SpriteRenderer preview;
	GameObject cursor;

	public TowerBase CurrentTower { get; private set; } = null;

	private void Awake()
	{
		preview = GameObject.FindWithTag("TowerPreview").GetComponent<SpriteRenderer>();
		
		cursor = GameObject.FindWithTag("Cursor");
	}

	public void NotifyClick(Transform sender)
	{
		foreach(Transform child in transform)
		{
			var image = child.GetComponent<Image>();

			if (child == sender)
			{
				image.color = Color.white;
			}
			else
			{
				image.color = Color.gray;
			}
		}

		preview.sprite = Resources.Load<Sprite>($"Images/Towers/{sender.name}");
		CurrentTower = sender.GetComponent<TowerBase>();

		cursor.SetActive(false);
	}
}
