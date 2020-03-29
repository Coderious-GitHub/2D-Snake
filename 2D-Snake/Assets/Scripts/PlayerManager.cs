using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;
    public Tilemap map;

    public Text playerName;
    public Text playerScore;
    public Text playerTurn;

    public Tile headLeft, headRight, headUp, headDown;
    public Tile bodyHoriz, bodyVert;
    public Tile leftToBottom, leftToTop, rightToBottom, rightToTop;

    enum Direction { Up, Down, Left, Right };
    Direction playerDirection, inputDirection;

    Vector3Int playerPosition, tail;
    List<Vector3Int> snake;

    private void Start()
    {
        GlobalVariables.instance.score = 0;
        playerScore.text = GlobalVariables.instance.score.ToString();

        GlobalVariables.instance.turn = 0;
        playerTurn.text = GlobalVariables.instance.turn.ToString();

        playerName.text = GlobalVariables.instance.playerName;

        playerDirection = Direction.Left;
        inputDirection = Direction.Left;
        playerPosition = new Vector3Int(0, 0, 0);
        tail = playerPosition;

        snake = new List<Vector3Int>
        {
            playerPosition
        };
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {

        if (gameManager.isGameOver == true)
            return;

        GlobalVariables.instance.turn++;

        playerDirection = inputDirection;

        //set tail
        tail = snake[snake.Count - 1];

        //move player
        switch (playerDirection)
        {
            case Direction.Up:
                {
                    playerPosition[1] += 1;
                    break;
                }
            case Direction.Down:
                {
                    playerPosition[1] -= 1;
                    break;
                }
            case Direction.Left:
                {
                    playerPosition[0] -= 1;
                    break;
                }
            case Direction.Right:
                {
                    playerPosition[0] += 1;
                    break;
                }
        }

        UpdateSnake();

        if (gameManager.isGameOver == false)
        {
            DrawPlayer();
        }

        playerScore.text = GlobalVariables.instance.score.ToString();
        playerTurn.text = GlobalVariables.instance.turn.ToString();
    }

    void PlayerInput()
    {
        switch (playerDirection)
        {
            case Direction.Left:
                {
                    if (Input.GetKey("w"))
                    {
                        inputDirection = Direction.Up;
                    }

                    if (Input.GetKey("s"))
                    {
                        inputDirection = Direction.Down;
                    }

                    break;
                }
            case Direction.Right:
                {
                    if (Input.GetKey("w"))
                    {
                        inputDirection = Direction.Up;
                    }

                    if (Input.GetKey("s"))
                    {
                        inputDirection = Direction.Down;
                    }
                    break;
                }
            case Direction.Up:
                {
                    if (Input.GetKey("a"))
                    {
                        inputDirection = Direction.Left;
                    }

                    if (Input.GetKey("d"))
                    {
                        inputDirection = Direction.Right;
                    }
                    break;
                }
            case Direction.Down:
                {
                    if (Input.GetKey("a"))
                    {
                        inputDirection = Direction.Left;
                    }

                    if (Input.GetKey("d"))
                    {
                        inputDirection = Direction.Right;
                    }
                    break;
                }
        }
    }

    void UpdateSnake()
    {
        //check if player hits an non-empty tile
        if (map.GetTile(playerPosition) != null &&
            playerPosition != gameManager.foodPosition)
        {
            //FindObjectOfType<AudioManager>().Play("Lose");
            AudioManager.instance.Play("Lose");
            gameManager.GameOver();
            return;
        }

        //check if player has hit the food tile
        if (gameManager.foodPosition == playerPosition)
        {
            //FindObjectOfType<AudioManager>().Play("Food");
            AudioManager.instance.Play("Food");

            GlobalVariables.instance.score += 10;

            gameManager.SpawnFood();
            gameManager.difficulty += GlobalVariables.instance.difficultyFactor;
            snake.Add(gameManager.prevFoodPosition);
        }

        //reorganize segment from tail to head
        for (int i = snake.Count - 1; i != 0; i--)
        {
            snake[i] = snake[i - 1];
        }

        snake[0] = playerPosition;
    }


    void DrawPlayer()
    {
        //draw the head depending on the player's direction
        switch (playerDirection)
        {
            case Direction.Up:
                {
                    map.SetTile(snake[0], headUp);
                    break;
                }
            case Direction.Down:
                {
                    map.SetTile(snake[0], headDown);
                    break;
                }
            case Direction.Left:
                {
                    map.SetTile(snake[0], headLeft);
                    break;
                }
            case Direction.Right:
                {
                    map.SetTile(snake[0], headRight);
                    break;
                }
        }

        //draw second snake segment (flat snake)
        if(snake.Count == 2)
        {
            switch (playerDirection)
            {
                case Direction.Up:
                    {
                        map.SetTile(snake[1], bodyVert);
                        break;
                    }
                case Direction.Down:
                    {
                        map.SetTile(snake[1], bodyVert);
                        break;
                    }
                case Direction.Left:
                    {
                        map.SetTile(snake[1], bodyHoriz);
                        break;
                    }
                case Direction.Right:
                    {
                        map.SetTile(snake[1], bodyHoriz);
                        break;
                    }
            }
        }

        Vector3Int prevSegment = new Vector3Int(0, 0, 0);
        Vector3Int nextSegment = new Vector3Int(0, 0, 0);

        //loop through segment and draw them depending their previous and next segment
        for (int i = 1; i < snake.Count - 1; i++)
        {
            prevSegment = snake[i + 1] - snake[i];
            nextSegment = snake[i] - snake[i - 1];
            Direction prevDirection = 0;
            Direction nextDirection = 0; ;

            switch (prevSegment.x)
            {
                case -1:
                    {
                        prevDirection = Direction.Left;
                        break;
                    }
                case 1:
                    {
                        prevDirection = Direction.Right;
                        break;
                    }
            }

            switch (prevSegment.y)
            {
                case 1:
                    {
                        prevDirection = Direction.Down;
                        break;
                    }
                case -1:
                    {
                        prevDirection = Direction.Up;
                        break;
                    }
            }

            switch (nextSegment.x)
            {
                case 1:
                    {
                        nextDirection = Direction.Left;
                        break;
                    }
                case -1:
                    {
                        nextDirection = Direction.Right;
                        break;
                    }
            }

            switch (nextSegment.y)
            {
                case -1:
                    {
                        nextDirection = Direction.Down;
                        break;
                    }
                case 1:
                    {
                        nextDirection = Direction.Up;
                        break;
                    }
            }


            if ((prevDirection == Direction.Right && nextDirection == Direction.Left) ||
                nextDirection == Direction.Right && prevDirection == Direction.Left)
                map.SetTile(snake[i], bodyHoriz);

            if ((prevDirection == Direction.Up && nextDirection == Direction.Down) ||
                    (nextDirection == Direction.Up && prevDirection == Direction.Down))
                map.SetTile(snake[i], bodyVert);

            if ((prevDirection == Direction.Right && nextDirection == Direction.Up) ||
                (nextDirection == Direction.Right && prevDirection == Direction.Up))
                map.SetTile(snake[i], rightToBottom);

            if ((prevDirection == Direction.Right && nextDirection == Direction.Down) ||
                (nextDirection == Direction.Right && prevDirection == Direction.Down))
                map.SetTile(snake[i], rightToTop);

            if ((prevDirection == Direction.Left && nextDirection == Direction.Up) ||
                (nextDirection == Direction.Left && prevDirection == Direction.Up))
                map.SetTile(snake[i], leftToBottom);

            if ((prevDirection == Direction.Left && nextDirection == Direction.Down) ||
                (nextDirection == Direction.Left && prevDirection == Direction.Down))
                map.SetTile(snake[i], leftToTop);
        }

        //delete tail
        map.SetTile(tail, null);
    }
}
