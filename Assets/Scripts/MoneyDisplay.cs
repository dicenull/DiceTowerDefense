using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : DisplayBase<MoneyController>
{
	protected override void DisplayText()
	{
		text.text = $"Money: {controller.Data}";
	}
}