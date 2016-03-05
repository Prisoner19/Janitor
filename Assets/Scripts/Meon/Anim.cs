using UnityEngine;
using System.Collections;

namespace Meon
{
	public class Anim : MonoBehaviour 
	{
		private Animator animation_controller;

		private Info scr_meon; 

		void Awake()
		{
			animation_controller = gameObject.GetComponent<Animator>();
		}

		// Update is called once per frame
		void Update () 
		{
		
		}

		public void Set_Walking_Animation(Direction dir)
		{
			animation_controller.SetInteger("direction", (int)dir);
			animation_controller.SetBool("isIdle", false);

		}

		public void Set_Idle_Animation(Direction dir)
		{
			animation_controller.SetInteger("direction", (int)dir);
			animation_controller.SetBool("isIdle", true);
		}

		public void Set_Direction(Direction dir)
		{
			animation_controller.SetInteger("direction", (int)dir);
		}

		public Info Get_Meon()
		{
			return scr_meon;
		}

		public void Set_Meon(Info meon)
		{
			scr_meon = meon;
		}
	}
}