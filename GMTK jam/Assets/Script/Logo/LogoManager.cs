using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LogoManager : MonoBehaviour
{
    public TMP_Text madeBy0;
    public TMP_Text madeBy1;
    public TMP_Text madeBy2;
    public TMP_Text madeBy3;
    public TMP_Text Mission0;
    public TMP_Text Mission1;
    public TMP_Text Mission2;

    public CanvasGroup BlackPanel;

    string miss0 = "LOCATION: CUBE LAND";
    string misss0;
    string miss1 = "SPIKE ATACK DAY: 3254 AFTER CUBACA CTEATION";
    string misss1;
    string miss2 = "MISSION: FIND ALL CUBACA PIECES TO RESTORE PIECE AND ORDER";
    string misss2;

    private void Start()
    {
        var fadeAnimation = DOTween.Sequence();
        fadeAnimation.Append(madeBy0.DOFade(1, 1).SetLoops(2, LoopType.Yoyo));
        fadeAnimation.Append(madeBy1.DOFade(1, 1).SetLoops(2, LoopType.Yoyo));
        fadeAnimation.Append(madeBy2.DOFade(1, 1).SetLoops(2, LoopType.Yoyo));
        fadeAnimation.Append(madeBy3.DOFade(1, 1).SetLoops(2, LoopType.Yoyo));
        fadeAnimation.OnComplete(() => StartCoroutine(TextApear()));
        
    }
    IEnumerator TextApear()
    {
       

        foreach (char st in miss0)
        {
            misss0 += st;
            Mission0.text = misss0 + "|";
            yield return new WaitForSeconds(.1f);
        }
        Mission0.text = misss0;
        foreach (char st in miss1)
        {
            misss1 += st;
            Mission1.text = misss1 + "|";
            yield return new WaitForSeconds(.1f);
        }
        Mission1.text = misss1;
        foreach (char st in miss2)
        {
            misss2 += st;
            Mission2.text = misss2 + "|";
            yield return new WaitForSeconds(.1f);
        }
        Mission2.text = misss2;

        BlackPanel.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene(sceneBuildIndex: 2));
        
    }
}
