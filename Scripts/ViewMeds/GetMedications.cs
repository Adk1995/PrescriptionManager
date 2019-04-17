using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class GetMedications : MonoBehaviour {
    string[] readLines = null;
    public GameObject infoPanel;
    public TextMeshProUGUI[] textboxes;
    public List<GameObject> panels;
    public GameObject canvas;
    int noOfPanels=0;
    int count = 0;
    int lineNo = 1;
    // Use this for initialization
    void Start()
    {
        textboxes = infoPanel.GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log(PlayerPrefs.GetString("Name"));
        //if(File.Exists("Assets/Resources/UserData/" + patient.PatientName + ".txt"))
        if (File.Exists("Assets/Resources/UserData/" + PlayerPrefs.GetString("Name") + ".txt") || PlayerPrefs.GetString("Name") == "qwe")
        {
            readLines = File.ReadAllLines("Assets/Resources/UserData/" + PlayerPrefs.GetString("Name") + ".txt");

            foreach(string line in readLines)
            {
                if(line == "#")
                {
                    noOfPanels += 1;

                }
            }

        }

        for (int i = 0; i < noOfPanels; i++)
        {
            panels.Add(Instantiate(infoPanel));
        }

        foreach(GameObject panel in panels)
        {
            panel.transform.SetParent(canvas.transform);
            panel.transform.localPosition = new Vector3(450, -100 - count*350, 0);
            textboxes = panel.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in textboxes)
            {
                if (text.name == "Times")
                {
                    readLines[lineNo] = readLines[lineNo].Replace("+", ",");
                }
                text.text = readLines[lineNo];
                Debug.Log(text.name);

                lineNo += 1;
            }
            count++;
            lineNo += 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
