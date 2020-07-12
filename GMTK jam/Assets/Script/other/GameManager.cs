using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup blackPanel;
    public CanvasGroup Ptext;
    //public GameObject PausePanel;
    public void BfadeIn(float time)
    {
        LeanTween.alphaCanvas(blackPanel, 1f, time);
    }
    public void BfadeOut(float time)
    {
        LeanTween.alphaCanvas(blackPanel, 0f, time);
    }
    public void PfadeIn(float time)
    {
        LeanTween.alphaCanvas(Ptext, .4f, time);
    }
    public void PfadeOut(float time)
    {
        LeanTween.alphaCanvas(Ptext, .15f, time);
    }
    public void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        PfadeIn(.4f);
        yield return new WaitForSeconds(.4f);
        PfadeOut(.4f);
        yield return new WaitForSeconds(.4f);
        StartCoroutine(wait());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //foreach (Transform t in PausePanel.transform)
            //{

            //}
        }
    }
}
