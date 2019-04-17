using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ToggleDrugInfo : MonoBehaviour {

    public Button toggleButton;
    public Button upperToggle;
    public Button hamburgerButton;
    public Button home;
    public Button back;
    public Button game;
    public Button save;
    public GameObject[] panels;
    public GameObject[] upperPanels;
    public GameObject mainPanel;
    Animator MenuPanelAnim;

    public int i = 0;
    public int j = 0;
	// Use this for initialization
	void Start () {
        toggleButton.onClick.AddListener(ChangeOnClick);
        upperToggle.onClick.AddListener(ChangeTop);
        hamburgerButton.onClick.AddListener(OpenPanel);
        home.onClick.AddListener(SceneChange);
        game.onClick.AddListener(GameScene);
        back.onClick.AddListener(HidePanel);
        save.onClick.AddListener(AddInfoToFile);
        MenuPanelAnim = mainPanel.GetComponent<Animator>();

    }

    void AddInfoToFile()
    {
        Patients patient = GameObject.Find("PatientData").GetComponent<DataReader>().currentPatient;
        List<int> indices_records;
        indices_records = new List<int>();
        String[] readLines = null;
        bool to_Write = true;
        if (patient.PatientName == PlayerPrefs.GetString("Name") || PlayerPrefs.GetString("Name")==("qwe"))
        {
           

            if (File.Exists("Assets/Resources/UserData/" + patient.PatientName + ".txt"))
            {
                readLines = File.ReadAllLines("Assets/Resources/UserData/" + patient.PatientName + ".txt");
                for (int i = 0; i < readLines.Length;i++)
                {
                    if(readLines[i] == "#")
                    {
                        indices_records.Add(i);
                    }
                }
            }
            foreach(int index in indices_records)
            {
                if(patient.RxNumber == readLines[index+2])
                {
                    to_Write = false;
                }
            }
            if(to_Write)
            {
                TextWriter line = new StreamWriter("Assets/Resources/UserData/" + patient.PatientName + ".txt", append: true);

                line.WriteLine("#");
                line.WriteLine(patient.DrugName);
                line.WriteLine(patient.RxNumber);
                line.WriteLine(patient.Dosage);
                line.WriteLine(patient.Times);
                line.WriteLine(patient.PharmacyNumber);
                line.WriteLine(patient.PillColour);
               

                line.Close();
            }

        }
    }

    void HidePanel()
    {
        MenuPanelAnim.SetInteger("MenuOn", 0);

    }
    void GameScene()
    {
        SceneManager.LoadScene("Game1");
    }
    void SceneChange()
    {
        SceneManager.LoadScene("Second Scene");
    }
    void OpenPanel()
    {
        MenuPanelAnim.SetInteger("MenuOn", 1);
    }
    void ChangeTop()
    {
        upperPanels[j].SetActive(false);
        j = (j + 1) % upperPanels.Length;
        upperPanels[j].SetActive(true);
    }

    void ChangeOnClick()
    {
        Debug.Log("Button Clicked");
        panels[i].SetActive(false);
        i = (i + 1) % panels.Length;
        panels[i].SetActive(true);

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

    // Update is called once per frame
    void Update () {
		
	}


}
