using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] balloons;
    public Vector3 spawnValues;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float spawnWait;
    public int startWait;
    public bool stop;
    int randEnemy;
    public int balloonCount = 0;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(startWait);

        while (balloonCount<=20)
        {
            //randEnemy = Random.Range(0, 2);
            int x = Random.Range(0, 2);
            float spawnX;
            float spawnZ;
            if(x==1)
            {
                spawnX = Random.Range(0.5f, spawnValues.x);

            }
            else
            {
                spawnX = Random.Range(0.5f, -spawnValues.x);

            }
            x = Random.Range(0, 2);
            if (x == 1)
            {
                spawnZ = Random.Range(0.5f, spawnValues.z);

            }
            else
            {
                spawnZ = Random.Range(-0.5f, -spawnValues.z);

            }
            Vector3 spawnPos = new Vector3(spawnX, Random.Range(-spawnValues.y-1, spawnValues.y-1), spawnZ);
            int balloonColor = Random.Range(0, 4);
            Instantiate(balloons[balloonColor], spawnPos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            balloonCount += 1;
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
