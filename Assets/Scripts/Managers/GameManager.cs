using UnityEngine;
using System.Collections;

namespace Manager
{
	public class GameManager : MonoBehaviour 
	{
		private static GameManager instance;

		public float tile_width;
		public float tile_height;
		public float grid_scale;

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
