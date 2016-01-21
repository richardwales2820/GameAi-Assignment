using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float playerSpeed = 1;
    public float playerRotationSpeed = 45;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float currentAngle = transform.eulerAngles.z;

        Debug.Log("Sin: " + Mathf.Sin(Mathf.Deg2Rad * currentAngle) + " *** Cos: " + Mathf.Cos(Mathf.Deg2Rad * currentAngle));

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x + playerSpeed * -Mathf.Sin(Mathf.Deg2Rad * currentAngle), 
                transform.position.y + playerSpeed * Mathf.Cos(Mathf.Deg2Rad * currentAngle), 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, playerRotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -playerRotationSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x - playerSpeed * -Mathf.Sin(Mathf.Deg2Rad * currentAngle),
                transform.position.y - playerSpeed * Mathf.Cos(Mathf.Deg2Rad * currentAngle), 0);
        }
    }
}
