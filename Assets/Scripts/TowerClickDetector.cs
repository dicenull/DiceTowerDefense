using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerClickDetector : MonoBehaviour, IPointerClickHandler
{
	private TowerSelector selecter;

	private void Awake()
	{
		selecter = transform.parent.GetComponent<TowerSelector>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		selecter.NotifyClick(transform);
	}
}
