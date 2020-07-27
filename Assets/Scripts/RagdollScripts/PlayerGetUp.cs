using UnityEngine;
public class PlayerGetUp : Istate
{
    private animationControl _AnimCont;
    public bool SetRagdollInactive = false;
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
        // playerisUp = false;

        _AnimCont.setAnimator(true);
  
        _AnimCont._PlayerAnimator.SetFloat("Speed", 0);
        front = _AnimCont._RagdollTemplateAnimator.GetBool("Front");

        if (front)
        {
            _AnimCont.PlayAnim("faceUp_Getting Up");
        }
        else
        {
            _AnimCont.PlayAnim("faceDwn_GetUp");
        }

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        SetRagdollInactive = _AnimCont._PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunLocomotion");
    //    Debug.Log(_AnimCont._PlayerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}