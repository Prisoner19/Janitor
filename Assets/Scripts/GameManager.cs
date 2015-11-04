using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	private Vector3 screenPoint;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(InputTracker.Has_Clicked(Mouse_Button.Left) && InputTracker.Get_Clicked_Object("Meones"))
		{
			screenPoint = Camera.main.WorldToScreenPoint(InputTracker.Get_Clicked_Object().gameObject.transform.position);
		}

		if(InputTracker.Is_Clicking(Mouse_Button.Left) && InputTracker.Get_Clicked_Object("Meones"))
		{
			Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
			Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentScreenPosition);
			InputTracker.Get_Clicked_Object().gameObject.transform.position = currentPos;
		}

	}
}
