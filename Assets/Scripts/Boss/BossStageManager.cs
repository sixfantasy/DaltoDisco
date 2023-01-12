using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossStageManager : MonoBehaviour
{
    EnemyGetDamage damage;
    UIManager distanceReference;
    public int Stage;
    public EnemySpawner spawner;

    [SerializeField] private BackgroundManager _backgroundManager;
    [SerializeField] private GameObject _bossAnnouncement;

    [SerializeField] private AudioSource _mainSong;
    [SerializeField] private AudioSource _afterBossSong;

    // Start is called before the first frame update
    void Start()
    {
        damage = GetComponent<EnemyGetDamage>();
        distanceReference = GameObject.Find("Managers").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceReference.DistanceTravelled > 200 && Stage == 0)
        {
            _backgroundManager.isBossfightHappenning = true;
            StartCoroutine(_backgroundManager.BackgroundPeriod());
            StartCoroutine(DoBossAnnouncement());
            Stage = 1;
            spawner.enabled = false;
        }
        if (damage.health < 700 && Stage == 1)
            Stage = 2;
        if (damage.health < 200 && Stage == 2)
            Stage = 3;
        if (damage.health > 0 && Stage == 2)
            spawner.enabled = true;
        GetComponent<Animator>().SetInteger("Stage", Stage);
        Debug.Log(GetComponent<Animator>().GetInteger("Stage"));
    }

    private IEnumerator DoBossAnnouncement()
    {
        _bossAnnouncement.SetActive(true);
        yield return new WaitForSeconds(_backgroundManager.GetTimeBetweenChanges());
        Destroy(_bossAnnouncement);
    }

    private void OnDestroy()
    {
        if (damage.health <= 0)
        {
            _backgroundManager.isBossfightHappenning = false;
            _backgroundManager.ResetBackground();

            Destroy(_mainSong);
            _afterBossSong.enabled = true;
        }
    }
}
