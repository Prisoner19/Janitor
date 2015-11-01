using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(InputTracker.Has_Clicked(Mouse_Button.Left))
		{
			Debug.Log(InputTracker.Get_Clicked_Object().name);
		}
	}
}
