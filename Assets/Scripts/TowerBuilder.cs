using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerBuilder : MonoBehaviour
{
	[SerializeField]
	private GameObject TowerObj = null;

	private GameObject nextTowerObj;

	private Tilemap fieldTile;

	private Transform preview;
	private SpriteRenderer previewRenderer;

    // Start is called before the first frame update
    void Start()
    {
		fieldTile = GetComponent<Tilemap>();
		preview = transform.Find("TowerPreview");
		previewRenderer = preview.GetComponent<SpriteRenderer>();

		buildNextTower();
    }
	
    // Update is called once per frame
    void Update()
    {
		var mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var mouseInField = fieldTile.WorldToCell(mouseInWorld);
		var anchoredPos = mouseInField + new Vector3(0.5f, 0.5f);

		var hit = Physics2D.Raycast(mouseInWorld, Vector3.forward);

		// なにも設置されていない壁であればOK
		bool settable = fieldTile.GetTile(mouseInField) == TileTypes.Wall && hit.collider == null;

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

		// あらかじめ生成しておいたタワーに機能を付与
		var tower = nextTowerObj.AddComponent(towerType) as TowerBase;		
		if (!moneyController.SettableTower(tower))
		{
			Destroy(tower);
			return;
		}

		// タワーを設置
		nextTowerObj.GetComponent<SpriteRenderer>().sprite = previewRenderer.sprite;
		nextTowerObj.transform.position = pos;
		nextTowerObj.SetActive(true);

		// 次のタワーを生成
		buildNextTower();
		
		moneyController.Pay(tower.Cost);
	}

	void buildNextTower()
	{
		nextTowerObj = Instantiate(TowerObj, transform);
		nextTowerObj.SetActive(false);
	}
}
