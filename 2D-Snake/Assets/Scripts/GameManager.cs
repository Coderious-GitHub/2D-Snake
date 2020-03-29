using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int width, height;

    public Tilemap map;
    public Tile border;
    public Tile food;

    public GameObject gameOverUI;

    Vector3Int pos;
    public Vector3Int foodPosition, prevFoodPosition;

    public float difficulty = 100f;

    public bool isGameOver;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
            AudioManager.instance.Play("Theme");

        width = 24;
        height = 18;
        isGameOver = false;
        pos = new Vector3Int(-width / 2, height / 2 - 1, 0);

        Time.fixedDeltaTime = 50f / difficulty;

        InitBorders();
        SpawnFood();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(1).name);
    }

    void InitBorders()
    {
        //draw upper and lower borders
        for (int i = -width/2 ; i <= width / 2; i++)
        {
            map.SetTile(pos, border);
            pos[1] -= height;

            map.SetTile(pos, border);
            pos[1] += height;

            pos[0] = i;
        }

        pos = new Vector3Int(-width / 2, height / 2 - 1, 0);

        //draw left and right borders
        for (int j = height / 2 - 1; j >= -height / 2 - 1; j--)
        {
            map.SetTile(pos, border);
            pos[0] += width - 1;

            map.SetTile(pos, border);
            pos[0] -= width - 1;

            pos[1] = j;
        }
    }

    public void SpawnFood()
    {
        int x = Random.Range(-width / 2 + 1, width / 2 - 1);
        int y = Random.Range(height / 2 - 2, -height / 2);

        prevFoodPosition = foodPosition;
        foodPosition = new Vector3Int(x, y, 0);

        while (map.GetTile(foodPosition) != null)
        {
            x = Random.Range(-width / 2 + 1, width / 2 - 1);
            y = Random.Range(height / 2 - 2, -height / 2);

            foodPosition = new Vector3Int(x, y, 0);
        }

        map.SetTile(foodPosition, food);
    }


    private void FixedUpdate()
    {
        Time.fixedDeltaTime = 50f / difficulty;
    }

    public void GameOver()
    {
        GlobalVariables.instance.UpdateScore(GlobalVariables.instance.playerName, 
            GlobalVariables.instance.score, GlobalVariables.instance.turn, 
            GlobalVariables.instance.difficultyFactor);
        isGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
