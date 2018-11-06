/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        DriverEmotion.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using Affdex;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using EVP;


public class DriverEmotions : ImageResultsListener {

    int counter = 0;
    string simTime;

    public float currentSmile;
    public float currentInterocularDistance;
    public float currentContempt;
    public float currentValence;
    public float currentAnger;
    public float currentFear;
    public float currentAttention;
    public float currentBrowFurrow;
    public float currentBrowRaise;
    public float currentChinRaise;
    public float currentEyeClosure;
    public float currentInnerBrowRaise;
    public float currentLipCornerDepression;
    public float currentLipPress;
    public float currentLipPucker;
    public float currentLipSuck;
    public float currentMouthOpen;
    public float currentNoseWrinkle;
    public float currentSmirk;
    public float currentUpperLipRaise;
    public FeaturePoint[] featurePointsList;
    public EmotionContainer emotionContainer;
    public VehicleController vehicleController;
    public TimerScript timeScript;

    private void Start()
    {
        InvokeRepeating("sampleEmotion", 1.0f, 1.0f);
        //InvokeRepeating("finalize", 8.0f, 8.0f);
        emotionContainer = new EmotionContainer();
        vehicleController = GameObject.Find("Vehicle").GetComponent<VehicleController>();
        timeScript = GameObject.Find("TimerText").GetComponent<TimerScript>();
    }

    private string takeTime()
    {
        return timeScript.simMinutes + ":" + timeScript.simSeconds;
    }

    void sampleEmotion()
    {
        simTime = takeTime();
        emotionContainer.addEmotion(counter, simTime, currentSmile,currentInterocularDistance, currentContempt,
                                    currentValence,currentAnger,currentFear,currentAttention,currentBrowFurrow,currentBrowRaise,
                                    currentChinRaise,currentEyeClosure,currentInnerBrowRaise,currentLipCornerDepression,
                                    currentLipPress,currentLipPucker,currentLipSuck,currentMouthOpen,currentNoseWrinkle,currentSmirk,
                                    currentUpperLipRaise, 
                                    vehicleController.throttleInput, vehicleController.steerInput, vehicleController.brakeInput);
        counter++;
    }
    void OnDestroy()
    {
        string realTime = System.DateTime.Now.ToString().Replace(@"/", "-");
        realTime = realTime.Replace(" ", "_");
        realTime = realTime.Replace(":", "-");
        emotionContainer.Save(System.IO.Path.Combine(Application.dataPath + "/Emotion Measurements/", "emotionsAt_"+ realTime + ".xml"));
    }

    public override void onImageResults(Dictionary<int, Face> faces)
    {
        foreach (KeyValuePair<int, Face> pair in faces)
        {
            int FaceId = pair.Key;  // The Face Unique Id.
            Face face = pair.Value;    // Instance of the face class containing emotions, and facial expression values.

            //Retrieve the Emotions Scores
            face.Emotions.TryGetValue(Emotions.Contempt, out currentContempt);
            face.Emotions.TryGetValue(Emotions.Valence, out currentValence);
            face.Emotions.TryGetValue(Emotions.Anger, out currentAnger);
            face.Emotions.TryGetValue(Emotions.Fear, out currentFear);
            face.Expressions.TryGetValue(Expressions.Attention, out currentAttention);
            face.Expressions.TryGetValue(Expressions.BrowFurrow, out currentBrowFurrow);
            face.Expressions.TryGetValue(Expressions.BrowRaise, out currentBrowRaise);
            face.Expressions.TryGetValue(Expressions.ChinRaise, out currentChinRaise);
            face.Expressions.TryGetValue(Expressions.EyeClosure, out currentEyeClosure);
            face.Expressions.TryGetValue(Expressions.InnerBrowRaise, out currentInnerBrowRaise);
            face.Expressions.TryGetValue(Expressions.LipCornerDepressor, out currentLipCornerDepression);
            face.Expressions.TryGetValue(Expressions.LipPress, out currentLipPress);
            face.Expressions.TryGetValue(Expressions.LipPucker, out currentLipPucker);
            face.Expressions.TryGetValue(Expressions.LipSuck, out currentLipSuck);
            face.Expressions.TryGetValue(Expressions.MouthOpen, out currentMouthOpen);
            face.Expressions.TryGetValue(Expressions.NoseWrinkle, out currentNoseWrinkle);
            face.Expressions.TryGetValue(Expressions.Smirk, out currentSmirk);
            face.Expressions.TryGetValue(Expressions.UpperLipRaise, out currentUpperLipRaise);

            //Retrieve the Smile Score
            face.Expressions.TryGetValue(Expressions.Smile, out currentSmile);
            //Debug.Log("Smile!");

            //Retrieve the Interocular distance, the distance between two outer eye corners.
            currentInterocularDistance = face.Measurements.interOcularDistance;

            //Retrieve the coordinates of the facial landmarks (face feature points)
            featurePointsList = face.FeaturePoints;
        }
    }
	
}
