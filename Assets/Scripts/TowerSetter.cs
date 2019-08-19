using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject TowerObj;

	private Tilemap fieldTile;

	private Transform preview;
	private SpriteRenderer previewRenderer;

    // Start is called before the first frame update
    void Start()
    {
		fieldTile = GetComponent<Tilemap>();
		preview = transform.Find("TowerPreview");
		previewRenderer = preview.GetComponent<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
		var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var mouseInField = fieldTile.WorldToCell(mouseInWorld);
		var anchoredPos = mouseInField + new Vector3(0.5f, 0.5f);

		bool settable = fieldTile.HasTile(mouseInField);

		preview.gameObject.SetActive(settable);
		if (settable)
		{
			preview.position = anchoredPos;
		}
		
		if (Input.GetMouseButtonDown(0))
		{
			if (!settable)
			{
				return;
			}

			buildTower(anchoredPos);
		}
    }

	private void buildTower(Vector3 pos)
	{
		var moneyController = Singleton.GetInstance<MoneyController>();
		var towerType = Type.GetType(previewRenderer.sprite.name + "Tower");

		var tower = TowerObj.AddComponent(towerType) as TowerBase;
		if (!moneyController.SettableTower(tower))
		{
			return;
		}

		// タワーを設置
		TowerObj.GetComponent<SpriteRenderer>().sprite = previewRenderer.sprite;
		Instantiate(TowerObj, pos, Quaternion.identity, transform);
		moneyController.Pay(tower.Cost);
	}
}
