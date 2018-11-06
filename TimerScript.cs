/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        TimerScript.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    private Text timerText;
    private float startTime;
    public string simMinutes;
    public string simSeconds;
    public string shareTime;
    public float shareSeconds;

	// Use this for initialization
	void Start () {
        startTime = Time.realtimeSinceStartup;
        timerText = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.realtimeSinceStartup - startTime;
        shareSeconds = (int)t % 60;
        simMinutes = ((int) t / 60).ToString();
        simSeconds = ((int)t % 60).ToString();

        timerText.text = simMinutes + ":" + simSeconds;
        shareTime = simMinutes + "-" + simSeconds;
    }
}
