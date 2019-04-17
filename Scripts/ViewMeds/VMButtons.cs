using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VMButtons : MonoBehaviour {

    public Button hamburger;
    public Button back;
    
    public GameObject mainPanel;
    Animator MenuPanelAnim;

	// Use this for initialization
	void Start () {
        hamburger.onClick.AddListener(OpenPanel);
        back.onClick.AddListener(HidePanel);
        MenuPanelAnim = mainPanel.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
		
	}
    void HidePanel()
    {
        MenuPanelAnim.SetInteger("MenuOn", 0);
    }
    void OpenPanel()
    {
        Debug.Log("HElleo");
        MenuPanelAnim.SetInteger("MenuOn", 1);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Second Scene");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ScanMeds()
    {
        SceneManager.LoadScene("ScanMedicine");
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
