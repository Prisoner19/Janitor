using UnityEngine;
using System.Collections;

namespace Manager
{
	public class InputManager : MonoBehaviour 
	{
		private static InputManager instance;

		private GameObject go_meon_clicked;
	
		//--------METHODS--------

		private void Awake()
		{
			instance = this;
		}

		public void Initialize()
		{
			go_meon_clicked = null;
		}

		private void Update () 
		{
			Check_Meon_Click();
			Check_Meon_Drag();
			Check_Meon_Release();
		}

		private void Check_Meon_Click()
		{
			if(InputTracker.Has_Clicked(Mouse_Button.Left))
			{
				go_meon_clicked = InputTracker.Get_Object_Under_Mouse("Meones");

				if(go_meon_clicked != null)
				{
					if(go_meon_clicked.GetMeon().Current_state == MeonState.Peeing)
					{
						go_meon_clicked.GetMeon().Receive_Poke();
						go_meon_clicked = null;
					}
					else if(go_meon_clicked.GetMeon().Current_state == MeonState.Washing_hands)
					{
						go_meon_clicked = null;
					}
				}
			}
		}

		private void Check_Meon_Drag()
		{
			if(go_meon_clicked != null)
			{
				if(InputTracker.Is_Clicking(Mouse_Button.Left))
				{
					go_meon_clicked.Set_To_Mouse_Position();					
					Check_Urinal_Collision();
					Check_Sink_Collision();
				}
			}
		}

		private bool Check_Urinal_Collision()
		{
			if(go_meon_clicked != null)
			{
				if(go_meon_clicked.GetMeon().Current_state == MeonState.Needs_to_pee)
				{
					GameObject go_urinal = InputTracker.Get_Object_Under_Mouse("Urinales");
					Urinal obj_urinal = null;
					bool success = false;
					
					if(go_urinal != null)
					{
						obj_urinal = go_urinal.GetUrinal();
						
						success = obj_urinal.Try_To_Assign_Meon(go_meon_clicked);
						
						if(success == true)
						{
							Debug.Log("hola");
							go_meon_clicked.GetMeon().Try_To_Assign_Urinal(go_urinal);
							go_meon_clicked = null;
						}
					}
					
					return success;
				}
			}

			return false;
		}

		private bool Check_Sink_Collision()
		{
			if(go_meon_clicked != null)
			{
				if(go_meon_clicked.GetMeon().Current_state == MeonState.Finished_peeing)
				{
					GameObject go_sink = InputTracker.Get_Object_Under_Mouse("Sinks");
					Sink obj_sink = null;
					bool success = false;
					
					if(go_sink != null)
					{
						obj_sink = go_sink.GetSink();
						
						success = obj_sink.Try_To_Assign_Meon(go_meon_clicked);
						
						if(success == true)
						{
							go_meon_clicked.GetMeon().Try_To_Assign_Sink(go_sink);
							go_meon_clicked = null;
						}
					}
					
					return success;
				}
			}
			
			return false;
		}

		private void Check_Meon_Release()
		{
			if(go_meon_clicked != null)
			{
				if(InputTracker.Has_Released_Click(Mouse_Button.Left))
				{
					go_meon_clicked = null;
				}
			}
		}
		
		public static InputManager Instance 
		{
			get { return instance; }
		}
	}
}