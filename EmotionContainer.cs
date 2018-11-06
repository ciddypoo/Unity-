/*============================================================================= 
#  Author:          ciddypoo 
#  Email:           z4pdesigns@gmail.com 
#  FileName:        EmotionContainer.cs
#  Description:     
#  Version:         
#  LastChange:      
#  History:         
=============================================================================*/ 

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("EmotionCollection")]
 public class EmotionContainer 
{
    int count = 0;
    [XmlArray("Emotions"),XmlArrayItem("Emotion")]
 	//public Emotion[] emotions = new Emotion[20];
    public List<Emotion> Emotions = new List<Emotion>();

    private void Start()
    {
        //emotions = new Emotion[20];
    }

    public void Save(string path)
 	{
 		var serializer = new XmlSerializer(typeof(EmotionContainer));
 		using(var stream = new FileStream(path, FileMode.Create))
 		{
 			serializer.Serialize(stream, this);
            stream.Close();
        }
 	}

 	public void addEmotion(int count, string sim, float Smile, float InterocularDistance, float Contempt, float Valence, float Anger, float Fear,
        float Attention, float BrowFurrow, float BrowRaise, float ChinRaise, float EyeClosure, float InnerBrowRaise,
        float LipCornerDepression, float LipPress, float LipPucker, float LipSuck, float MouthOpen, float NoseWrinkle,
        float Smirk, float UpperLipRaise, float steer, float throttle, float brake)
 	{
        Emotion e = new Emotion();
        e.setEmotionParams(count, sim, Smile, InterocularDistance,Contempt, Valence, Anger, Fear,
        Attention, BrowFurrow, BrowRaise, ChinRaise, EyeClosure, InnerBrowRaise,
        LipCornerDepression, LipPress, LipPucker, LipSuck, MouthOpen, NoseWrinkle,
        Smirk, UpperLipRaise, steer, throttle, brake);
        Emotions.Add(e);
        //Debug.Log(e.currentSmile);
 	
 	}
 }