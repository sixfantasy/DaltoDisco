using System.Collections;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer _standardVideo;
    [SerializeField] private UnityEngine.Video.VideoPlayer[] _backgroundVideos;

    [SerializeField] private float _timeBetweenBackgroundChanges;
    [SerializeField] private UnityEngine.Video.VideoPlayer _currentVideo;
    [SerializeField] private GameObject _mrWorldWide;

    private int _currentVideoIndex;
    public bool isBossfightHappenning;

    void Start()
    {
        _currentVideoIndex = -1;
        isBossfightHappenning = false;
        StartCoroutine(ChangeToStandardBackground());
    }

    public float GetTimeBetweenChanges() => _timeBetweenBackgroundChanges;

    public void EndBoss()
    { 
        StartCoroutine(ChangeToStandardBackground());
        StartCoroutine(EnableMrWorldWide());
    }

    private IEnumerator EnableMrWorldWide()
    {
        yield return new WaitForSeconds(_timeBetweenBackgroundChanges + 14);
        _mrWorldWide.SetActive(true);
    }

    private IEnumerator ChangeToStandardBackground()
    {
        yield return new WaitForSeconds(_timeBetweenBackgroundChanges);
        _currentVideo.enabled = false;
        _currentVideo = _standardVideo;
        _currentVideo.enabled = true;        
    }

    public IEnumerator BackgroundPeriod()
    {
        yield return new WaitForSeconds(_timeBetweenBackgroundChanges);
        _currentVideoIndex = (_currentVideoIndex + 1) % _backgroundVideos.Length;

        if (isBossfightHappenning)
        {
            _currentVideo.enabled = false;
            _currentVideo = _backgroundVideos[_currentVideoIndex];
            _currentVideo.enabled = true;
            StartCoroutine(BackgroundPeriod());
        }
    }
}
