//using System;
//using UnityEngine;
//using UnityEngine.Rendering;

//public class CamRotandPos : IRotate
//{
//    private Player _player;
//    private Transform _CamBase;


//    private float _tiltX;
//    private float _tiltY;
//    private Transform posTarget;
//    private Transform aim;
//    private Vector3 getVec;
//    private bool callOnce;
//    private float rotationX;
//    private float rotationY;
//    private Vector3 target;
//    private float RotationSpeed =2f;

//    public CamRotandPos(Player player, Transform camBase)
//    {
//        _player = player;
//        _CamBase = camBase;
//        posTarget = _player.transform.Find("CamTarget - pos");
//    }

//    public void Tick()
//    {

//        rotationX += _player.playerInput.MouseX * RotationSpeed;
//        rotationY -= _player.playerInput.MouseY * RotationSpeed;
//        rotationY = Mathf.Clamp(rotationY, -30, 30);
//        _CamBase.position = posTarget.position;
//        //  _CamBase.LookAt(target);
//    }

//    public void LateTick()
//    {
//      //  if (!_player.stateControl.FixingCam)
//    //    {
//            _CamBase.rotation = Quaternion.Euler(rotationY, rotationX, 0);
//      //  }
//     //  
//       // Transform aim = _CamBase.Find("AimTarget");
//   //     _CamBase.LookAt();
//        //Vector3 a = aim.pos + o;
//        //  _CamBase.LookAt(a);
//        //Vector3 o = new Vector3(_tiltX, rotationY, 0);
//        //
//    }
//}
