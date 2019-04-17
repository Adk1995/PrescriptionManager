﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.00001f;
    private Vector3 moveDir;
    public GameObject camera1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDir = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), 0, CrossPlatformInputManager.GetAxisRaw("Vertical")).normalized;
	}

    void FixedUpdate()
    {
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + GetComponent<Rigidbody>().transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);    
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - camera1.GetComponent<Rigidbody>().transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
    }
}
