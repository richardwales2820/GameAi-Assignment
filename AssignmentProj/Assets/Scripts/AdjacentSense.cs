using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdjacentSense : MonoBehaviour {

    // Initialize variables for agents of interest
	public Rigidbody2D agent1, agent2;
	public Text agent1Details, agent2Details;
	bool agent1In, agent2In;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Gets objects within range of Adj Agent Sensor
		Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, 3.2f);

        // Loop through colliders in range of the player
		for (int i = 0; i < collidersInRange.Length; i++) {
			if (collidersInRange[i].attachedRigidbody != null)  // Check if this is a rigid body
			{
				//Sets bool values if agent 1 or 2 was detected
				if (collidersInRange [i].attachedRigidbody == agent1)
					agent1In = true;  // Agent 1 is within the adjacent agent sensor

				if (collidersInRange [i].attachedRigidbody == agent2)
					agent2In = true;  // Agent 2 is within the adjacent agent sensor
			}
		}

		if (agent1In) {
			//Gets distance from player to agent
			float distance = Vector3.Distance (transform.position, agent1.position);

			//This vector is a resultant vector after subtracting one vector from the other
			Vector3 resultant = (Vector3)transform.position - (Vector3)agent1.position;

			//get the smallest angle needed to turn player to agent
			//-1 and the 180 are there to fix rotation issues from sprite
			float relativeHeading = - 1 * (Vector3.Angle(transform.up, resultant) - 180);

			//Change color of agent when in collision
			SpriteRenderer renderer = agent1.GetComponent<SpriteRenderer> ();
			renderer.color = new Color (255f, 255f, 0f, 1f); // Set to yellow

			//Update UI with details
			agent1Details.text = "Agent 1 Distance: " + distance.ToString("F2") + "\nRelative Heading: " + relativeHeading.ToString("F2");
		} 

		//If not in collision, set color to normal and reset text
		else {
			SpriteRenderer renderer = agent1.GetComponent<SpriteRenderer>();
			renderer.color = new Color(255f, 0f, 0f, 255f); // Set to opaque gray

			agent1Details.text = "";
		}

		//Same as agent1 code but with agent2
		if (agent2In) {
			float distance = Vector3.Distance (transform.position, agent2.position);

			Vector3 resultant = (Vector3)transform.position - (Vector3)agent2.position;
			float relativeHeading = - 1 * (Vector3.Angle(transform.up, resultant) - 180);


			SpriteRenderer renderer = agent2.GetComponent<SpriteRenderer> ();
			renderer.color = new Color (0f, 255f, 0f, 1f); // Set to green

			agent2Details.text = "Agent 2 Distance: " + distance.ToString("F2") + "\nRelative Heading: " + relativeHeading.ToString("F2");
		} 
		else {
			SpriteRenderer renderer = agent2.GetComponent<SpriteRenderer>();
			renderer.color = new Color(255f, 0f, 0f, 255f); // Set to opaque gray

			agent2Details.text = "";
		}

		agent1In = false;
		agent2In = false;
	}
}
