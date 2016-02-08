using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pieslice : MonoBehaviour {

    // Initialize Pie Slice Sensor attributes variables
	public Text sliceText;
	public TextMesh pieNum;
	int agents = 0;
	//private bool agent1In, agent2In;

	// Use this for initialization
	void Start () {
		agents = 0;
	}

	//Agent enters slice, agents increments
	void OnTriggerEnter2D(Collider2D collider)
	{
		agents++;
	}

	//Agent leaves slice, agents decrements
	void OnTriggerExit2D(Collider2D collider)
	{
		agents--;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Null checks satisfy unity's weird errors
		//text.tag is there to allow for easy re-use with other slices
		if (sliceText != null)
			sliceText.text = sliceText.tag + " level " + agents; //Changes text to be the amount of agents in slice

		//If agents are in slice, changes color of the slice number labels to red
		if (pieNum != null) {
			if (agents > 0)
				pieNum.color = new Color (255f, 0f, 0f, 1f);
			else
				pieNum.color = new Color (255f, 255f, 255f, 1f);
		}
	}
}
