using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WallSense : MonoBehaviour {

    // Ray Distance
	public float rayDistance = 5;

    // Color of GUI rays (turns a different color when it collides with a collider)
    public Color forwardLineColor, rightLineColor, leftLineColor;
    public Text forwardDistText, rightDistText, leftDistText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void FixedUpdate() {

        float forwardDist = -1;
        float rightDist = -1;
        float leftDist = -1;

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

		//Raycast will only detect layer 8, walls
		LayerMask layerMask = 1 << 8;

        //Check if the rays are colliding with an object; if they are, draw them magenta
		Collider2D forwardCollide = Physics2D.Raycast(transform.position, forwardRayPos, rayDistance, layerMask).collider;
		Collider2D rightCollide = Physics2D.Raycast(transform.position, rightRayPos, rayDistance, layerMask).collider;
		Collider2D leftCollide = Physics2D.Raycast(transform.position, leftRayPos, rayDistance, layerMask).collider;

        if (forwardCollide != null) {
            forwardLineColor = Color.magenta;
            forwardDist = Vector3.Distance(transform.position, forwardCollide.transform.position);

        }

        if (rightCollide != null) {
            rightLineColor = Color.magenta;
            rightDist = Vector3.Distance(transform.position, rightCollide.transform.position);
        }

        if (leftCollide != null) {
            leftLineColor = Color.magenta;
            leftDist = Vector3.Distance(transform.position, leftCollide.transform.position);
        }

        //Draw lines that extend from the player in their respective directions with a set length
        Debug.DrawLine(transform.position, transform.position + rayDistance * forwardRayPos, forwardLineColor);
		Debug.DrawLine(transform.position, transform.position + rayDistance * rightRayPos, rightLineColor);
		Debug.DrawLine(transform.position, transform.position + rayDistance * leftRayPos, leftLineColor);

        if (forwardDist != -1) {
            if (forwardDistText != null) forwardDistText.text = "Forward Sensor: " + forwardDist.ToString("F2");
        } else {
            if (forwardDistText != null) forwardDistText.text = "";
        }

        if (rightDist != -1) {
            if (rightDistText != null) rightDistText.text = "Right Sensor: " + rightDist.ToString("F2");
        } else {
            if (rightDistText != null) rightDistText.text = "";
        }

        if (leftDist != -1) {
            if (leftDistText != null) leftDistText.text = "Left Sensor: " + leftDist.ToString("F2");
        } else {
            if (leftDistText != null) leftDistText.text = "";
        }

        Debug.ClearDeveloperConsole();
	}
}
