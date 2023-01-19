using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class CubataManager : MonoBehaviour
{
    public PostProcessLayer postProcessLayer;
    public bool isDrunk = false;
    public static CubataManager Instance;

    private void Awake()
    {
        if (Instance!=null)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (isDrunk)
        {
            StartCoroutine(ActivateFilter());
            isDrunk = false;
        }
    }
    public IEnumerator ActivateFilter()
    {
        postProcessLayer.enabled = true;
        yield return new WaitForSeconds(5f);
        postProcessLayer.enabled = false;
    }
}
