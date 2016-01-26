using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manager
{
	public class SinkManager : MonoBehaviour 
	{
		private static SinkManager instance;
		
		private List<Sink> list_sink;

		public GameObject pfb_sink;
		public int num_sinks;
		
		private void Awake()
		{
			instance = this;
		}
		
		public void Initialize()
		{
			list_sink = new List<Sink>();
			Spawn_Sinks();
		}
		
		private void Spawn_Sinks()
		{
			for(int i = 0; i < num_sinks; i++)
			{
				GameObject go_sink = Instantiate(pfb_sink) as GameObject;
				go_sink.SetPositionXY(800, 300 *  (list_sink.Count - num_sinks/2));
				
				list_sink.Add(go_sink.GetSink());
			}
		}
		
		public static SinkManager Instance 
		{
			get { return instance; }
		}
	}
}