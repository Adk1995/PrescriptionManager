using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public GameObject male, female;
    public bool m, f;

    public Animator malcom, stefani;

    // Use this for initialization
    void Start()
    {

        malcom = male.GetComponent<Animator>();
        stefani = female.GetComponent<Animator>();
        male.SetActive(false);
        female.SetActive(false);
        if (PlayerPrefs.GetString("Gender").ToLower() == "male" || PlayerPrefs.GetString("Gender").ToLower() == "m")
        {
            male.SetActive(true);
            m = true;
            f = false;
        }
        else
        {
            female.SetActive(true);
            f = true;
            m = false;
        }

        Invoke("Greet", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Greet()
    {
        if (m)
        {
            malcom.SetInteger("AnimC", 1);
            //malcom.SetInteger("AnimC", 0);
        }
        else
        {
            stefani.SetInteger("AnimC", 1);
            //stefani.SetInteger("AnimC", 0);
        }
        Invoke("StopGreet", 4.0f);
    }

    void StopGreet()
    {
        if (m)
        {
            malcom.SetInteger("AnimC", 0);
        }
        else
        {
            stefani.SetInteger("AnimC", 0);
        }
    }
}
