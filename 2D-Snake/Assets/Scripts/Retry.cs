
using UnityEngine;

public class Retry : MonoBehaviour
{

    public void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }

}