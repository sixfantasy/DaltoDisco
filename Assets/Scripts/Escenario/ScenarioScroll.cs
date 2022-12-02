using UnityEngine;

public class ScenarioScroll : MonoBehaviour
{
    void FixedUpdate() => transform.position -= new Vector3(ScrollManager.Instance.GetScrollSpeed() * Time.deltaTime, 0);
}
