using UnityEngine;
using System.Collections;

namespace Manager
{
	public class GameManager : MonoBehaviour 
	{
		private static GameManager instance;

		private void Awake()
		{
			instance = this;
		}

		void Start () 
		{
			InputManager.Instance.Initialize();
			UrinalManager.Instance.Initialize();
			SinkManager.Instance.Initialize();
			MeonManager.Instance.Initialize();
		}

		public static GameManager Instance {
			get {
				return instance;
			}
		}
	}
}
