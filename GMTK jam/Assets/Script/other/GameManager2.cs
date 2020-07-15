using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{

    public CanvasGroup blackPanel;
    public void BfadeIn(float time)
    {
        blackPanel.DOFade(1,time);
    }
    public void BfadeOut(float time)
    {
        blackPanel.DOFade(0, time);
    }
}
