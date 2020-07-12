using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public GameManager gameManager;
    public Rigidbody2D rb;

    private void Start()
    {
        LeanTween.scale(gameObject, new Vector3(0.17f, 0.17f), 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.rotateAround(gameObject, Vector3.forward, -720f, 1f);
        LeanTween.move(gameObject, gameObject.transform.position + new Vector3(3.5f, -1f, 0f), 1f);
        gameManager.BfadeOut(.7f);
    }
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .3f).setEase(LeanTweenType.easeOutBounce);
            StartCoroutine(wait(gameObject,2));
        }
        else if (collision.gameObject.tag == "Start")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .6f).setEase(LeanTweenType.easeOutBounce);
            LeanTween.rotateAround(gameObject, Vector3.forward, -360f, .6f);
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, 1));
        }
        else if (collision.gameObject.tag == "Base")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .6f).setEase(LeanTweenType.easeOutBounce);
            LeanTween.rotateAround(gameObject, Vector3.forward, 360f, .6f);
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(-2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, 3, 1));
        }
        else if (collision.gameObject.tag == "Hallway")
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), .6f).setEase(LeanTweenType.easeOutBounce);
            LeanTween.rotateAround(gameObject, Vector3.forward, -360f, .6f);
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(2f, 1f, 0f), .6f);
            StartCoroutine(wait(gameObject, 3, 2));
        }
        else if (collision.gameObject.tag == "Friendly")
        {
            LeanTween.scale(collision.gameObject, new Vector3(0f, 0f), .3f).setEase(LeanTweenType.easeOutBounce);
            StartCoroutine(wait(collision.gameObject, 4, 4, false));
        }
        else if (collision.gameObject.tag == "Spawn")
        {
            LeanTween.move(gameObject, gameObject.transform.position + new Vector3(1, 0f, 0), .5f);
        }
    }
    IEnumerator wait(GameObject g, int Stay = 4, int scene = 2, bool a=true)
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
            SceneManager.LoadScene(sceneBuildIndex: scene);
        }
        else if (Stay == 4)
        {
            LeanTween.scale(gameObject, new Vector3(0f, 0f), 1f).setEase(LeanTweenType.easeOutBounce);
            yield return new WaitForSeconds(1);
            transform.position = new Vector3(7.81f, 2.51f, -3.654236f);
            LeanTween.scale(gameObject, new Vector3(0.17f, 0.17f), 1f).setEase(LeanTweenType.easeOutBounce);
            yield return new WaitForSeconds(1);
        }
        else
        {

        }
    }
}
