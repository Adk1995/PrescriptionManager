using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour {

    public GameObject World;
    public FauxGravityAttractor attractor;
    private Transform myTransform;
    Rigidbody rbody;

	// Use this for initialization
	void Start () { 
        rbody = GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotation;
        rbody.useGravity = false;
        myTransform = GetComponent<Rigidbody>().transform;	
	}
	
	// Update is called once per frame
	void Update () {
        World.GetComponent<FauxGravityAttractor>().Attract(myTransform);
        //attractor.Attract(myTransform);
	}
}
