using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton : MonoBehaviour
{
	private static Dictionary<Type, Singleton> instances
		= new Dictionary<Type, Singleton>();

	protected Singleton()
	{
		if(instances.ContainsKey(GetType()))
		{
			throw new InvalidOperationException("インスタンスはすでに生成されています");
		}

		instances.Add(GetType(), this);
	}

	public static T GetInstance<T>()
		where T : Singleton
	{
		if(!instances.ContainsKey(typeof(T)))
		{
			instances[typeof(T)] = GameObject.FindWithTag("Singleton").AddComponent<T>();
		}

		return (T)instances[typeof(T)];
	}

}
