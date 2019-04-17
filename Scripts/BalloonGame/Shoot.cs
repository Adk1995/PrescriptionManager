using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public float speed=3;

	// Use this for initialization
	void Start () {
        StartCoroutine(deleteAfterTime());
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

    }

    IEnumerator deleteAfterTime()
    {
        yield return new WaitForSeconds(5);
        //Destroy(this.gameObject);
    }
}
