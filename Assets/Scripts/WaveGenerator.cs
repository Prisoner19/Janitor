using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveGenerator : MonoBehaviour 
{
	public GameObject pfbDude;

	private List<GameObject> dudesList;
	private bool ready;

	// Use this for initialization
	void Start () 
	{
		ready = true;
		dudesList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ready == true)
		{
			StartCoroutine("Generate_Dude");
		}
	}

	private IEnumerator Generate_Dude()
	{
		ready = false;
		dudesList.Add((Instantiate(pfbDude, new Vector3(50 * dudesList.Count, 0, 0), Quaternion.identity) as GameObject));
		yield return new WaitForSeconds(2);
		ready = true;
	}
}
