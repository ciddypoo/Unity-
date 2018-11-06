/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        RadioControl.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioControl : MonoBehaviour {
    Renderer naviScreen;
    AudioSource radioSource;
    AudioSource songSource;
    AudioSource showSource;
    AudioSource trafficSource;
    AudioSource noiseSource;
    AudioDistortionFilter adf;
    AudioEchoFilter aef;
    Crosstales.Radio.Demo.KeyboardController keyboard;
    Crosstales.Radio.Demo.GUIPlayStation gui;

    private bool radioOn = true;
    private bool songOn = false;
    private bool trafficOn = false;

    float radioVol = 0.1f;
    float tmp = 0;

	void Start () {
        naviScreen = GameObject.FindGameObjectWithTag("Navi").GetComponent<Renderer>();
        radioSource = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
        songSource = GameObject.Find("FavSong").GetComponent(typeof(AudioSource)) as AudioSource;
        songSource.volume = 0;
        showSource = GameObject.Find("Comedy").GetComponent(typeof(AudioSource)) as AudioSource;
        showSource.volume = 0;
        trafficSource = GameObject.Find("Traffic").GetComponent(typeof(AudioSource)) as AudioSource;
        trafficSource.volume = 0;
        noiseSource = GameObject.Find("Noise").GetComponent(typeof(AudioSource)) as AudioSource;
        adf = gameObject.GetComponent(typeof (AudioDistortionFilter)) as AudioDistortionFilter;
        aef = gameObject.GetComponent(typeof (AudioEchoFilter)) as AudioEchoFilter;
        keyboard = gameObject.GetComponentInChildren(typeof(Crosstales.Radio.Demo.KeyboardController)) as Crosstales.Radio.Demo.KeyboardController;
        gui = gameObject.GetComponentInChildren(typeof(Crosstales.Radio.Demo.GUIPlayStation)) as Crosstales.Radio.Demo.GUIPlayStation;
    }

    // Update is called once per frame
    void Update () {
        if (gui.overRide == false)
        {
            radioSource.mute = false;

            if (songOn) { 
            songOn = false;
            songSource.Stop();
            }

            if (trafficOn) { 
                trafficOn = false;
                trafficSource.Stop();
            }
        }
        if (myVariableStorage.isSpeaking && radioVol > 0.1f) {
            radioSource.volume = 0.1f;
            songSource.volume = 0.1f;
            trafficSource.volume = 0.1f;
        }
        else
        {          
            radioSource.volume = radioVol;
            songSource.volume = radioVol;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(myVariableStorage.toggleVolume(1f));
            radioVol += 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(myVariableStorage.toggleVolume(1f));
            radioVol -= 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(myVariableStorage.toggleFavSongEvent(1f));
            myVariableStorage.toggleSongOngoing(true);
            gui.overRide = true;
            radioSource.mute = true;
            trafficSource.Stop();
            trafficOn = false;
            songOn = true;
            keyboard.fakeStation();
            songSource.PlayDelayed(2f);                   
        }
        if (songOn)
        {
           
            if (songSource.volume < radioVol)
            {
                songSource.volume += 0.05f * Time.deltaTime;
            }
            gui.Station.text = "Last FM";
            gui.RecordArtist.text = "Calvin Harris, Dua Lipa";
            gui.RecordTitle.text = "One Kiss";
            if (songSource.isPlaying == false)
            {
                
                songOn = false;
                gui.overRide = false;
                radioSource.mute = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myVariableStorage.toggleSongOngoing(false);
            StartCoroutine(myVariableStorage.toggleTrafficEvent(1f));
            myVariableStorage.toggleTrafficOngoing(true);
            gui.overRide = true;
            radioSource.mute = true;
            songSource.Stop();
            songOn = false;
            trafficOn = true;
            radioVol = 0.7f;
            trafficSource.Play();
        }
        if (trafficOn)
        {   
            
            trafficSource.volume = radioVol + 0.2f;
            
            gui.Station.text = "BR";
            gui.RecordArtist.text = "News";
            gui.RecordTitle.text = "Traffic Information";
            if (trafficSource.isPlaying == false)
            {
                
                    trafficOn = false;
                    gui.overRide = false;
                    radioSource.mute = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (adf.enabled == false && aef.enabled == false) {
                StartCoroutine(myVariableStorage.toggleEchoEvent(1f));
                myVariableStorage.toggleEchoOngoing(true);
            adf.enabled = true;
            aef.enabled = true;
            }
            else {
                myVariableStorage.toggleEchoOngoing(false);
                adf.enabled = false;
                aef.enabled = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            StartCoroutine(myVariableStorage.toggleNavi(1f));
            if (naviScreen.enabled == false)
            {

                naviScreen.enabled = true;
            }        
            else
            {
                naviScreen.enabled = false;
            }

        }

        
        if (Input.GetKeyDown(KeyCode.Quote) || Input.GetKeyDown(KeyCode.BackQuote))
        {
            myVariableStorage.toggleTrafficOngoing(false);
            myVariableStorage.toggleSongOngoing(false);
            StartCoroutine(myVariableStorage.toggleRadioOnOff(1f));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            myVariableStorage.toggleTrafficOngoing(false);
            myVariableStorage.toggleSongOngoing(false);
            StartCoroutine(myVariableStorage.toggleRadioNextPrev(1f));
            
        }

    }  
}
