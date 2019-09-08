using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetter : MonoBehaviour
{
	GameHpController hpController;
	MoneyController moneyController;

	[SerializeField]
	GameObject pauseObj = null;

    // Start is called before the first frame update
    void Start()
    {
		moneyController = Singleton.GetInstance<MoneyController>();


		hpController = Singleton.GetInstance<GameHpController>();
		hpController.DataChanged += HpController_DataChanged;
    }

	private void HpController_DataChanged(object sender, System.EventArgs e)
	{
		if(hpController.Data <= 0)
		{
			pauseObj.SetActive(true);
		}
	}

	public void OnRestartButtonClick()
	{
		hpController.Reset();
		moneyController.Reset();

		pauseObj.SetActive(false);
	}
}
