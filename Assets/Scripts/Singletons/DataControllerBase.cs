using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataControllerBase : Singleton
{ 
	protected DataControllerBase() { }

	private int data;
	public int Data
	{
		get => data;
		set
		{
			data = value;
			DataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
	
	public event EventHandler DataChanged;
}
