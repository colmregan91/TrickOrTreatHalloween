using UnityEngine;
public class PlayerGetUp : Istate
{
    private animationControl _AnimCont;
    public bool playerisUp = false;
    private getUpBack getupback;
    private getUpFront getupfront;
    bool front;
    public PlayerGetUp(animationControl AnimCont)
    {
        _AnimCont = AnimCont;
        getupback = _AnimCont._PlayerAnimator.GetBehaviour<getUpBack>();
        getupfront = _AnimCont._PlayerAnimator.GetBehaviour<getUpFront>();
    }

    public void OnEnter()
    {
        playerisUp = false;
        _AnimCont._PlayerAnimator.enabled = true;

        front = _AnimCont._RagdollTemplateAnimator.GetBool("Front");

        if (front)
        {
            _AnimCont.PlayAnim("GetUpFront");
        }
        else
        {
            _AnimCont.PlayAnim("GetUpBack");
        }

    }

    public void OnExit()
    {
        playerisUp = false;
        getupback.getUpback = false;
        getupfront.GetUpFront = false;
    }

    public void OnUpdate()
    {
        if (front)
        {
            playerisUp = getupfront.GetUpFront;

        }
        else
        {
            playerisUp = getupback.getUpback;
        }
    }
}