using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject PlatformPrefab;
    float oldPlatformY = 0;
    float nextTimer = 1.5f;
    float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= nextTimer)
            SummonPlatform();
    }

    private void SummonPlatform()
    {
        float PlaformMultiplier = Random.Range(0.5f, 2f);
        GameObject summon = Instantiate(PlatformPrefab, new Vector3(15f, oldPlatformY + Random.Range(-2f, 2f)), Quaternion.identity);
        summon.transform.localScale = new Vector3(5 * PlaformMultiplier, 1, 1);
        nextTimer = (5f * PlaformMultiplier / ScrollManager.Instance.GetScrollSpeed())+0.25f;
        currentTime = 0;
    }
}
