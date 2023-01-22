using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private SceneTransition _sceneTransition;

    IEnumerator ChangeScene(int scene)
    {
        yield return StartCoroutine(_sceneTransition.DoFading(false));
        if (scene == -1) Application.Quit();
        else SceneManager.LoadSceneAsync(scene);
    }

    public void StartGame() => StartCoroutine(ChangeScene(1));

    public void ExitGame() => StartCoroutine(ChangeScene(-1));

    public void MenuScene() => StartCoroutine(ChangeScene(0));
}
