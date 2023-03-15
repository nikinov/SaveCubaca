using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public LayerMask ground;
    public Transform feetpos;
    public float min;
    public bool isgrounded=true;
    private float c;
    void Start()
    {
        StartCoroutine(changejumpkey(1));
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics2D.OverlapCircle(new Vector2(feetpos.position.x,feetpos.position.y), min, ground);
        float v = Input.GetAxis("Horizontal");
        transform.Translate(v * 2 * Time.deltaTime, 0, 0);
       if(c==1)
        {
            if (isgrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }
        }
       if(c==2)
        {
            if(isgrounded&&Input.GetKeyDown(KeyCode.V))
            {
                rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }
        }
      
    }
    IEnumerator changejumpkey(float time)
    {
        yield return new WaitForSeconds(6);
        c = Random.Range(1, 3);
        Debug.Log(c);
        StartCoroutine(changejumpkey(1));

    }
}
