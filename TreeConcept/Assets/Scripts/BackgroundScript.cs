using UnityEngine;
using System.Collections;
using System;

public class BackgroundScript : MonoBehaviour
{
	// Use this for initialization
	void Start() { }

	float lastTick = 0f;

	// Update is called once per frame
	void Update()
	{
		float currentTick = TimeScript.GetTick();
		var tickDifference = currentTick - lastTick;
		tickDifference = tickDifference < 0 ? currentTick : tickDifference;
		lastTick = currentTick;

		transform.Rotate(0f, 0f, tickDifference / 1000f);
	}
}
