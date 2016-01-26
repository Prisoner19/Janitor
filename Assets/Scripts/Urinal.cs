using UnityEngine;
using System.Collections;

public class Urinal : MonoBehaviour
{
	private bool is_occupied;

	private GameObject go_meon;

	private void Start()
	{
		is_occupied = false;

		go_meon = null;
	}

	public bool Try_To_Assign_Meon(GameObject go_meon)
	{
		if(is_occupied == false)
		{
			this.go_meon = go_meon;
			is_occupied = true;
			return true;
		}

		return false;
	}

	public void Unassign_Meon()
	{
		is_occupied = false;
		go_meon = null;
	}
}
