using DG.Tweening;
using UnityEngine;

public class TextAnime : MonoBehaviour
{

    void Start()
    {
        StartScalingAnimation();
    }

    private void StartScalingAnimation()
    {
        var seqence = DOTween.Sequence();

        seqence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .8f));
        seqence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), .8f));
        seqence.SetLoops(-1);
        
    }
}