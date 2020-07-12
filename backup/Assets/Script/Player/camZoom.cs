using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoom : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float speed;
    private int zoom;
    [SerializeField] private float corner0;
    [SerializeField] private float corner1;
    private void Start()
    {
        cam = Camera.main;
        zoom = 1;
    }
    private void Update()
    {
        if (zoom == 1)
        {
            if (cam.orthographicSize > 2)
            {
                cam.orthographicSize = cam.orthographicSize - 1 * Time.deltaTime * speed;
                this.transform.position += new Vector3(Time.deltaTime * speed * 1.8f * corner0, Time.deltaTime * speed * corner1);
            }
            else
            {
                cam.orthographicSize = 2;
                zoom = 0;
                StartCoroutine(wait(.5f));
            }
        }
        else if (zoom == 2)
        {
            if (cam.orthographicSize < 5)
            {
                cam.orthographicSize = cam.orthographicSize + 1 * Time.deltaTime * speed;
                this.transform.position += new Vector3(Time.deltaTime * speed * 1.8f * -corner0, Time.deltaTime * speed * -corner1);
            }
            else
            {
                this.transform.position = new Vector3(0, 0, -10);
                cam.orthographicSize = 5;
                zoom = 0;
            }
        }
    }
    IEnumerator wait(float sec)
    {
        yield return new WaitForSeconds(sec);
        zoom = 2;
    }
}