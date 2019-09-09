using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnceButton : MonoBehaviour
{
	public void Used()
	{
		Destroy(gameObject, 0.1f);
	}
}
