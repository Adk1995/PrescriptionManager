using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {
    public Text timer;
    public float total = 30;
    public Image image;
    public TextMeshProUGUI pillMessage;
    public Image backButton;
    public Text backButtonText;
	// Use this for initialization
	void Start () {
        image.enabled = false;
        backButton.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        total = total - Time.deltaTime;
        double total2 = System.Math.Round(total, 2);
        if(total>0)
        {
            timer.text = total2.ToString() + "s";

        }

        if (total<0)
        {
            timer.text = "0.0s";
            image.enabled = true;
            backButton.enabled = true;
            backButtonText.enabled = true;
            pillMessage.text = "Take Your Pills";
        }
	}
}
