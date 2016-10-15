using System;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
	static DateTime StartTime;
	public static int MinutesPerDay = 3;
	
	// Use this for initialization
	void Start()
	{
		StartTime = DateTime.Now;
		Debug.Log("Started TimeScript");
	}

	// Update is called once per frame
	void Update() { }

	public static int GetDay()
	{
		return Convert.ToInt32(
			Math.Floor(
				Convert.ToDouble(
					DateTime.Now.Subtract(StartTime).Minutes / MinutesPerDay
				)
			)
		);
	}

	//There are 18000 ticks in a day
	//9000 ticks for day and 9000 ticks for night
	//150 ticks per real-world second
	public static int GetTick()
	{
		var sub = DateTime.Now.Subtract(StartTime);
		return Convert.ToInt32(
			Math.Floor(
				Convert.ToDouble(
					(sub.Milliseconds + (1000 * sub.Seconds) +
						((1000 * MinutesPerDay) *
							(sub.Minutes - (MinutesPerDay *
								Math.Floor(Convert.ToDouble(sub.Minutes / MinutesPerDay))
							))
						)
					) / 10
				)
			)
		);
	}

	public static int GetTotalTick()
	{
		return (18000 * GetDay()) + GetTick();
	}
}
