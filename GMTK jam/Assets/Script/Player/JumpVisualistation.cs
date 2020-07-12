using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpVisualistation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Color jumpColor;
    [SerializeField] private Color atentionColor;
    [SerializeField] private BeatJumper jumper;
    [SerializeField] private float atentionTime;
    [SerializeField] private float jumpTime;

    private AtentionStage atention;
    private Color defaultColor;

    private enum AtentionStage
    {
        Default,Atention,Jump
    }

    private void Start()
    {
        defaultColor = sp.color;
    }

    private void Update()
    {
        switch (atention)
        {
            case AtentionStage.Default:
                if(jumper.JumpTimer <= atentionTime + jumpTime)
                {
                    atention = AtentionStage.Atention;
                }
                break;
            case AtentionStage.Atention:
                sp.color = Color.Lerp(atentionColor,defaultColor, atentionTime + jumpTime/jumper.JumpTimer);
                if(jumper.JumpTimer <= jumpTime)
                {
                    atention = AtentionStage.Jump;
                    sp.color = jumpColor;
                }
                break;
            case AtentionStage.Jump:
                //sp.color = Color.Lerp(defaultColor, defaultColor, atentionTime + jumpTime / jumper.JumpTimer);
                if (jumper.JumpTimer <= jumper.JumpFrequency - 0.1f)
                {
                    atention = AtentionStage.Default;
                    sp.color = defaultColor;
                }
                break;

        }
    }

}
