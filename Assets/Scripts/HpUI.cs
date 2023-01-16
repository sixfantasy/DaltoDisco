using UnityEngine;

public class HpUI : MonoBehaviour
{
    [SerializeField] private RectTransform _hpPanel;
    [SerializeField] private PlayerStats _playerStats;

    private void Update() => _hpPanel.sizeDelta = new Vector2(_hpPanel.rect.width, _playerStats.health / _playerStats.maxHealth * 100);


}
