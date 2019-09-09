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
	private GameObject cursor;

	private TowerBase tower, previewTower;
	private MoneyController moneyCon;

	private bool onField = false;

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

		cursor = GameObject.FindWithTag("Cursor");

		moneyCon = Singleton.GetInstance<MoneyController>();
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButton(0))
		{
			// マウス上にあるオブジェクトを取得
			var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

			if (hit.collider == null)
			{
				return;
			}

			cursor.transform.position = hit.collider.gameObject.transform.position;
			cursor.SetActive(true);
			tower = hit.collider.gameObject.GetComponent<TowerBase>();

			updateStatus();
		}

		if(onField)
		{
			upgradeBtn.interactable = (tower.UpgradeCost <= moneyCon.Data);
		}
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
			var renderer = tower.gameObject.GetComponent<SpriteRenderer>();
			preview.sprite = renderer.sprite;
			preview.color = renderer.color;

			deleteBtn.interactable = true;
			onField = true;
		}
		else
		{
			// 設置前のプレビュータワー
			previewTower = tower;
			preview.sprite = tower.gameObject.GetComponent<Image>().sprite;
			preview.color = Color.white;

			inactiveUI();
		}
	}

	public void Upgrade()
	{
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

		tower = previewTower;
		updateStatus();

		inactiveUI();
	}

	private void inactiveUI()
	{
		cursor.SetActive(false);
		upgradeBtn.interactable = false;
		deleteBtn.interactable = false;
		onField = false;
	}
}
