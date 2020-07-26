using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class constrants : MonoBehaviour
{
    //private AimConstraint _aimConstraint;
    //private playerEventHandler eventHandler;
    //private IplayerInput myPlayerInput;
    //private IPlayer _player;
    //private PlayerStateMachine playerstateMachine;
    //private bool PlayerHasItem = false;
    //private ITemShooter itemShooter;
    //private bool isConstraintsDisabled;


    //void HandleStateChange(Istate state)
    //{
    //    if (state is DodgeFromIdleState || state is dodgeFromMoving)
    //    {

    //        SwitchOff();
    //        isConstraintsDisabled = true;
    //    }
    //    else
    //    {
    //        isConstraintsDisabled = false;
    //    }

    //}

    //private void Awake()
    //{

    //    _aimConstraint = GetComponent<AimConstraint>();
    //}
    //// Start is called before the first frame update
    //IEnumerator Start()
    //{
    //    _player = transform.root.GetComponent<IPlayer>();
    //    yield return new WaitUntil(() => _player.initialised == true);
    //    myPlayerInput = _player.input;

    //    playerstateMachine = _player.playerstateMachine;
    //    eventHandler = _player.eventHandler;
    //    eventHandler.HandleItemChange += handleItemPickedUp;

    //    playerstateMachine.HandleStateChange += HandleStateChange;

    //}

    //private void OnDisable()
    //{
    //    eventHandler.HandleItemChange -= handleItemPickedUp;

    //    playerstateMachine.HandleStateChange -= HandleStateChange;
    //}

    //void handleItemPickedUp(Item item)
    //{
    //    itemShooter = item.gameObject.GetComponent<ITemShooter>();
    //    PlayerHasItem = true;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Pause.Active) return;

    //    if (!PlayerHasItem)
    //    {
    //        SwitchOff();
    //        return;
    //    }
    //    //   Aim();
    //    //if (isConstraintsDisabled)
    //    //    return;


    //    if (itemShooter.isShooting)
    //    {
    //        StopCoroutine("ResetAimDelay");
    //        SnapAim();
    //        return;
    //    }



    //    if (myPlayerInput.AimingWeapon)
    //    {
    //        StopCoroutine("ResetAimDelay");
    //        Aim();
    //        return;
    //    }

    //    if (Input.GetKeyUp(KeyCode.Mouse1) || itemShooter.isRoundFinished)
    //    {
    //        StartCoroutine("ResetAimDelay");
    //    }
    //}

    //void SnapAim()
    //{
    //    if (_aimConstraint.weight >= 1)
    //    {
    //        return;
    //    }
    //    _aimConstraint.enabled = true;
    //    _aimConstraint.weight = 1;
    //}

    //void Aim()
    //{
    //    if (_aimConstraint.weight >= 1)
    //    {
    //        return;
    //    }
    //    _aimConstraint.enabled = true;
    //    _aimConstraint.weight += 5f * Time.deltaTime;

    //}


    //void SwitchOff()
    //{
    //    _aimConstraint.enabled = false;
    //    _aimConstraint.weight = 0;
    //}
    //IEnumerator ResetAimDelay()
    //{
    //    yield return new WaitForSeconds(2f);
    //    if (!myPlayerInput.AimingWeapon)
    //    {
    //        ResetAim();
    //    }
    //}
    //void ResetAim()
    //{
    //    if (_aimConstraint.weight <= 0)
    //    {
    //        SwitchOff();
    //        return;
    //    }

    //    if (_aimConstraint.weight >= 0)
    //    {
    //        _aimConstraint.weight -= 4f * Time.deltaTime;

    //    }
    //}
}
