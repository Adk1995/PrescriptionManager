using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuMarkEvent : MonoBehaviour {

	public List<GameObject> modelList;
	public List<string> modelIdList;
    public static string curVuMarkInstance;
	private int modelN;
	private VuMarkManager vuMarkManager;

	void Start () {
		// Set VuMarkManager
		vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
		// Set VuMark detected and lost behavior methods
		vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
		vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);

		// Deactivate all models 
		foreach(GameObject item in modelList){
			item.SetActive (false);
		}
	}

	void Update () {
/*		foreach (var vmb in vuMarkManager.GetActiveBehaviours()) {
			Debug.Log ("ID: "+ getVuMarkID(vmb.VuMarkTarget));
		}
*/
	}

	private string getVuMarkID(VuMarkTarget vuMark){
		switch (vuMark.InstanceId.DataType){
		case InstanceIdType.BYTES:
			return vuMark.InstanceId.HexStringValue;
		case InstanceIdType.STRING:
			return vuMark.InstanceId.StringValue;
		case InstanceIdType.NUMERIC:
			return vuMark.InstanceId.NumericValue.ToString();
		}

		return null;
	}

	public void onVuMarkDetected(VuMarkTarget target){
		Debug.Log ("Detected ID: "+ getVuMarkID(target));
        //		Debug.Log (target.Template.VuMarkUserData);

        // Find and activate model by VuMark ID
        for (int i = 0; i < modelIdList.Count; i++)
        {
          // Debug.Log(getVuMarkID(target).GetType());
            //Debug.Log(getVuMarkID(target));
            //Debug.Log(modelIdList[i]);

            //string currInnerText = getVuMarkID(target);
            //string paraText = modelIdList[i];
            //if (currInnerText.Length != paraText.Length)
            //{
            //    Debug.Log(currInnerText.Length);
            //    Debug.Log(paraText.Length);
            //    throw new Exception("Well here's the problem");

            //}

            //for (int j = 0; j < currInnerText.Length; j++)
            //{
            //    if (currInnerText[j] != paraText[j])
            //    {
            //        throw new Exception("Difference at character: " + j + 1);
            //    }
            //}

            if (getVuMarkID(target).Equals(modelIdList[i])) {
                curVuMarkInstance = modelIdList[i];
               // Debug.Log(curVuMarkInstance);
				modelList [i].SetActive (true);

				// Set model number
				modelN = i;
			}
		}
	}

	public void onVuMarkLost(VuMarkTarget target){
		Debug.Log ("Lost ID: "+ getVuMarkID(target));
        curVuMarkInstance = null;
		// Deactivate model by model number
		modelList [modelN].SetActive (false);
	}
}
