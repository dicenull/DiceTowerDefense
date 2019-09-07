using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelecter : MonoBehaviour
{
	SpriteRenderer preview;
	TowerStatusViewer statusViewer;
	GameObject cursor;

	private void Awake()
	{
		preview = GameObject.FindWithTag("TowerPreview").GetComponent<SpriteRenderer>();
		statusViewer = GameObject.FindWithTag("StatusBox").GetComponent<TowerStatusViewer>();

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
		statusViewer.Tower = sender.GetComponent<TowerBase>();

		cursor.SetActive(false);
	}
}
