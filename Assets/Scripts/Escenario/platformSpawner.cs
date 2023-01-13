using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public Platforms scriptablePlatforms;
    float oldPlatformY = -1;
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
        float PlaformMultiplier = Random.Range(0.8f, 2f);
        GameObject summon = Instantiate((scriptablePlatforms.platforms[Random.Range(0, 5)]), new Vector3(15f, oldPlatformY + Random.Range(-1.5f, 1.5f)), Quaternion.identity);
        summon.transform.localScale = new Vector3(5 * PlaformMultiplier * ScrollManager.Instance.GetScrollSpeed() / 7.5f , 1, 1);
        nextTimer = (5f * (PlaformMultiplier / 7.5f) +0.25f);
        currentTime = 0;
    }
}
