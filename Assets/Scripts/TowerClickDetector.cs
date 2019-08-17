using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerClickDetector : MonoBehaviour, IPointerClickHandler
{
	private TowerSelecter selecter;

	private void Awake()
	{
		selecter = transform.parent.GetComponent<TowerSelecter>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		selecter.NotifyClick(this);
	}
}
