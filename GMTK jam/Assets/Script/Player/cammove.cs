using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammove : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (Player.position.x - 3 > this.transform.position.x)
        {
            this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * 5, 0, -10);
        }
        else if (Player.position.x + 3 < this.transform.position.x)
        {
            if (Player.position.x > 6)
            {
                this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * -5, 0, -10);
            }
        }
    }
}
