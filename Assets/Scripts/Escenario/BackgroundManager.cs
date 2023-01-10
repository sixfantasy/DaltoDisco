using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer[] _backgroundVideos;

    [SerializeField] private float _timeBetweenBackgroundChanges;
    [SerializeField] private UnityEngine.Video.VideoPlayer _currentVideo;

    private int _currentVideoIndex;

    void Start()
    {
        _currentVideoIndex = -1;
        StartCoroutine(BackgroundPeriod());
    }

    IEnumerator BackgroundPeriod()
    {
        yield return new WaitForSeconds(_timeBetweenBackgroundChanges);
        _currentVideoIndex = (_currentVideoIndex + 1) % _backgroundVideos.Length;
        _currentVideo.enabled = false;
        _currentVideo = _backgroundVideos[_currentVideoIndex];
        _currentVideo.enabled = true;
        StartCoroutine(BackgroundPeriod());
    }
}
