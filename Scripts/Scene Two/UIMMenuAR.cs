using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMMenuAR : MonoBehaviour {

    public GameObject MenuPanel;
    Animator MenuPanelAnim;
    //public Text player_name;
    AudioSource bgm;
    public GameObject world;

    public TextMeshProUGUI player_name;
    
    private void Start()
    {
        bgm = world.GetComponent<AudioSource>();
        MenuPanelAnim = MenuPanel.GetComponent<Animator>();
        //player_name = Pname.GetComponent<TextMeshProUGUI>();
        player_name.text = PlayerPrefs.GetString("Name");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ScanMeds()
    {
        SceneManager.LoadScene("ScanMedicine");
    }

    public void MenuFocus()
    {
        bgm.volume = 0.25f;
        MenuPanelAnim.SetInteger("MenuOn", 1);
    }

    public void NormalMode()
    {
        SceneManager.LoadScene("Second Scene");
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

    public void ViewMeds()
    {
        SceneManager.LoadScene("ViewMedications");
    }
}
