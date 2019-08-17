using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSelecter : MonoBehaviour
{
	public void NotifyClick(MonoBehaviour sender)
	{
		Debug.Log(sender.name);
	}
}
