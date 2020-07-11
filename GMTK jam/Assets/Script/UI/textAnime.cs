using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAnime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());

    }

    IEnumerator wait()
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), .8f);
        yield return new WaitForSeconds(.8f);
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), .8f);
        yield return new WaitForSeconds(.8f);
        StartCoroutine(wait());
    }
}