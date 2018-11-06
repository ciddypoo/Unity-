/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        Emotion.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Xml;
using System.Xml.Serialization;

public class Emotion 
{
    [XmlElement("SampleNumber")]
    public int number;
    [XmlElement("SimTime")]
    public string simTime;
    [XmlElement("Speaking")]
    public bool speaking;
   
    [XmlElement("IntroductionEvent")]
    public bool introductionEvent;
    [XmlElement("EngineEvent")]
    public bool engineEvent;
    [XmlElement("FavoriteSongEvent")]
    public bool favSongEvent;
    [XmlElement("FavoriteSongOngoing")]
    public bool favSongOngoing;
    [XmlElement("TrafficEvent")]
    public bool trafficEvent;
    [XmlElement("TrafficOngoing")]
    public bool trafficOngoing;
    [XmlElement("EchoEvent")]
    public bool echoEvent;
    [XmlElement("EchoOngoing")]
    public bool echoOngoing;

    [XmlElement("VolumeUpDownInteraction")]
    public bool volUpDown;
    [XmlElement("RadioOnOffInteraction")]
    public bool radOnOff;
    [XmlElement("RadioNextPrevInteraction")]
    public bool radNextPrev;
    [XmlElement("NavigationInteraction")]
    public bool navi;
    [XmlElement("Misunderstood")]
    public bool mis;

    [XmlElement("currentSmile")]
    public float currentSmile;
    [XmlElement("currentInterocularDistance")]
    public float currentInterocularDistance;
    [XmlElement("currentContempt")]
    public float currentContempt;
    [XmlElement("currentValence")]
    public float currentValence;
    [XmlElement("currentAnger")]
    public float currentAnger;
    [XmlElement("currentFear")]
    public float currentFear;
    [XmlElement("currentAttention")]
    public float currentAttention;
    [XmlElement("currentBrowFurrow")]
    public float currentBrowFurrow;
    [XmlElement("currentBrowRaise")]
    public float currentBrowRaise;
    [XmlElement("currentChinRaise")]
    public float currentChinRaise;
    [XmlElement("currentEyeClosure")]
    public float currentEyeClosure;
    [XmlElement("currentInnerBrowRaise")]
    public float currentInnerBrowRaise;
    [XmlElement("currentLipCornerDepression")]
    public float currentLipCornerDepression;
    [XmlElement("currentLipPress")]
    public float currentLipPress;
    [XmlElement("currentLipPucker")]
    public float currentLipPucker;
    [XmlElement("currentLipSuck")]
    public float currentLipSuck;
    [XmlElement("currentMouthOpen")]
    public float currentMouthOpen;
    [XmlElement("currentNoseWrinkle")]
    public float currentNoseWrinkle;
    [XmlElement("currentSmirk")]
    public float currentSmirk;
    [XmlElement("currentUpperLipRaise")]
    public float currentUpperLipRaise;
    [XmlElement("SteerInput")]
    public float steerInput;
    [XmlElement("ThrottleInput")]
    public float throttleInput;
    [XmlElement("BrakeInput")]
    public float brakeInput;

    public Emotion ()
    {

    }

    public void setEmotionParams(int count, string sim, float Smile,float InterocularDistance,float Contempt,float Valence,float Anger,float Fear,
        float Attention,float BrowFurrow,float BrowRaise,float ChinRaise,float EyeClosure,float InnerBrowRaise,
        float LipCornerDepression,float LipPress,float LipPucker,float LipSuck,float MouthOpen,float NoseWrinkle,
        float Smirk,float UpperLipRaise,float steer,float throttle,float brake) {

        number = count;
        simTime = sim;
        speaking = myVariableStorage.isSpeaking;
        introductionEvent = myVariableStorage.introductionEvent;
        engineEvent = myVariableStorage.engine;
        favSongEvent = myVariableStorage.favSongEvent;
        favSongOngoing = myVariableStorage.favSong;
        trafficEvent = myVariableStorage.trafficEvent;
        trafficOngoing = myVariableStorage.traffic;
        echoEvent = myVariableStorage.echoEvent;
        echoOngoing = myVariableStorage.echo;
        volUpDown = myVariableStorage.volumeChanged;
        radOnOff = myVariableStorage.radioOnOff;
        radNextPrev = myVariableStorage.radioNextPrev;
        navi = myVariableStorage.naviChanged;
        mis = myVariableStorage.mis;

        currentSmile = Smile;
        currentInterocularDistance = InterocularDistance;
        currentContempt = Contempt;
        currentValence = Valence;
        currentAnger = Anger;
        currentFear = Fear;
        currentAttention = Attention;
        currentBrowFurrow = BrowFurrow;
        currentBrowRaise = BrowRaise;
        currentChinRaise = ChinRaise;
        currentEyeClosure = EyeClosure;
        currentInnerBrowRaise = InnerBrowRaise;
        currentLipCornerDepression = LipCornerDepression;
        currentLipPress = LipPress;
        currentLipPucker = LipPucker;
        currentLipSuck = LipSuck;
        currentMouthOpen = MouthOpen;
        currentNoseWrinkle = NoseWrinkle;
        currentSmirk = Smirk;
        currentUpperLipRaise = UpperLipRaise;
      
        steerInput = steer;
        throttleInput = throttle;
        brakeInput = brake;
}
}
