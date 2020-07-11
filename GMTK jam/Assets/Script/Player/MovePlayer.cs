using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float drag;

    private Rigidbody2D moveRb;


    private void Start()
    {
        moveRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 vel = moveRb.velocity;
        vel.x += Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        vel.x *= drag;
        moveRb.velocity = vel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
