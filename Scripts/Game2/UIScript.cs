using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{

    public GameObject MenuPanel;
    Animator MenuPanelAnim;

    public TextMeshProUGUI player_name;

    private void Start()
    {
        MenuPanelAnim = MenuPanel.GetComponent<Animator>();
        player_name.text = PlayerPrefs.GetString("Name");
    }

    public void home()
    {
        SceneManager.LoadScene("Second Scene");
    }

    public void ScanMeds()
    {
        SceneManager.LoadScene("ScanMedicine");
    }

    public void MenuFocus()
    {
        MenuPanelAnim.SetInteger("MenuOn", 1);
    }

    public void MenuNotInFocus()
    {
        MenuPanelAnim.SetInteger("MenuOn", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game1");
    }
}
