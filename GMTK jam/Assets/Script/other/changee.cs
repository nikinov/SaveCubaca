using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changee : MonoBehaviour
{
    public GameObject portal;
    public GameObject newSpike;
    private void Start()
    {
        newSpike.SetActive(false);
        newSpike.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        newSpike.SetActive(true);
        portal.transform.DOScale(Vector3.zero,1);
        newSpike.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        newSpike.GetComponent<Rigidbody2D>().AddForce(new Vector3(-15,0,0));
        Destroy(gameObject);
        
    }
}
