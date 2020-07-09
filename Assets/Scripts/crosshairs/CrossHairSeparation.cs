using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
public class CrossHairSeparation : MonoBehaviour
{

    [SerializeField] private float maxTarget;
    [SerializeField] private float minTarget;
    [SerializeField] private float TargetWhenAiming = 20;
    [SerializeField] private float crosshairLerpSpeed;

    private crossHair _Crosshair;
    public Image[] CurrentCrosshairImages;
    private Vector2 TargetVector;

    #region targetVectors
    private Vector2 MaxTargetVector => new Vector2(maxTarget, maxTarget);
    private Vector2 MinTargetVector => new Vector2(minTarget, minTarget);
    private Vector2 AimTargetVector => new Vector2(TargetWhenAiming, TargetWhenAiming);
    private Vector2 TopTarget => new Vector2(0, TargetVector.y);
    private Vector2 BottomTarget => new Vector2(0, -TargetVector.y);
    private Vector2 LeftTarget => new Vector2(-TargetVector.x, 0);
    private Vector2 RightTarget => new Vector2(TargetVector.x, 0);
    private Vector2[] TargetVectors => new Vector2[] { TopTarget, BottomTarget, LeftTarget, RightTarget };
    #endregion

    private float lerpMoving;
    private float lerpNotMoving;
    IPlayer Player;
    Transform crosshairholder => transform.Find("Holder");

    private IEnumerator Start()
    {
        Player = transform.root.GetComponent<IPlayer>();

        yield return new WaitUntil(() => Player.initialised == true);
        _Crosshair = GetComponent<crossHair>();
        CurrentCrosshairImages = _Crosshair._crosshairImages;
    }

    private void Update()
    {
        if (Player == null) return;

        bool isMoving = Player.input.MoveVector != Vector3.zero;
        bool isAiming = Player.input.AimingWeapon;

        if (isMoving)
        {
            TargetVector = MaxTargetVector;
        }
        else
        {
            TargetVector = MinTargetVector;
        }

        if (isAiming)
        {
            crosshairLerpSpeed = 20;
            TargetVector = AimTargetVector;
        }
        else
        {
            crosshairLerpSpeed = 6;
        }

        for (int i = 0; i < CurrentCrosshairImages.Length; i++)
        {
            var recticlePart = CurrentCrosshairImages[i].rectTransform;
            recticlePart.localPosition = Vector2.Lerp(recticlePart.localPosition, TargetVectors[i], crosshairLerpSpeed * Time.deltaTime);
        }

        lerpMoving = Mathf.Clamp(lerpMoving, 0, 1);
        lerpNotMoving = Mathf.Clamp(lerpNotMoving, 0, 1);
    }



}
// LIST IN UPDATE LOOP FORMERLY BELOW

//RectTransform top = CurrentCrosshairImages[0].rectTransform;
//top.localPosition = Vector2.Lerp(top.localPosition, TopTarget, crosshairLerpSpeed * Time.deltaTime);

//RectTransform bottom = CurrentCrosshairImages[1].rectTransform;
//bottom.localPosition = Vector2.Lerp(bottom.localPosition, BottomTarget, crosshairLerpSpeed * Time.deltaTime);

//RectTransform left = CurrentCrosshairImages[2].rectTransform;
//left.localPosition = Vector2.Lerp(left.localPosition, LeftTarget, crosshairLerpSpeed * Time.deltaTime);

//RectTransform right = CurrentCrosshairImages[3].rectTransform;
//right.localPosition = Vector2.Lerp(right.localPosition, RightTarget, crosshairLerpSpeed * Time.deltaTime);

//public class RandomPointControl
//{
//    [SerializeField] private Transform _randomPoint;
//    private crossHair _crossHairScr;
//    private Image[] _crosshairImages;
//    public RandomPointControl(Image[] crosshairImages)
//    {
//        _crosshairImages = crosshairImages;
//    }
//    public Vector3 RandomPointTick()
//    {
//        RectTransform TopRecticle = _crosshairImages[0].rectTransform;
//        RectTransform BottomRecticle = _crosshairImages[1].rectTransform;

//        RectTransform leftRecticle = _crosshairImages[2].rectTransform;
//        RectTransform RightRecticle = _crosshairImages[3].rectTransform;

//        float randomPointX = Random.Range(leftRecticle.localPosition.x, RightRecticle.localPosition.x);
//        float randomPointY = Random.Range(TopRecticle.localPosition.y, BottomRecticle.localPosition.y);

//        Vector3 randomPos = new Vector3(randomPointX, randomPointY);
//        _randomPoint.localPosition = randomPos;
//        return randomPos;
//    }
//}