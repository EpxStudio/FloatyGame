using UnityEngine;
using System.Collections.Generic;
using System;

public class IslandRockScript : MonoBehaviour
{
	static List<IslandRockScript> Rocks;

	// Use this for initialization
	void Start()
	{
		if (Rocks == null) Rocks = new List<IslandRockScript>();

		Rocks.Add(this);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	/// <summary>
	/// When the rock needs to leave the scene.
	/// Island deterioration.
	/// </summary>
	public void FuckOff()
	{

	}

	float GetDistanceFromCenter()
	{
		return Math.Abs(transform.localPosition.x);
	}

	public static IslandRockScript GetFurthestRock()
	{
		if (Rocks == null) throw new Exception();

		var toReturn = Rocks[0];
		foreach (var r in Rocks)
		{
			if (r.GetDistanceFromCenter() > toReturn.GetDistanceFromCenter()) toReturn = r;
		}

		return toReturn;
	}
}
