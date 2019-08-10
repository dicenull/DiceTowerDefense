using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : MonoBehaviour
{
	private GameHpController controller;
	private Text text;

	// Start is called before the first frame update
	void Start()
	{
		controller = GameHpController.Instance;
		text = GetComponent<Text>();

		controller.HpChanged += Controller_HpChanged;
		DisplayText();
	}

	private void Controller_HpChanged(object sender, System.EventArgs e)
	{
		DisplayText();
	}

	private void DisplayText()
	{
		text.text = $"Hp: {controller.Hp}";
	}
}
