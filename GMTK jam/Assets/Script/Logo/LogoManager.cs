using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    public TextMeshProUGUI madeBy0;
    public TextMeshProUGUI madeBy1;
    public TextMeshProUGUI madeBy2;
    public TextMeshProUGUI madeBy3;
    public TextMeshProUGUI Mission0;
    public TextMeshProUGUI Mission1;
    public TextMeshProUGUI Mission2;

    public CanvasGroup BlackPanel;

    string miss0 = "LOCATION: CUBE LAND";
    string misss0;
    string miss1 = "SPIKE ATACK DAY: 3254 AFTER CUBACA CTEATION";
    string misss1;
    string miss2 = "MISSION: FIND ALL CUBACA PIECES TO RESTORE PIECE AND ORDER";
    string misss2;

    private void Start()
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        LeanTween.alphaCanvas(madeBy0.gameObject.GetComponent<CanvasGroup>(), 1, 1);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(madeBy0.gameObject.GetComponent<CanvasGroup>(), 0, 1);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(madeBy1.gameObject.GetComponent<CanvasGroup>(), 1, 1);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(madeBy1.gameObject.GetComponent<CanvasGroup>(), 0, 1);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(madeBy2.gameObject.GetComponent<CanvasGroup>(), 1, 1);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(madeBy2.gameObject.GetComponent<CanvasGroup>(), 0, 1);
        yield return new WaitForSeconds(2);
        LeanTween.alphaCanvas(madeBy3.gameObject.GetComponent<CanvasGroup>(), 1, 1);
        yield return new WaitForSeconds(1);
        LeanTween.alphaCanvas(madeBy3.gameObject.GetComponent<CanvasGroup>(), 0, 1);
        yield return new WaitForSeconds(2);
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
        LeanTween.alphaCanvas(BlackPanel, 1, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}
