/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        myVariableStorage.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myVariableStorage : MonoBehaviour {

    private IEnumerator coroutine;
    private static AudioSource bleep = new AudioSource();
    public static bool isSpeaking = false;
    public static bool volumeChanged = false;
    public static bool naviChanged = false;
    public static bool radioOnOff = false;
    public static bool radioNextPrev = false;
    public static bool introductionEvent = false;
    public static bool favSongEvent = false;
    public static bool trafficEvent = false;
    public static bool echoEvent = false;
    public static bool engine = false;
    public static bool favSong = false;
    public static bool traffic = false;
    public static bool echo = false;
    public static bool mis = false;

    private void Start()
    {
        bleep = GameObject.Find("VoiceIndicator").GetComponent<AudioSource>();
    }

    public static IEnumerator toggleIntroductionEvent(float waitTime)
    {
        introductionEvent = true;
        yield return new WaitForSeconds(waitTime);
        introductionEvent = false;
    }
    public static IEnumerator toggleEngineEvent(float waitTime)
    {
        engine = true;
        yield return new WaitForSeconds(waitTime);
        engine = false;
    }
    public static IEnumerator toggleFavSongEvent(float waitTime)
    {
        favSongEvent = true;
        yield return new WaitForSeconds(waitTime);
        favSongEvent = false;
    }
    public static IEnumerator toggleTrafficEvent(float waitTime)
    {
        trafficEvent = true;
        yield return new WaitForSeconds(waitTime);
        trafficEvent = false;
    }
    public static IEnumerator toggleEchoEvent(float waitTime)
    {
        echoEvent = true;
        yield return new WaitForSeconds(waitTime);
        echoEvent = false;
    }
   
    public static void toggleSongOngoing(bool x)
    {
        favSong = x;
    }
    public static void toggleTrafficOngoing(bool x)
    {
        traffic = x;
    }
    public static void toggleEchoOngoing(bool x)
    {
        echo = x;
    }
    public static IEnumerator toggleVolume(float waitTime)
    {
        volumeChanged = true;
        yield return new WaitForSeconds(waitTime);
        volumeChanged = false;
    }

    public static IEnumerator toggleNavi(float waitTime)
    {
        naviChanged = true;
        yield return new WaitForSeconds(waitTime);
        naviChanged = false;

    }
    public static IEnumerator toggleMis(float waitTime)
    {
        mis = true;
        yield return new WaitForSeconds(waitTime);
        mis = false;
    }

    public static IEnumerator toggleRadioOnOff(float waitTime)
    {
        radioOnOff = true;
        yield return new WaitForSeconds(waitTime);
        radioOnOff = false;

    }
    public static IEnumerator toggleRadioNextPrev(float waitTime)
    {
        radioNextPrev = true;
        yield return new WaitForSeconds(waitTime);
        radioNextPrev = false;
    }
}

