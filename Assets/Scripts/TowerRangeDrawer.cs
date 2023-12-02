using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerRangeDrawer : MonoBehaviour
{
	private Tilemap tilemap;
	private GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
		tilemap = GetComponent<Tilemap>();
		circle = transform.Find("Circle").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
		var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var tilemapPoint = tilemap.WorldToCell(mousePoint);
		
		/*
		var tile = tilemap.GetTile(tilemapPoint) as TowerBase;
		if (tile != null)
		{
			circle.SetActive(true);

			circle.transform.position = tilemapPoint;
			circle.transform.position += new Vector3(0.5f, 0.5f);
			circle.transform.localScale = new Vector3(tile.Range, tile.Range);
		}
		else
		{
			circle.SetActive(false);

		}
		*/
    }
}
