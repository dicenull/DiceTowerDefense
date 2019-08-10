using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
	private MoneyController controller;
	private Text text;

	// Start is called before the first frame update
	void Start()
	{
		controller = MoneyController.Instance;
		text = GetComponent<Text>();

		controller.MoneyChanged += Controller_MoneyChanged;
	}

	private void Controller_MoneyChanged(object sender, System.EventArgs e)
	{
		DisplayText();
	}

	private void DisplayText()
	{
		text.text = $"Money: {controller.Money}";
	}
}