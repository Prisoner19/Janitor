using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manager
{
	public class MeonManager : MonoBehaviour 
	{
		private static MeonManager instance;

		public GameObject pfb_meon;
		public int meon_max;
		
		private List<Meon> list_meones;
		private bool is_ready;

		private void Awake()
		{
			instance = this;
		}

		public void Initialize () 
		{
			is_ready = true;
			list_meones = new List<Meon>();
		}
		
		private void Update () 
		{
			if(is_ready == true)
			{
				StartCoroutine("Generate_Meon");
			}
		}
		
		private IEnumerator Generate_Meon()
		{
			if(list_meones.Count < meon_max)
			{
				is_ready = false;

				GameObject go_meon = Instantiate(pfb_meon) as GameObject;
				go_meon.SetPositionXY(100 * (list_meones.Count - meon_max / 2), 0);

				list_meones.Add(go_meon.GetMeon());

				yield return new WaitForSeconds(2);

				is_ready = true;
			}

			yield return null;
		}

		public static MeonManager Instance 
		{
			get { return instance; }
		}
	}
}
