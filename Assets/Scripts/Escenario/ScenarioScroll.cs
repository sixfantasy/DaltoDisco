using UnityEngine;

public class ScenarioScroll : MonoBehaviour
{
    void FixedUpdate()
    {
        Debug.Log(ScrollManager.Instance.GetScrollSpeed());
        transform.position -= new Vector3(ScrollManager.Instance.GetScrollSpeed() * Time.deltaTime, 0);
    }
}
