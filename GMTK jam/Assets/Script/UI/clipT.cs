using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clipT : MonoBehaviour
{
    [SerializeField] private Transform follow;

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(follow.position);
        this.transform.position = namePos;
    }
}
