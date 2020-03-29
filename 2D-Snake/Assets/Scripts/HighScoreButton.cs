using UnityEngine;
using UnityEngine.UI;

public class HighScoreButton : MonoBehaviour
{
    public GameObject highScoreUI;

    public Text firstPlayer, firstScore, firstTurn, firstDifficulty;
    public Text secondPlayer, secondScore, secondTurn, secondDifficulty;
    public Text thirdPlayer, thirdScore, thirdTurn, thirdDifficulty;
    public Text forthPlayer, forthScore, forthTurn, forthDifficulty;
    public Text fifthPlayer, fifthScore, fifthTurn, fifthDifficulty;
    public Text sixthPlayer, sixthScore, sixthTurn, sixthDifficulty;
    public Text seventhPlayer, seventhScore, seventhTurn, seventhDifficulty;
    public Text eigthPlayer, eigthScore, eigthTurn, eigthDifficulty;
    public Text ninthPlayer, ninthScore, ninthTurn, ninthDifficulty;
    public Text tenthPlayer, tenthScore, tenthTurn, tenthDifficulty;

    public void ShowHighScore()
    {
        highScoreUI.SetActive(true);
        UpdateTable();
    }

    public void UpdateTable()
    {
        for (int i = 0; i <= 9; i++)
        {
            switch (i)
            {
                case 0:
                    {
                        firstPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        firstScore.text = GlobalVariables.instance.highScore[i, 1];
                        firstTurn.text = GlobalVariables.instance.highScore[i, 2];
                        firstDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 1:
                    {
                        secondPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        secondScore.text = GlobalVariables.instance.highScore[i, 1];
                        secondTurn.text = GlobalVariables.instance.highScore[i, 2];
                        secondDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 2:
                    {
                        thirdPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        thirdScore.text = GlobalVariables.instance.highScore[i, 1];
                        thirdTurn.text = GlobalVariables.instance.highScore[i, 2];
                        thirdDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 3:
                    {
                        forthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        forthScore.text = GlobalVariables.instance.highScore[i, 1];
                        forthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        forthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 4:
                    {
                        fifthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        fifthScore.text = GlobalVariables.instance.highScore[i, 1];
                        fifthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        fifthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 5:
                    {
                        sixthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        sixthScore.text = GlobalVariables.instance.highScore[i, 1];
                        sixthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        sixthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 6:
                    {
                        seventhPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        seventhScore.text = GlobalVariables.instance.highScore[i, 1];
                        seventhTurn.text = GlobalVariables.instance.highScore[i, 2];
                        seventhDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 7:
                    {
                        eigthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        eigthScore.text = GlobalVariables.instance.highScore[i, 1];
                        eigthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        eigthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 8:
                    {
                        ninthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        ninthScore.text = GlobalVariables.instance.highScore[i, 1];
                        ninthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        ninthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
                case 9:
                    {
                        tenthPlayer.text = GlobalVariables.instance.highScore[i, 0];
                        tenthScore.text = GlobalVariables.instance.highScore[i, 1];
                        tenthTurn.text = GlobalVariables.instance.highScore[i, 2];
                        tenthDifficulty.text = GlobalVariables.instance.highScore[i, 3];
                        break;
                    }
            }
        }
    }

}
