using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator agentAnimator;

    private void Awake()
    {
        agentAnimator = GetComponent<Animator>();
    }

    public void PlayerAnimation(PlayerAnimationEnum animationType)
    {
        switch(animationType)
        {
            case PlayerAnimationEnum.die:
                Play("die");
                break;
            case PlayerAnimationEnum.hit:
                Play("hit");
                break;
            case PlayerAnimationEnum.attack:
                Play("attack");
                break;
            case PlayerAnimationEnum.idle:
                Play("Idle");
                break;
            case PlayerAnimationEnum.run:
                Play("Run");
                break;
            case PlayerAnimationEnum.jump:
                Play("jump");
                break;
            case PlayerAnimationEnum.fall:
                Play("fall");
                break;
            case PlayerAnimationEnum.climb:
                Play("climb");
                break;
            case PlayerAnimationEnum.land:
                Play("land");
                break;

            default:
                break;
        }

    }
    public void Play(string name)
    {
        agentAnimator.Play(name, -1, 0f);
    }
}
