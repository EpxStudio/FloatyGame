using UnityEngine;
using System.Collections;

public class FlipperScript : MonoBehaviour
{
	public GameObject ToFlip;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.GetComponent<PlayerScript>() != null)
		{
			Debug.Log("collisioned!");
			ToFlip.transform.Rotate(new Vector3(180, 0, 0));
		}
	}
}
