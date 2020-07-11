using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float drag;
    public GameManager gameManager;

    private Rigidbody2D moveRb;

    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(0.17f, 0.17f), 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.rotateAround(gameObject, Vector3.forward, -720f, 1f);
        LeanTween.move(gameObject, gameObject.transform.position + new Vector3(3.5f, -1f, 0f), 1f);
        gameManager.BfadeOut(.7f);
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
            StartCoroutine(wait(gameObject,false));
        }
        else if (collision.gameObject.tag == "Start")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .6f).setEase(LeanTweenType.easeOutBounce);
            LeanTween.rotateAround(gameObject, Vector3.forward, -360f, .6f);
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, true));
        }
        else if (collision.gameObject.tag == "Base")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .6f).setEase(LeanTweenType.easeOutBounce);
            LeanTween.rotateAround(gameObject, Vector3.forward, 360f, .6f);
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(-2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, true, 1));
        }
        else if (collision.gameObject.tag == "Spawn")
        {
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(1, 0f, 0), .5f);
        }
    }
    IEnumerator wait(GameObject g, bool Stay = true, int scene = 2)
    {
        gameManager.sBfadeIn(.4f);
        yield return new WaitForSeconds(.6f);
        Destroy(g);
        if (Stay)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -scene + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
