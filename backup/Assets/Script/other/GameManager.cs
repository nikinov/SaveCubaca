using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup blackPanel;
    public void BfadeIn(float time)
    {
        LeanTween.alphaCanvas(blackPanel, 1f, time);
    }
    public void BfadeOut(float time)
    {
        LeanTween.alphaCanvas(blackPanel, 0f, time);
    }
}
