using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
        LeanTween.scale(Player, new Vector3(0.135f, 0.135f), 1.35f).setEase(LeanTweenType.easeOutBounce);
    }
}
