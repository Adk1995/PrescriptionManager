using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTouch : MonoBehaviour {
    public Text text;
    public GameObject dart;
    public Camera main;
    public Transform origin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount>0&&Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Vector3 n = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10);
            Vector3 p = Camera.main.ScreenToWorldPoint( n);
            Vector3 pos = new Vector3(0,0,1);
            GameObject bul = Instantiate(dart, origin.position, Quaternion.identity);
           //bul.transform.position = transform.position + Camera.main.transform.forward * 2;
            text.text = origin.position.ToString();
        }
	}
}
