using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelayWaiter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] objectsToActivate;
    [SerializeField] private float delay;
    private void Start()
    {
        ActivateObjects(false);
        StartCoroutine(ActivateObjectsInDelay(delay));
    }

    private IEnumerator ActivateObjectsInDelay(float seconds)
    {
        yield return new WaitForSeconds(delay);
        ActivateObjects(true);
    }

    private void ActivateObjects(bool state)
    {
        foreach(MonoBehaviour obj in objectsToActivate)
        {
            obj.enabled = state;
        }
    }
}
