/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        VoiceController.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.RTVoice.Tool;
using Crosstales.RTVoice.Model;

namespace Crosstales.RTVoice {
    public class VoiceController : MonoBehaviour {
        TextFileSpeaker speech;
        Crosstales.RTVoice.Speaker speaker;
        CircleRotation cr;

        // Use this for initialization
        void Start()
        {
            cr = FindObjectOfType<CircleRotation>();
            speech = this.GetComponent(typeof(TextFileSpeaker)) as Crosstales.RTVoice.Tool.TextFileSpeaker;
            speaker = this.GetComponentInParent(typeof(Speaker)) as Crosstales.RTVoice.Speaker;
            Speaker.OnSpeakComplete += turnOff;
        }

        // Update is called once per frame
        void Update() {
            
            //Introduction
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(myVariableStorage.toggleIntroductionEvent(2f));
                speech.SpeakText(0);
                myVariableStorage.isSpeaking = true;              
            }
            //EchoFunction
            if (Input.GetKeyDown(KeyCode.P))
            {
                StartCoroutine(myVariableStorage.toggleEchoEvent(2f));
                speech.SpeakText(1);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //AreYouSure?
            if (Input.GetKeyDown(KeyCode.O))
            {
                speech.SpeakText(2);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //SongFunction
            if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine(myVariableStorage.toggleFavSongEvent(2f));
                speech.SpeakText(3);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //I see
            if (Input.GetKeyDown(KeyCode.B))
            {
                speech.SpeakText(4);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //Affirm
            if (Input.GetKeyDown(KeyCode.A))
            {
                int i = Random.Range(9, 17);
                speech.SpeakText(i);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //Misunderstand
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(myVariableStorage.toggleMis(1f));
                int i = Random.Range(27,31);
                speech.SpeakText(i);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }
            //Not Implemented
            if (Input.GetKeyDown(KeyCode.K))
            {
                int i = Random.Range(32, 36);
                speech.SpeakText(i);
                myVariableStorage.isSpeaking = true;
                myVariableStorage.listening = false;
            }       
        }

        void turnOff(Wrapper wrapper)
        {
            cr.off();
            myVariableStorage.isSpeaking = false;
            //myVariableStorage.listening = false;
        }

        public void affirm()
        {
            int i = Random.Range(9, 17);
            speech.SpeakText(i);
            myVariableStorage.isSpeaking = true;
            myVariableStorage.listening = false;
        }
    }
}