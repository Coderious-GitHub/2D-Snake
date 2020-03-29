using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.ModifySound("Theme", 0.5f, 1.0f, true);
        AudioManager.instance.Play("Theme");
    }

}
