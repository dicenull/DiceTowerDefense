using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public abstract class EnemyBase : MonoBehaviour
{
	public abstract float Speed { get; }

	public abstract int Money { get; }

	protected abstract float hp { get; set; }
	public float Hp { get => hp; }

	Tilemap tilemap;
	Slider hpSlider;
	Tile baseTile;
	Vector3Int direction = Vector3Int.down;
	float moveAmount = 0f;

	private void Awake()
	{
		tilemap = transform.parent.parent.GetComponent<Tilemap>();
	}

	private void Start()
	{
		baseTile = Resources.Load<Tile>("Images/base");

		hpSlider = transform.Find("Canvas/HpBar").GetComponent<Slider>();
		hpSlider.maxValue = hp;
		hpSlider.value = hp;
	}

	public void DamageFrom(TowerBase tower)
	{
		hp -= tower.Power;
		hpSlider.value = hp;

		if (hp <= 0)
		{
			MoneyController.Instance.Recieve(Money);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
    {
		var currentPos = tilemap.LocalToCell(transform.position);

		if(tilemap.GetTile(currentPos) == baseTile)
		{
			GameHpController.Instance.Damage();
			Destroy(gameObject);
			return;
		}

		if (moveAmount > 1f)
		{
			
			// 進行方向一つ先のタイル座標
			var nextPos =  currentPos + direction;

			// 壁のないほうへ方向転換する
			if (tilemap.HasTile(nextPos))
			{
				if (tilemap.HasTile(currentPos + direction.RotatedRight()))
				{
					// 左に回転
					direction.RotateLeft();
					transform.Rotate(0, 0, -90);
				}
				else
				{
					// 右に回転
					direction.RotateRight();
					transform.Rotate(0, 0, 90);
				}

			}

			moveAmount = 0f;
		}

		Move();
	}

	private void Move()
	{
		var amount = Speed * Time.deltaTime;

		transform.position += (Vector3)direction * amount;
		moveAmount += amount;
	}
}
