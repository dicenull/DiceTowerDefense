using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSetter : MonoBehaviour
{
	[SerializeField]
	private GameObject TowerObj;

	private Tilemap fieldTile;

    // Start is called before the first frame update
    void Start()
    {
		fieldTile = GetComponent<Tilemap>();
    }
	
    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			var fieldPos = fieldTile.WorldToCell(mousePoint);

			if (!fieldTile.HasTile(fieldPos))
			{
				return;
			}

			var moneyController = MoneyController.Instance;
			var tower = TowerObj.GetComponent<TowerBase>();
			if(!moneyController.SettableTower(tower))
			{
				return;
			}

			// タワーを設置
			var anchoredPos = fieldPos + new Vector3(0.5f, 0.5f);
			Instantiate(TowerObj, anchoredPos, Quaternion.identity, transform);
			moneyController.UseMoney(tower.Cost);
		}
    }
}
