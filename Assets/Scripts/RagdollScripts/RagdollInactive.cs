using UnityEngine;

public class RagdollInactive : Istate
{
    private animationControl _animCont;
    //private IBind _PlayerBinding;
    private IPlayer player;
    public RagdollInactive(animationControl animCont)
    {
        _animCont = animCont;
        player = _animCont.GetComponentInParent<IPlayer>();

    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {
        _animCont.setAnimator(false);
    }

    public void OnUpdate()
    {

    }
}
