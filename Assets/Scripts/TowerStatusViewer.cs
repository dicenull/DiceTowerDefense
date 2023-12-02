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

	private MoneyController moneyCon;

	private TowerBase tower;
	private TowerSelector towerSelector;

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
		towerSelector = GameObject.FindWithTag("TowerSelector").GetComponent<TowerSelector>();
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
	}
	public void UpdateToPreview()
	{
		tower = towerSelector.CurrentTower;

		var sprite = tower.gameObject.GetComponent<Image>().sprite;

		updateStatus(tower, sprite, Color.white);
		inactiveUI();
	}

	private void updateStatus()
	{
		var towerSpriteRen = tower.gameObject.GetComponent<SpriteRenderer>();

		updateStatus(this.tower, towerSpriteRen.sprite, towerSpriteRen.color);
	}


	private void updateStatus(TowerBase tower, Sprite sprite, Color color)
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

		preview.sprite = sprite;
		preview.color = color;

		upgradeBtn.interactable = (tower.UpgradeCost <= moneyCon.Data);
		deleteBtn.interactable = true;
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
		moneyCon.Recieve(tower.Refund);
		Destroy(tower.gameObject);

		UpdateToPreview();
	}

	private void inactiveUI()
	{
		cursor.SetActive(false);
		upgradeBtn.interactable = false;
		deleteBtn.interactable = false;
	}
}
