using System;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
	static DateTime StartTime;
	public static int MinutesPerDay = 3;
	public static int TotalDays = 10;

	public static int TotalTicks
	{
		get
		{
			return 180000 * TotalDays;
		}
	}
	
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

	//There are 180000 ticks in a day
	//90000 ticks for day and 9000 ticks for night
	//1500 ticks per real-world second
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

	public static int GetTotalTickCount()
	{
		return (180000 * GetDay()) + GetTick();
	}
}
