using UnityEngine;
using System.Collections;

public class AdjacentSense : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Collider2D[] collidersInRange = Physics2D.OverlapCircleAll(transform.position, 3.2f);

		for (int i = 0; i < collidersInRange.Length; i++) {
			if (collidersInRange[i].attachedRigidbody != null)
				Debug.Log (collidersInRange [i].attachedRigidbody);
		}
	}
}
