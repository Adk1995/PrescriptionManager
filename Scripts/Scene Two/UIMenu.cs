using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMenu : MonoBehaviour {

    public GameObject MenuPanel;
    Animator MenuPanelAnim;
    AudioSource bgm;
    public GameObject world;
    public GameObject[] models;
    public TextMeshProUGUI player_name;
    public int age;
    public TextMeshProUGUI gender;

    private void Start()
    {
        bgm = world.GetComponent<AudioSource>();
        MenuPanelAnim = MenuPanel.GetComponent<Animator>();
        player_name.text = PlayerPrefs.GetString("Name");
        age = PlayerPrefs.GetInt("Age");
        //gender.text = PlayerPrefs.GetString("Gender");
        Debug.Log(age);
        if(age>50)
        {
            models[1].SetActive(true);
        }
        else if(age<50&&age>25){
            models[2].SetActive(true);
        }
        else if(age<25 && age>19)
        {
            models[3].SetActive(true);
        }
        else{
            models[0].SetActive(true);
        }
    }

    public void ViewMeds()
    {
        SceneManager.LoadScene("ViewMedications");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ScanMeds()
    {
        SceneManager.LoadScene("ScanMedicine");
    }

    public void ViewAR()
    {
        SceneManager.LoadScene("Second Scene AR");
    }

    public void MenuFocus()
    {
        bgm.volume = 0.25f;
        MenuPanelAnim.SetInteger("MenuOn", 1);
    }

    public void MenuNotInFocus()
    {
        bgm.volume = 1;
        MenuPanelAnim.SetInteger("MenuOn", 0);
    }

    public void TunnelGame()
    {
        SceneManager.LoadScene("Game2");
    }
}
