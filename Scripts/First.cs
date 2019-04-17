using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class First : MonoBehaviour {
    public InputField name1, age, gender, tablets;

    public RectTransform patientInfo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save()
    {
        
        PlayerPrefs.SetString("Gender", gender.text);
        PlayerPrefs.SetString("Name", name1.text);
        PlayerPrefs.SetString("Age", age.text);
        PlayerPrefs.SetString("Tablets", tablets.text);

        Debug.Log(age.text);
        Debug.Log(int.Parse(age.text));
        if (int.Parse(age.text) > 18)
            SceneManager.LoadScene("Adult Scene Two");
        else
            SceneManager.LoadScene("Second Scene");
    }

    public void transition()
    {
        patientInfo.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }
}
