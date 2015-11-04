using UnityEngine;
using System.Collections;

public class Pee : MonoBehaviour 
{


	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "Urinal")
		{
			transform.position = collision.gameObject.transform.position;
		}
	}
}
