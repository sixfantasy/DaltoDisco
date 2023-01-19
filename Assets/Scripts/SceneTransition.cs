using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;
    private Color _imageColor;
    private float _alpha;

    private void Start()
    {
        _transitionImage.color = _imageColor;
        if (SceneManager.GetActiveScene().name != "GameOver")
            StartCoroutine(DoFading(true));
        else
            StartCoroutine(DoFading(true, false));
    }

    public IEnumerator DoFading(bool isFadeIn, bool doTripleFade = true)
    {
        if (isFadeIn)
        {
            _alpha = 1;
            if (doTripleFade)
            {
                for (int i = 0; i < 3; i++)
                {
                    while (_alpha > 0)
                    {
                        _alpha -= 5f * Time.deltaTime;
                        _imageColor.a = _alpha;
                        _transitionImage.color = _imageColor;
                        yield return new WaitForEndOfFrame();
                    }

                    while (_alpha < 1)
                    {
                        _alpha += 5f * Time.deltaTime;
                        _imageColor.a = _alpha;
                        _transitionImage.color = _imageColor;
                        yield return new WaitForEndOfFrame();
                    }
                }
            }

            while (_alpha > 0)
            {
                _alpha -= Time.deltaTime;
                _imageColor.a = _alpha;
                _transitionImage.color = _imageColor;
                yield return new WaitForEndOfFrame();
            }

            _transitionImage.enabled = false;
        }
        else
        {
            _alpha = 0;
            _transitionImage.enabled = true;
            while (_alpha < 1)
            {
                _alpha += 0.5f * Time.deltaTime;
                _imageColor.a = _alpha;
                _transitionImage.color = _imageColor;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
