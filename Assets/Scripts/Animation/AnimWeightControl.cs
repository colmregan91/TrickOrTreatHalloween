using UnityEngine;

public class AnimWeightControl
{
    private readonly Animator _animator;
    private readonly IPlayer _player;
    private const int LegLayerIndex = 2;
    private const int AimingLayerIndex = 3;

    public AnimWeightControl(Animator anim, IPlayer player)
    {
        _animator = anim;
        _player = player;
    }

    public void ControlLegWeight(int target, float lerper)
    {
        float getCurWeight = _animator.GetLayerWeight(LegLayerIndex);
        getCurWeight = Mathf.Lerp(getCurWeight, target, lerper);
        _animator.SetLayerWeight(LegLayerIndex, getCurWeight);
    }

    public void Tick()
    {

        if (_player.inventory.ActiveItem == null || _player.inventory.isLootDropped)
        {
            _animator.SetLayerWeight(AimingLayerIndex, 0);
            return;
        }
        
        if (_player.inventory.ActiveItem.ObjectType is FireworkObject)
        {
            float aimer = _player.input.AimingWeapon == false ? 0.6f : 0.8f;
            float getCurWeight = _animator.GetLayerWeight(AimingLayerIndex);
            getCurWeight = Mathf.Lerp(getCurWeight, aimer, 0.1f);
            _animator.SetLayerWeight(AimingLayerIndex, getCurWeight);
        }

    }

}

//    if (_inventory.ActiveItem != null) // will be changed to if fwork equipped
//    {
//       

//      
//    }



////    _animator.SetLayerWeight(LegLayerIndex, 1);
//}
//else
//{
//  //  _animator.SetLayerWeight(LegLayerIndex, 0);
//    if (_inventory.ActiveItem != null)
//    {
//        _animator.SetLayerWeight(AimingLayerIndex, 0);
//    }
//}


//~AnimWeightControl()
//{
//    //   _player.playerInput.DodgePressed -= SetLegsLayerDown;
//}
//void SeAimingLayerDown(bool no)
//{
//    _animator.SetLayerWeight(AimingLayerIndex, 0);
//}

//void SetLegsLayerDown(bool no)
//{
//    _animator.SetLayerWeight(LegLayerIndex, 0);
//}
//public void ShootAimBlend(bool yes)
//{
//    float prevVal = _animator.GetLayerWeight(AimingLayerIndex);

//    if (_player.playerInput.AimingWeapon == false)
//    {
//        if (yes)
//        {
//            float getCurWeight = _animator.GetLayerWeight(AimingLayerIndex);
//            getCurWeight = Mathf.Lerp(getCurWeight, 1, 0.8f);
//            _animator.SetLayerWeight(AimingLayerIndex, getCurWeight);
//        }
//        else
//        {
//            float getCurWeight = _animator.GetLayerWeight(AimingLayerIndex);
//            getCurWeight = Mathf.Lerp(getCurWeight, 1, 0.8f);
//            _animator.SetLayerWeight(AimingLayerIndex, getCurWeight);
//        }

//    }
//}