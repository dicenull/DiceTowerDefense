using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFixed : MonoBehaviour
{
	Quaternion initRotation;

	private void Start()
	{
		initRotation = transform.rotation;
	}

	// Update is called once per frame
	void Update()
    {
		transform.rotation = initRotation;
    }
}
