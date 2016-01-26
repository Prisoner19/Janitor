using UnityEngine;
using System.Collections;

public enum MeonState
{
	Needs_to_pee,
	Peeing,
	Finished_peeing,
	Washing_hands,
	Finished_washing
}

public class Meon : MonoBehaviour
{
	public float time_to_pee;
	public float time_washing_hands;
	public float initial_happiness;

	private float current_happiness;

	private GameObject go_urinal;
	private GameObject go_sink;

	private Vector3 initial_pos;

	private MeonState current_state;
	
	#region Placeholder

	private GameObject go_text;

	private Sprite spr_peeing;
	private Sprite spr_needs_to_pee;
	private Sprite spr_finished_peeing;
	private Sprite spr_washing_hands;
	private Sprite spr_finished_washing;
	
	#endregion

	private void Start()
	{
		current_happiness = initial_happiness;

		initial_pos = gameObject.transform.position;

		current_state = MeonState.Needs_to_pee;

		go_urinal = null;

		go_text = new GameObject("Text");
		go_text.transform.parent = this.gameObject.transform;
		go_text.SetLocalPositionXY(0,50);

		spr_peeing = Resources.Load("Sprites/Text Boxes/spr_peeing", typeof(Sprite)) as Sprite;
		spr_needs_to_pee = Resources.Load("Sprites/Text Boxes/spr_needs_to_pee", typeof(Sprite)) as Sprite;
		spr_finished_peeing = Resources.Load("Sprites/Text Boxes/spr_finished_peeing", typeof(Sprite)) as Sprite;
		spr_washing_hands = Resources.Load("Sprites/Text Boxes/spr_washing_hands", typeof(Sprite)) as Sprite;
		spr_finished_washing = Resources.Load("Sprites/Text Boxes/spr_finished_washing", typeof(Sprite)) as Sprite;

		go_text.AddComponent<SpriteRenderer>().sprite = spr_needs_to_pee;
		go_text.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}

	private void Update()
	{
		if(Current_state == MeonState.Needs_to_pee)
		{
			current_happiness -= 5 * Time.deltaTime;
		}
		else if(Current_state == MeonState.Finished_peeing)
		{
			current_happiness -= 3 * Time.deltaTime;
		}

		Update_Happiness_Indicator();
	}

	public void Try_To_Assign_Urinal (GameObject go_urinal)
	{
		if(current_state == MeonState.Needs_to_pee)
		{
			gameObject.Set_Position_To(go_urinal);
			StartCoroutine(Start_To_Pee());

			this.go_urinal = go_urinal;
		}
	}

	public void Try_To_Assign_Sink (GameObject go_sink)
	{
		if(current_state == MeonState.Finished_peeing)
		{
			gameObject.Set_Position_To(go_sink);
			StartCoroutine(Start_Washing_Hands());
			
			this.go_sink = go_sink;
		}
	}

	public void Receive_Poke ()
	{
		current_happiness = 25;
	}

	private void Update_Happiness_Indicator()
	{
		if(current_happiness < 30)
		{
			if(Get_Color() != Color.red)
			{
				Set_Color(Color.red);
				Manager.GameManager.Instance.gameObject.GetComponent<AudioSource>().Play();
			}
		}
		else if(current_happiness < 70)
		{
			if(Get_Color() != Color.yellow)
			{
				Set_Color(Color.yellow);
			}
		}
		else
		{
			if(Get_Color() != Color.green)
			{
				Set_Color(Color.green);
			}
		}
	}

	private IEnumerator Start_To_Pee()
	{
		current_happiness += 10;
		current_state = MeonState.Peeing;

		go_text.GetComponent<SpriteRenderer>().sprite = spr_peeing;

		yield return new WaitForSeconds(time_to_pee);

		go_urinal.GetUrinal().Unassign_Meon();
		current_state = MeonState.Finished_peeing;
		current_happiness += 10;

		go_text.GetComponent<SpriteRenderer>().sprite = spr_finished_peeing;
	}

	private IEnumerator Start_Washing_Hands()
	{
		current_happiness += 10;
		current_state = MeonState.Washing_hands;
		
		go_text.GetComponent<SpriteRenderer>().sprite = spr_washing_hands;
		
		yield return new WaitForSeconds(time_washing_hands);

		go_sink.GetSink().Unassign_Meon();
		current_state = MeonState.Finished_washing;
		current_happiness += 10;
		
		go_text.GetComponent<SpriteRenderer>().sprite = spr_finished_washing;
	}

	public void Send_To_Queue()
	{
		gameObject.transform.position = initial_pos;
	}

	private void Set_Color(Color c)
	{
		gameObject.GetComponent<SpriteRenderer>().color = c;
	}

	private Color Get_Color()
	{
		return gameObject.GetComponent<SpriteRenderer>().color;
	}

	public MeonState Current_state {
		get {
			return current_state;
		}
	}
}
