using UnityEngine;
using System.Collections;

public class AdjacentSense : MonoBehaviour {

	public Rigidbody2D agent1, agent2;
	bool agent1In, agent2In;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, 3.2f);

		for (int i = 0; i < collidersInRange.Length; i++) {
			if (collidersInRange[i].attachedRigidbody != null)
			{
				if (collidersInRange [i].attachedRigidbody == agent1)
					agent1In = true;

				if (collidersInRange [i].attachedRigidbody == agent2)
					agent2In = true;
			}
		}

		if (agent1In) {
			SpriteRenderer renderer = agent1.GetComponent<SpriteRenderer> ();
			renderer.color = new Color (0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
		} 
		else {
			SpriteRenderer renderer = agent1.GetComponent<SpriteRenderer>();
			renderer.color = new Color(255f, 0f, 0f, 255f); // Set to opaque gray
		}

		if (agent2In) {
			SpriteRenderer renderer = agent2.GetComponent<SpriteRenderer> ();
			renderer.color = new Color (0.5f, 0.5f, 0.5f, 1f); // Set to opaque gray
		} 
		else {
			SpriteRenderer renderer = agent2.GetComponent<SpriteRenderer>();
			renderer.color = new Color(255f, 0f, 0f, 255f); // Set to opaque gray
		}

		agent1In = false;
		agent2In = false;

	}
}
