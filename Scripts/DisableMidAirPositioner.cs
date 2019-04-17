using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMidAirPositioner : MonoBehaviour {

    public GameObject MidAirPositioner;
	
    public void disableMidAirPositioner()
    {
        MidAirPositioner.SetActive(false);
    }
}
