
using UnityEngine;

public class CloseHighScore : MonoBehaviour
{

    public GameObject highScoreUi;

    public void Close()
    {
        highScoreUi.SetActive(false);
    }

}
