using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;
using System.IO;


public class TimedNotifications : MonoBehaviour {
    public Text text;
    public string curTime;
    public GameObject holdDataScript;
    public string timeToSend = "11:22";
    public bool tempNotificationSent = false;
    string[] readLines = null;
    public List<string> timeList;
    public List<bool> notificationSent;
	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetString("Name"));
        if(File.Exists("Assets/Resources/UserData/" + PlayerPrefs.GetString("Name") + ".txt")||PlayerPrefs.GetString("Name")=="qwe")
        {
            readLines = File.ReadAllLines("Assets/Resources/UserData/" + PlayerPrefs.GetString("Name") + ".txt");
            for (int i = 0; i < readLines.Length; i++)
            {
                if(readLines[i]=="#")
                {
                    string[] times = readLines[i + 4].Split(new char[] { '+' });
                    for (int j = 0; j < times.Length; j++)
                    {
                        timeList.Add(times[j]);
                        notificationSent.Add(false);
                    }

                }
            }
          

         }

        //holdDataScript = GameObject.Find("PatientData");
        //DataReader dataReader = holdDataScript.GetComponent<DataReader>();
}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(GameObject.Find("PatientData").GetComponent<DataReader>().currentPatient.PatientName);
        curTime = System.DateTime.Now.ToString("HH:mm");
        string selectedTime = null;
        for (int i = 0; i < timeList.Count; i++)
        {
            if (curTime == timeList[i] && notificationSent[i] == false)
            {
                NotificationManager.Send(TimeSpan.FromSeconds(2), "Hello "+ PlayerPrefs.GetString("Name"), "Time to take your meds", new Color(1, 0.3f, 0.15f));
                selectedTime = curTime;
                notificationSent[i] = true;
            }
        }

        if (curTime == timeToSend && tempNotificationSent==false)
        {
            NotificationManager.Send(TimeSpan.FromSeconds(2), "Hello Player", "Time to take your meds", new Color(1, 0.3f, 0.15f));
            tempNotificationSent = true;
        }


    }

   
}
