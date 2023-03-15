using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float drag;
    public GameManager gameManager;
    private Vector3 Teleport;

    [SerializeField] private AudioClip hitSpike;
    [SerializeField] private AudioSource source;

    private Rigidbody2D moveRb;

    private void Start()
    {
        transform.DOScale(new Vector3(0.17f, 0.17f), 1).SetEase(Ease.OutBounce);
        transform.DORotate(new Vector3(0, 0, -720), 1f);
        transform.DOMove(gameObject.transform.position + new Vector3(3.5f, -1f, 0f), 1f);
        gameManager?.BfadeOut(.7f);
        moveRb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float horMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        Vector2 vel = moveRb.velocity;
        vel.x += horMove;
        vel.x *= drag;
        moveRb.velocity = vel;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.DOScale(Vector3.zero, .3f).SetEase(Ease.OutBounce);
            StartCoroutine(wait(gameObject,2));
            source.PlayOneShot(hitSpike);
        }
        else if (collision.gameObject.tag == "Start")
        {
            transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce);
            transform.DORotate(new Vector3(0, 0, -360), .6f);
            //Interesting
            transform.DOMove(gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, 1));
        }
        else if (collision.gameObject.tag == "Base")
        {
            transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce);
            transform.DORotate(new Vector3(0, 0, 360), .6f);
            //Interesting
            transform.DOMove(gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, 3, 1));
        }
        else if (collision.gameObject.tag == "Hallway")
        {
            transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce);
            transform.DORotate(new Vector3(0, 0, -360), .6f);
            //Interesting
            transform.DOMove(gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
        }
        else if (collision.gameObject.tag == "Friendly")
        {
            transform.DOScale(Vector3.zero, .3f).SetEase(Ease.OutBounce);
            StartCoroutine(wait(collision.gameObject, 4, 4, false));
        }
        else if (collision.gameObject.tag == "Spawn")
        {
            transform.DOMove(gameObject.transform.position + new Vector3(1f, 0f, 0f), .5f);
        }
        else if (collision.gameObject.tag == "Dis")
        {
            transform.DOScale(Vector3.zero, .6f).SetEase(Ease.OutBounce);
            wait(collision.gameObject);
        }
        else
        {

        }
    }
    IEnumerator wait(GameObject g, int Stay = 5, int scene = 2, bool a=true)
    {
        if(a)
        {
            gameManager?.BfadeIn(.4f);
        }
        yield return new WaitForSeconds(.6f);
        Destroy(g);
        if (Stay == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Stay == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Stay == 3)
        {
            SceneManager.LoadScene(scene);
        }
        else if (Stay == 4)
        {
            transform.DOScale(Vector3.zero, 1f).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(1);
            transform.position = Teleport;
            transform.DOScale(new Vector3(0.17f, 0.17f), 1).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(1);
        }
        else
        {

        }
    }
}
