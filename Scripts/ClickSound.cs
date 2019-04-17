using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour {

    public GameObject click;

	// Use this for initialization
	void Start () {
        click.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clicked()
    {
        click.SetActive(true);
        Invoke("clickDeactivate", 0.2f);
    }

    void clickDeactivate()
    {
        click.SetActive(false);
    }
}
