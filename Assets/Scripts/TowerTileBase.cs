using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public abstract float Range { get; }
	public abstract float Damage { get; }
	public abstract float ReloadTime { get; }
}
