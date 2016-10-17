using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class IslandScript : MonoBehaviour
{
	List<GameObject> Rocks = new List<GameObject>();
	int totalRocks;
	int ticksPerRock;
	int deletedRocks = 0;

	// Use this for initialization
	void Start()
	{
		foreach (Transform t in transform)
		{
			Rocks.Add(t.gameObject);
		}

		totalRocks = Rocks.Count;
		ticksPerRock = TimeScript.TotalTicks / totalRocks;

		Debug.Log(totalRocks);
		Debug.Log(ticksPerRock);
	}
	
	// Update is called once per frame
	void Update()
	{
		Debug.Log("Ticks: " + TimeScript.GetTotalTickCount());
		Debug.Log("Next barrier: " + deletedRocks * ticksPerRock);
		if (TimeScript.GetTotalTickCount() > deletedRocks * ticksPerRock)
		{
			var farthest = Rocks[0];

			foreach (var o in Rocks)
			{
				if (Math.Abs(o.transform.localPosition.x) > Math.Abs(farthest.transform.localPosition.x))
				{
					farthest = o;
				}
			}

			farthest.GetComponent<Rigidbody2D>().isKinematic = false;
			Rocks.Remove(farthest);
			deletedRocks++;
		}
	}
}
