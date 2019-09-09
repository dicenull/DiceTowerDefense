using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DisplayBase<T> : MonoBehaviour
	where T : DataControllerBase
{
	protected T controller;
	protected Text text;

	private void Awake()
	{
		controller = Singleton.GetInstance<T>();
	}

	// Start is called before the first frame update
	void Start()
	{
		text = GetComponent<Text>();

		controller.DataChanged += Controller_DataChanged;
		DisplayText();
	}

	private void Controller_DataChanged(object sender, System.EventArgs e)
	{
		DisplayText();
	}

	protected abstract void DisplayText();
}
