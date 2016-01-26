using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manager
{
	public class UrinalManager : MonoBehaviour 
	{
		private static UrinalManager instance;

		private List<Urinal> list_urinal;

		public GameObject pfb_urinal;
		public int num_urinals;

		private void Awake()
		{
			instance = this;
		}

		public void Initialize()
		{
			list_urinal = new List<Urinal>();
			Spawn_Urinals();
		}

		private void Spawn_Urinals()
		{
			for(int i = 0; i < num_urinals; i++)
			{
				GameObject go_urinal = Instantiate(pfb_urinal) as GameObject;
				go_urinal.SetPositionXY(200 * (list_urinal.Count - num_urinals/2), 300);

				list_urinal.Add(go_urinal.GetUrinal());
			}
		}

		public static UrinalManager Instance 
		{
			get { return instance; }
		}
	}
}