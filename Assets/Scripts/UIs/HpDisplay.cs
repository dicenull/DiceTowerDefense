using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpDisplay : DisplayBase<GameHpController>
{
	protected override void DisplayText()
	{
		text.text = $"Hp: {controller.Data}";
	}
}
