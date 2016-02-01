using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pieslice : MonoBehaviour {

	public Text sliceText;
	public TextMesh pieNum;
	int agents = 0;
	//private bool agent1In, agent2In;

	// Use this for initialization
	void Start () {
		agents = 0;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		agents++;
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		agents--;
	}

	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (agents);

		if (sliceText != null)
			sliceText.text = sliceText.tag + " level " + agents;

		if (pieNum != null) {
			if (agents > 0)
				pieNum.color = new Color (255f, 0f, 0f, 1f);
			else
				pieNum.color = new Color (255f, 255f, 255f, 1f);
		}
	}
}
