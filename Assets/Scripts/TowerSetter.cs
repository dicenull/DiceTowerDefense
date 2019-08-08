using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSetter : MonoBehaviour
{
	[SerializeField]
	private Tilemap FieldTile;

	[SerializeField]
	private Tilemap TowerTile;

    // Start is called before the first frame update
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
		{
			var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			var fieldPos = FieldTile.WorldToCell(mousePoint);
			var towerPos = TowerTile.WorldToCell(mousePoint);

			if(FieldTile.HasTile(fieldPos))
			{
				TowerTile.SetTile(towerPos, new LaserTower());
			}
		}
    }
}
