using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction
{
	Dir45 = 45,
	Dir135 = 135,
	Dir225 = 225,
	Dir315 = 315
}

public struct MovementNode
{
	public int distance;
	public Direction direction;

	public MovementNode(int distance, Direction direction)
	{
		this.distance = distance;
		this.direction = direction;
	}
}

namespace Meon
{
	public class Movement : MonoBehaviour 
	{
		private int x;
		private int y;

		private Info scr_meon;

		private List<MovementNode> movement_list;

		private Direction current_direction;

		private float speed = 175;
		private bool isMoving = false;
		private Vector3 destination;

		private float tile_width;
		private float tile_height;
		private float grid_scale;

		// Use this for initialization
		void Start () 
		{
			tile_width = Manager.GameManager.Instance.tile_width;
			tile_height = Manager.GameManager.Instance.tile_height;
			grid_scale = Manager.GameManager.Instance.grid_scale;

			current_direction = Direction.Dir45;

			movement_list = new List<MovementNode>();
		}
		
		// Update is called once per frame
		void Update () 
		{
			if(isMoving)
			{
				Debug.Log("Moving from " + transform.position + " / " + destination);
				float step = speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, destination, step);
				Check_Arrival();
			}
		}

		public void Set_Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		private void Move_Distance(int distance, Direction dir)
		{
			isMoving = true;
			current_direction = dir;
			scr_meon.Get_Anim().Set_Walking_Animation(dir);

			destination = transform.position + distance * grid_scale * new Vector3(tile_width/2, tile_height/2);
		}

		private void Check_Arrival()
		{
			if(transform.position == destination)
			{
				isMoving = false;
				//scr_meon.Get_Anim().Set_Idle_Animation(current_direction);
			}
		}

		public void Move_Out_From_Scene()
		{
			movement_list.Clear();
			movement_list.Add(new MovementNode(1, Direction.Dir135));
			movement_list.Add(new MovementNode(5 - scr_meon.Place_index + 1, Direction.Dir45));
			movement_list.Add(new MovementNode(2, Direction.Dir315));

			StartCoroutine(Start_Movement());
		}

		private IEnumerator Start_Movement()
		{
			foreach(MovementNode mn in movement_list)
			{
				isMoving = true;
				scr_meon.Get_Anim().Set_Walking_Animation(mn.direction);
				destination = transform.position + mn.distance * grid_scale * new Vector3(tile_width/2 * Get_Direction_Factors(mn.direction).x, tile_height/2 * Get_Direction_Factors(mn.direction).y);
				yield return new WaitUntil(() => isMoving == false);
			}
		}

		private Vector2 Get_Direction_Factors(Direction dir)
		{
			switch(dir)
			{
				case Direction.Dir45: return new Vector2(1, -1);
				case Direction.Dir135: return new Vector2(-1, -1);
				case Direction.Dir225: return new Vector2(-1, 1);
				case Direction.Dir315: return new Vector2(1, 1);
			}

			return Vector2.one;
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