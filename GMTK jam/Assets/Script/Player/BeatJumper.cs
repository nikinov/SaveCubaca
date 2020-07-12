using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatJumper : MonoBehaviour
{
    [SerializeField] private float jumpFrequency;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDecrier;
    [SerializeField] private float startingTimer;
    public List<lightindi> lit;
    [SerializeField] private ParticleSystem jumpEffect;
    [SerializeField] private ParticleSystem landEffect;
    [SerializeField] private TrailRenderer jumpTrail;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip lendSound;
    [SerializeField] private AudioSource source;

    [SerializeField] private LayerMask groundMask;
    

    public float JumpTimer { get => jumpTimer; }
    public float JumpTimerAnalog { get => jumpTimer/jumpFrequency; }
    public float JumpFrequency { get => jumpFrequency; }

    private float jumpTimer;
    private Rigidbody2D moveRb;
    private bool isLanded;

    private void Start()
    {
        moveRb = GetComponent<Rigidbody2D>();
        jumpTimer = startingTimer;
        isLanded = true;
    }

    private void FixedUpdate()
    {
        jumpTimer -= Time.deltaTime;

        if(moveRb.velocity.y < 0)
        {
            Vector2 vel = moveRb.velocity;
            vel.y *= jumpDecrier;
            moveRb.velocity = vel;
        }

        if (jumpTimer <= .1f)
        {
            foreach (lightindi l in lit)
            {
                l.lightUp();
            }
        }

        IsLanded();

        if (jumpTimer <= 0)
        {
            Jump();
            jumpTimer = jumpFrequency;
        }

        if(!isLanded && Mathf.Abs(moveRb.velocity.magnitude) > 1f)
        {
            jumpTrail.emitting = true;
        }
        else
        {
            jumpTrail.emitting = false;
        }
        
    }

    private void Jump()
    {
        moveRb.velocity += Vector2.up * jumpForce;
        isLanded = false;
        jumpEffect.transform.up = Vector2.up;
        jumpEffect.Play();

        /*Vector2 squsheScale = transform.localScale;
        squsheScale.x /= 1.15f;
        squsheScale.y *= 1.15f;
        Vector3 globalScale = new Vector3();
        globalScale.x = transform.right.x * squsheScale.x + transform.up.x * squsheScale.y;
        globalScale.y = transform.right.y * squsheScale.x + transform.up.y * squsheScale.y;

        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(gameObject, squsheScale, .4f));
        seq.append(LeanTween.scale(gameObject, transform.localScale, .2f));*/


        source.PlayOneShot(jumpSound);
    }
    
    private void IsLanded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, groundMask);
        if(hit)
            Debug.Log(hit.collider.gameObject.name + " dst = " + hit.distance);
        if (hit && hit.distance<.382f) {
            if (!isLanded)
            {
                landEffect.transform.up = Vector2.up;
                landEffect.Play();

                /*Vector2 squsheScale = transform.localScale;
                squsheScale.x *= 1.15f;
                squsheScale.y /= 1.15f;
                Vector3 globalScale = Vector3.one;
                globalScale.x = transform.right.x * squsheScale.x + transform.up.x * squsheScale.y;
                globalScale.y = transform.right.y * squsheScale.x + transform.up.y * squsheScale.y;

                var seq = LeanTween.sequence();
                seq.append(LeanTween.scale(gameObject, squsheScale, .4f));
                seq.append(LeanTween.scale(gameObject, transform.localScale, .2f));*/

                source.PlayOneShot(lendSound);
            }
            isLanded = true;
        }
        else
        {
            isLanded = false;
        }

    }
}
