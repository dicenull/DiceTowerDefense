using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatusViewer : MonoBehaviour
{
	private List<Text> statuses;
	private string[] names = new[] { "Power", "Range", "Interval", "Cost", "UpgradeCost", "Refund" };

	private Image preview;
	private Text level;
	private Button upgradeBtn, deleteBtn;

	private TowerBase tower;
	public TowerBase Tower
	{
		set
		{
			tower = value;
			updateStatus();
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		statuses = new List<Text>();
		foreach(var name in names)
		{
			statuses.Add(transform.Find(name).GetComponent<Text>());
		}

		preview = transform.Find("Preview").GetComponent<Image>();
		level = transform.Find("Level").GetComponent<Text>();

		upgradeBtn = transform.Find("UpgradeButton").GetComponent<Button>();
		deleteBtn = transform.Find("DeleteButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
		// マウス上にあるオブジェクトを取得
		var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

		if(hit.collider == null)
		{
			return;
		}

		tower = hit.collider.gameObject.GetComponent<TowerBase>();
		updateStatus();
	}

	public void updateStatus()
	{
		for (var i = 0; i < names.Length; i++)
		{
			// ステータス名から各ステータスを取得
			var status = typeof(TowerBase).GetProperty(names[i]).GetValue(tower);

			if (i < 4)
			{
				statuses[i].text = $"{names[i]}: " + string.Format("{0:f}", status);
			}
			else
			{
				statuses[i].text = $"{(int)status}";
			}
		}


		level.text = $"Lv. {tower.Level}";

		if(tower.gameObject.GetComponent<SpriteRenderer>() != null)
		{
			// フィールド上のタワー
			preview.sprite = tower.gameObject.GetComponent<SpriteRenderer>().sprite;

			upgradeBtn.interactable = true;
			deleteBtn.interactable = true;
		}
		else
		{
			// 設置前のプレビュータワー
			preview.sprite = tower.gameObject.GetComponent<Image>().sprite;

			upgradeBtn.interactable = false;
			deleteBtn.interactable = false;
		}
	}

	public void Upgrade()
	{
		var moneyCon = Singleton.GetInstance<MoneyController>();
		if (tower == null || tower.UpgradeCost > moneyCon.Data)
		{
			return;
		}

		moneyCon.Pay(tower.UpgradeCost);
		tower.LevelUp();

		updateStatus();
	}

	public void Refund()
	{
		var moneyCon = Singleton.GetInstance<MoneyController>();

		moneyCon.Recieve(tower.Refund);
		Destroy(tower.gameObject);
	}
}
