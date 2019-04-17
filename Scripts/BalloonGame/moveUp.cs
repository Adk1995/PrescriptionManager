using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour {

    // Use this for initialization
    public float speed;
    // Use this for initialization
    void Start()
    {
        
        speed = Random.Range(0.07f, 0.5f);
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(transform.position.y>3)
        {
            speed = Random.Range(0.07f, 0.5f);
            float y = Random.Range(-1, 0);
            float spawnX = Random.Range(-3.0f, 3.0f);
            float spawnY = Random.Range(-3.0f, 3.0f);
            if(spawnX<1||spawnX>-1)
            {
                
            }
            transform.position = new Vector3(transform.position.x, Random.Range(-0.5f, 0.0f), transform.position.z);
        }
    }
}
