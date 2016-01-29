using UnityEngine;
using System.Collections;

public class WallSense : MonoBehaviour {

	public float floatHeight;
	public float liftForce;
	public float damping;
	public Rigidbody2D rb2D;
	public float rayDistance = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		//Gets the angle of the player
		float currentAngle = transform.eulerAngles.z;

		//Initialize vector positions of the rays
		//Uses the same trig as the movement code to cast ray in front of player
		//Left and Right rays have their angles shifted by +- 90 degrees
		Vector3 forwardRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * currentAngle), 
			Mathf.Cos(Mathf.Deg2Rad * currentAngle), transform.position.z);
		Vector3 rightRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * (currentAngle - 90)), 
			Mathf.Cos(Mathf.Deg2Rad * (currentAngle - 90)), transform.position.z);
		Vector3 leftRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * (currentAngle + 90)), 
			Mathf.Cos(Mathf.Deg2Rad * (currentAngle + 90)), transform.position.z);

		//Normalize vectors to only have directions
		forwardRayPos.Normalize ();
		rightRayPos.Normalize ();
		leftRayPos.Normalize ();

		/* This section will host the actual raycasting to check for object detection
		RaycastHit2D hit = Physics2D.Raycast(transform.position, forwardRayPos);

		if (hit.collider != null) {
			float distance = Mathf.Abs(hit.point.y - transform.position.y);
			float heightError = floatHeight - distance;
			float force = liftForce * heightError - rb2D.velocity.y * damping;
			rb2D.AddForce(Vector3.up * force);
		}
		*/

		//Draw lines that extend from the player in their respective directions with a set length
		Debug.DrawLine (transform.position, transform.position + rayDistance * forwardRayPos);
		Debug.DrawLine (transform.position, transform.position + rayDistance * rightRayPos);
		Debug.DrawLine (transform.position, transform.position + rayDistance * leftRayPos);
	}
}
