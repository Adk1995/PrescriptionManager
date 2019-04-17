using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour {
    public Text text;
    public static int score=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        score += 1;
        text.text ="Score: "+score.ToString();
        if (col.gameObject.tag == "balloon")
        {
            
            Destroy(col.gameObject);
        }
    }
}
