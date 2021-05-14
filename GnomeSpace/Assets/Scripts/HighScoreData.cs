using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HighScoreData 
{
    public float highScore;
    public float highScore2;
    public float highScore3;
    public float highScore4;
    public float highScore5;


    public HighScoreData(HighScorePanel highScore_01)
    {
        highScore = int.Parse(highScore_01.highScore.text);
        highScore2 = int.Parse(highScore_01.highScore2.text);
        highScore3 = int.Parse(highScore_01.highScore3.text);
        highScore4 = int.Parse(highScore_01.highScore4.text);
        highScore5 = int.Parse(highScore_01.highScore5.text);
    }

}
