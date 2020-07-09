using UnityEngine;


public class PlayerRotation : IRotate
{
    private readonly Transform _camBase;
    private readonly IPlayer _player;
    private readonly Transform _playerTransform;
    private readonly Transform _aimTarget;

    public PlayerRotation(IPlayer player, Transform camBase, Transform AimTarget)
    {
        _camBase = camBase;
        _player = player;
        _playerTransform = _player.playerTransform;
        _aimTarget = AimTarget;
    }


    public Quaternion getRotationTarget()
    {
        float CameulerAnglesY = _camBase.eulerAngles.y;
        Quaternion targetQuaternion = Quaternion.Euler(0, CameulerAnglesY, 0);
        return targetQuaternion;
    }

    public void RotateWhenMovingTick()
    {
        float CameulerAnglesY = _camBase.eulerAngles.y;
        Quaternion targetQuaternion = Quaternion.Euler(0, CameulerAnglesY, 0);
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, targetQuaternion, 10 * Time.deltaTime); // 10 is turn speed NOT CORRECTLERPING} 


    }

    public void RotateWhenStillTick(Quaternion TargetQuaternion, float percentComplete)
    {

        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, TargetQuaternion, percentComplete); // 10 is turn speed NOT CORRECTLERPING} 
    }

    public void SetRotationFromIdleDodge(Quaternion TargetQuaternion)
    {
        _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, TargetQuaternion, 1);

    }
}


