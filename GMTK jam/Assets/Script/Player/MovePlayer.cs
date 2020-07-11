using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("dd");
        if (collision.gameObject.tag == "Enemy")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .3f).setEase(LeanTweenType.easeOutBounce);
            StartCoroutine(wait(gameObject));
        }
    }
    IEnumerator wait(GameObject g)
    {
        yield return new WaitForSeconds(.3f);
        Destroy(g);
    }
}
