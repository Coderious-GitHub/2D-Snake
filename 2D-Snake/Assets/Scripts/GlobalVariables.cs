using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables instance;

    public string playerName = "";
    public int score = 0;
    public int turn = 0;
    public int difficultyFactor = 5;

    public string[,] highScore = new string[10, 4];

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        for (int i = 0; i<10; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                highScore[i, j] = "0";
            }
        }
    }

    public void UpdateScore(string playerName, int score, int turn, int difficulty)
    {
        int rank = 10;
        string diff = "";

        switch (difficulty)
        {
            case 5:
                {
                    diff = "Easy";
                    break;
                }
            case 7:
                {
                    diff = "Medium";
                    break;
                }
            case 10:
                {
                    diff = "Hard";
                    break;
                }
        }

        if(score != 0)
        {

            for (int i = 0; i < 10; i++)
            {
                if (score >= System.Convert.ToInt32(highScore[i, 1]))
                {
                    rank = i;
                    break;
                }
            }

            Debug.Log("rank:" + rank);

            if (rank < 10 && rank != 9)
            {
                for (int j = 9; j > rank; j--)
                {
                    highScore[j, 0] = highScore[j - 1, 0];
                    highScore[j, 1] = highScore[j - 1, 1];
                    highScore[j, 2] = highScore[j - 1, 2];
                    highScore[j, 3] = highScore[j - 1, 3];
                }
            }

            highScore[rank, 0] = playerName;
            highScore[rank, 1] = score.ToString();
            highScore[rank, 2] = turn.ToString();
            highScore[rank, 3] = diff;
        }
    }
}
