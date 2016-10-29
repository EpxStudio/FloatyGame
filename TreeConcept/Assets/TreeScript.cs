using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeScript : MonoBehaviour
{
	public GameObject toClone;

	static List<GameObject> SpawnedCircles;

	// Use this for initialization
	void Start()
	{
	}

	bool hasSpawned = false;
	
	// Update is called once per frame
	void Update()
	{
		if ((TimeScript.GetTotalTickCount() / 18) % 100 == 0)
		{
			if (!hasSpawned)
			{
				hasSpawned = true;
				if (SpawnedCircles == null)
				{
					SpawnedCircles = new List<GameObject>();
				}

				var newObject = Instantiate(toClone);
				newObject.transform.position = new Vector3(0, 0, 0);
				SpawnedCircles.Add(newObject);

				if (SpawnedCircles.Count > 5)
				{
					var toDelete = SpawnedCircles[0];
					SpawnedCircles.RemoveAt(0);
					Destroy(toDelete);
				}
			}
		}
		else
		{
			hasSpawned = false;
		}
	}
}
