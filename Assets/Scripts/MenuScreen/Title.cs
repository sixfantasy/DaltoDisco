using TMPro;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;

    private float _bevelOffsetInterpolation;
    private float _minBevelOffset;
    private float _maxBevelOffset;

    [SerializeField] private float _maxLocalScale;
    [SerializeField] private float _minLocalScale;
    [SerializeField] private float _scaleModifierSpeed;
    [SerializeField] private float _beatCooldown;
    private float _currentCooldown;
    private bool _isGrowing;

    void Start()
    {
        _bevelOffsetInterpolation = 0;
        _maxBevelOffset = 0.5f;
        _minBevelOffset = -0.5f;

        _currentCooldown = 0;
        _isGrowing = true;
    }

    void Update()
    {
        UpdateBevelOffset();
        UpdateScale();
    }

    void UpdateBevelOffset()
    {
        _titleText.fontSharedMaterial.SetFloat("_BevelOffset", Mathf.Lerp(_minBevelOffset, _maxBevelOffset, _bevelOffsetInterpolation));

        _bevelOffsetInterpolation += Time.deltaTime / 2;
        if (_bevelOffsetInterpolation >= 1f) 
        { 
            (_minBevelOffset, _maxBevelOffset) = (_maxBevelOffset, _minBevelOffset);
            _bevelOffsetInterpolation = 0;
        }
    }

    void UpdateScale()
    {
        if ((_currentCooldown -= Time.deltaTime) < 0)
        {

            _titleText.transform.localScale += (_isGrowing ? 1 : -1) * new Vector3(Time.deltaTime, Time.deltaTime) * _scaleModifierSpeed;

            if (_titleText.transform.localScale.x > _maxLocalScale || _titleText.transform.localScale.x < _minLocalScale)
                switch (_isGrowing)
                {
                    case true:
                        _isGrowing = false;
                        _titleText.transform.localScale = new Vector3(_maxLocalScale, _maxLocalScale);
                        break;
                    case false:
                        _isGrowing = true;
                        _titleText.transform.localScale = new Vector3(_minLocalScale, _minLocalScale);
                        _currentCooldown = _beatCooldown;
                        break;
                }
        }
    }
}
