using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene(1);

    public void ExitGame() => Application.Quit();

    public void MenuScene() => SceneManager.LoadScene(0);
}
