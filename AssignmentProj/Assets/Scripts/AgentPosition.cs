﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AgentPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public Text info;

	// Update is called once per frame
	void Update () {

        // Print the current x- and y-coordinate as well as the agent's heading
        info = gameObject.GetComponent<Text>();
        info.text = gameObject.transform.position.x + "\n" + gameObject.transform.position.y + "\n" + gameObject.transform.eulerAngles;
	}
}
