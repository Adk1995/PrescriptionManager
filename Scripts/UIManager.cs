using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button male, female;
    public bool flag_male;
    public RectTransform WelcomePanel, GenderPanel, AgePanel, MedsPanel;

    public InputField mname, fname, age, meds;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void transition1()
    {
        WelcomePanel.DOAnchorPos(new Vector2(0,1100), 0.25f);
        GenderPanel.DOAnchorPos(new Vector2(0,0), 0.25f);
    }

    public void transition2()
    {
        if (flag_male)
        {
            PlayerPrefs.SetString("Gender", "Male");
            PlayerPrefs.SetString("Name", mname.text);
            GenderPanel.DOAnchorPos(new Vector2(-202, 1100), 0.25f);
        }
        else
        {
            PlayerPrefs.SetString("Gender", "Female");
            PlayerPrefs.SetString("Name", fname.text);
            GenderPanel.DOAnchorPos(new Vector2(245, 1100), 0.25f);
        }
        AgePanel.DOAnchorPos(new Vector2(0,0), 0.25f);
    }

    public void transition3()
    {
        PlayerPrefs.SetInt("Age", int.Parse(age.text));
        AgePanel.DOAnchorPos(new Vector2(0,1100), 0.25f);
        MedsPanel.DOAnchorPos(new Vector2(0,0),0.25f);
    }

    public void transition_male()
    {
        flag_male = true;
        GenderPanel.DOAnchorPos(new Vector2(-202,0), 0.25f);
    }

    public void transition_female()
    {
        flag_male = true;
        GenderPanel.DOAnchorPos(new Vector2(245, 0), 0.25f);
    }

    public void back()
    {
        GenderPanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void changeScene()
    {
        PlayerPrefs.SetInt("Meds", int.Parse(meds.text));
        SceneManager.LoadScene("Second Scene");
    }
}
