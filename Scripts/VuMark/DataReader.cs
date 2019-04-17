using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DataReader : MonoBehaviour {

    List<Patients> patients = new List<Patients>();
    List<Drugs> drugsDb = new List<Drugs>();

    public Patients currentPatient;
    public TextMeshProUGUI[] guiDrugInfo;
    public TextMeshProUGUI[] guiElem;
    public TextMeshPro[] arComp;
    public string drugSelected;
    // Use this for initialization
    void Start () {
        TextAsset patientData = Resources.Load<TextAsset>("Patient Data");

        TextAsset drugsTsv = Resources.Load<TextAsset>("Drugs");
        string[] data = patientData.text.Split(new char[] { '\n' });
        string[] drugsData = drugsTsv.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Patients p = new Patients
            {
                ID = row[0],
                PatientName = row[1],
                RxNumber = row[2],
                Times = row[3],
                PillColour = row[4],
                PillShape = row[5],
                PrescriptionDate = row[6],
                PillNo = row[7],
                PharmacyNumber = row[8],
                DrugName = row[9],
                Dosage = row[10]
            };

            patients.Add(p);

        }

        for (int i = 1; i < drugsData.Length;i++)
        {
            string[] row = drugsData[i].Split(new char[] { ',' });

            Drugs d = new Drugs
            {
                drugId = row[0],
                drugName = row[1],
                sideEffects = row[2],
                interactions = row[3],
                treats = row[4],
                alcoholEffect = row[5],
                pregnancyEffect = row[6]
            };
            drugsDb.Add(d);
        }

	}
	
	// Update is called once per frame
	void Update () {
        if(VuMarkEvent.curVuMarkInstance!=null)
        {
            foreach(Patients p in patients)
            {
                if(p.ID.Equals(VuMarkEvent.curVuMarkInstance))
                {
                    currentPatient = p;
                    guiElem[0].SetText(p.PatientName);
                    arComp[0].SetText(p.PatientName);
                    guiElem[1].SetText(p.RxNumber);
                    arComp[1].SetText(p.RxNumber);

                    guiElem[2].SetText(p.DrugName);
                    arComp[2].SetText(p.DrugName);
                    string medTimes = makeTimeString(p.Times);
                    guiElem[3].SetText(medTimes);
                    arComp[3].SetText(medTimes);
                    guiElem[4].SetText(p.PillNo);
                    guiElem[5].SetText(p.PillShape);
                    guiElem[6].SetText(p.PillColour);
                    guiElem[7].SetText(p.Dosage);

                    arComp[4].SetText(p.PillNo);
                    arComp[5].SetText(p.PillShape);
                    arComp[6].SetText(p.PillColour);
                    arComp[7].SetText(p.Dosage);


                    drugSelected = p.DrugName;


                }
            }

            foreach(Drugs d in drugsDb)
            {
                if(drugSelected.Equals(d.drugName))
                {
                    string interString = interactionString(d.interactions);
                    guiDrugInfo[0].SetText(interString);

                    string sideEffects = splitSideEffects(d.sideEffects);
                    guiDrugInfo[1].SetText(sideEffects);

                    string treats = splitTreatsString(d.treats);
                    guiDrugInfo[2].SetText(treats);
                }
            }
        }
       

	}

    private string makeTimeString(string times)
    {
        string[] split = times.Split(new char[] { '+' });
        times = "";

        for (int i = 0; i < split.Length;i++)
        {
            times = times + split[i] + "\n";

        }
        return times;
    }
    private string splitTreatsString(string treats)
    {
        string[] split = treats.Split(new char[] { '+' });
        treats = "";
        for (int i = 0; i < split.Length;i++)
        {
            treats = treats + split[i] + "\n";
        }
        return treats;
    }

    private string splitSideEffects(string sideEffects)
    {
        string[] split = sideEffects.Split(new char[] { '+' });
        string comSideEffects = "";
        for (int i = 0; i < split.Length;i++)
        {
            comSideEffects = comSideEffects + split[i] + "\n";
        }
        return comSideEffects;
    }

    string interactionString(string compoundString)
    {
        string[] splitInteractions = compoundString.Split(new char[] { '+' });
        string interString = "";
        for (int i = 0; i < splitInteractions.Length - 1; i++)
        {
            interString = interString + splitInteractions[i] + "\n";
        }
        return interString;
    }
}
