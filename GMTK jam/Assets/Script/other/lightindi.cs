using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightindi : MonoBehaviour
{
    [SerializeField] private List<Transform> jLights;

    private void Start()
    {
        foreach (Transform l in jLights)
        {
            colchange(l, 0, 0, 0, 0);
        }
        lightUp();
    }
    void lightUp()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        foreach (Transform l in jLights)
        {
            colchange(l);
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            colchange(l, 0, 0, 0, 0);
        }
        yield return new WaitForSeconds(.3f);
        foreach (Transform l in jLights)
        {
            colchange(l, 0, 100, 100);
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            if (jLights.IndexOf(l) >= 2)
            {
                colchange(l, 50, 140, 140);
            }
            else
            {
                colchange(l, 0, 0, 0, 0);
            }
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            if (jLights.IndexOf(l) >= 4)
            {
                colchange(l, 80, 170, 170);
            }
            else
            {
                colchange(l, 0, 0, 0, 0);
            }
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            if (jLights.IndexOf(l) >= 6)
            {
                colchange(l, 160, 200, 200);
            }
            else
            {
                colchange(l, 0, 0, 0, 0);
            }
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            if (jLights.IndexOf(l) >= 8)
            {
                colchange(l, 210, 235, 235);
            }
            else
            {
                colchange(l, 0, 0, 0, 0);
            }
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            if (jLights.IndexOf(l) >= 10)
            {
                colchange(l, 255, 255, 255);
            }
            else
            {
                colchange(l, 0, 0, 0, 0);
            }
        }
        yield return new WaitForSeconds(.1f);
        foreach (Transform l in jLights)
        {
            colchange(l, 0, 0, 0, 0);
        }
    }
    void colchange(Transform what, float col1=255, float col2=255, float col3=255, float alpha=255)
    {
        what.gameObject.GetComponent<SpriteRenderer>().color = new Color(col1, col2, col3, alpha);
    }
}
