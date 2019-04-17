using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {
    public Button backButton;
	// Use this for initialization
	void Start () {
        backButton.onClick.AddListener(previousScene);
	}

    private void previousScene()
    {
        Debug.Log("in previous scene");
        SceneManager.LoadScene("Second Scene");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
