using UnityEngine;
using System.Collections;

public class WallSense : MonoBehaviour {

    // Ray Distance
	public float rayDistance = 5;

    // Color of GUI rays (turns a different color when it collides with a collider)
    public Color forwardLineColor, rightLineColor, leftLineColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void FixedUpdate() {

		//Gets the angle of the player
		float currentAngle = transform.eulerAngles.z;

		//Initialize vector positions of the rays
		//Uses the same trig as the movement code to cast ray in front of player
		//Left and Right rays have their angles shifted by +- 90 degrees
		Vector3 forwardRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * currentAngle), Mathf.Cos(Mathf.Deg2Rad * currentAngle), transform.position.z);
		Vector3 rightRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * (currentAngle - 90)), Mathf.Cos(Mathf.Deg2Rad * (currentAngle - 90)), transform.position.z);
		Vector3 leftRayPos = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * (currentAngle + 90)), Mathf.Cos(Mathf.Deg2Rad * (currentAngle + 90)), transform.position.z);

		//Normalize vectors to only have directions
		forwardRayPos.Normalize();
		rightRayPos.Normalize();
		leftRayPos.Normalize();

        // Initialize colors to white
        forwardLineColor = Color.white;
        rightLineColor = Color.white;
        leftLineColor = Color.white;

        //Check if the rays are colliding with an object; if they are, draw them magenta
        if (Physics2D.Raycast(transform.position, forwardRayPos, rayDistance).collider != null) forwardLineColor = Color.magenta;
        if (Physics2D.Raycast(transform.position, rightRayPos, rayDistance).collider != null) rightLineColor = Color.magenta;
        if (Physics2D.Raycast(transform.position, leftRayPos, rayDistance).collider != null) leftLineColor = Color.magenta;

        //Draw lines that extend from the player in their respective directions with a set length
        Debug.DrawLine(transform.position, transform.position + rayDistance * forwardRayPos, forwardLineColor);
		Debug.DrawLine(transform.position, transform.position + rayDistance * rightRayPos, rightLineColor);
		Debug.DrawLine(transform.position, transform.position + rayDistance * leftRayPos, leftLineColor);

        Debug.ClearDeveloperConsole();
	}
}
