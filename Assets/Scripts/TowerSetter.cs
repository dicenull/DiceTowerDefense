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

    // Start is called before the first frame update
    void Start()
    {
		fieldTile = GetComponent<Tilemap>();
		preview = transform.Find("TowerPreview");
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

			var moneyController = Singleton.GetInstance<MoneyController>();
			var tower = TowerObj.GetComponent<TowerBase>();
			if(!moneyController.SettableTower(tower))
			{
				return;
			}

			// タワーを設置
			Instantiate(TowerObj, anchoredPos, Quaternion.identity, transform);
			moneyController.Pay(tower.Cost);
		}
    }
}
