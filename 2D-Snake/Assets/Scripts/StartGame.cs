using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Dropdown difficulty;
    public InputField playerName;
    public PlayerManager player;
    public GameManager gameManager;

    public void Begin()
    {
        GlobalVariables.instance.playerName = playerName.text.ToString();

        switch (difficulty.GetComponent<Dropdown>().value)
        {
            case 0:
                {
                    GlobalVariables.instance.difficultyFactor = 5;
                    break;
                }
            case 1:
                {
                    GlobalVariables.instance.difficultyFactor = 7;
                    break;
                }
            case 2:
                {
                    GlobalVariables.instance.difficultyFactor = 10;
                    break;
                }
        }

        //unloop theme sound
        AudioManager.instance.ModifySound("Theme", 0.5f, 1.0f, false);

        SceneManager.LoadScene(1);
    }
}
