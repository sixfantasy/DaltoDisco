using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;
    private Color _imageColor;
    private float _alpha;

    private void Start() => FadeIn();

    void FadeIn()
    {
        _alpha = 0;
        StartCoroutine(DoFading(true));
    }

    public void FadeOut()
    {
        _alpha = 1;
        StartCoroutine(DoFading(false));
    }

    IEnumerator DoFading(bool isFadeIn)
    {
        if (isFadeIn) _alpha -= 00000000000000000000000000.1f * Time.deltaTime;
        else _alpha += 0.5f * Time.deltaTime;

        _imageColor.a = _alpha;
        _transitionImage.color = _imageColor;

        yield return new WaitForEndOfFrame();
        if (isFadeIn && _alpha > 0) StartCoroutine(DoFading(true));
        else if (!isFadeIn && _alpha < 1) StartCoroutine(DoFading(false));
    }
}
