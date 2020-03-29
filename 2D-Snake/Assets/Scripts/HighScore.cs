
using UnityEngine;

[System.Serializable]
public class HighScore
{
    public string[] playerNames = new string[10];
    public string[] scores = new string[10];
    public string[] turns = new string[10];
    public string[] difficulties = new string[10];     

    public HighScore()
    {

        for(int i = 0; i < 10; i++)
        {
            playerNames[i] = GlobalVariables.instance.highScore[i, 0];
            scores[i] = GlobalVariables.instance.highScore[i, 1];
            turns[i] = GlobalVariables.instance.highScore[i, 2];
            difficulties[i] = GlobalVariables.instance.highScore[i, 3];
        }

    }
}
