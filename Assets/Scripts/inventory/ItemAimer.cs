using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAimer : ItemComponent
{
    [SerializeField] private float aimRange;
    [SerializeField] private float CamDefaultFOV = 70;

    private IplayerInput myPlayerInput;
    private Camera cam;
    private FireworkObject CurrentItem;
    private bool aim;
    private IPlayer _player;
    private inventory _inventory;
    public bool PlayerCanAim;
    private PlayerStateMachine playerStateMachine;
    private float TargetFOV;
    public bool isAiming;
    private void Start()
    {
        _player = transform.root.GetComponent<IPlayer>();
        cam = _player._PlayerCamera;

        myPlayerInput = _player.input;

        playerStateMachine = _player.playerstateMachine;

        playerStateMachine.HandleStateChange += HandleStateChange;

    }
    private void OnDisable()
    {
        playerStateMachine.HandleStateChange -= HandleStateChange;
    }

    void HandleStateChange(Istate state)
    {
        if (state is Idle || state is Running || state is Turning)
        {
            PlayerCanAim = true;
        }
        else
        {
            PlayerCanAim = false;
        }
    }
    private void Update()
    {
        if (Pause.Active) return;

        if (!PlayerCanAim)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, CamDefaultFOV, 0.25f);
            return;
        }

        if (myPlayerInput.AimingWeapon)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, aimRange, 0.25f);

        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, CamDefaultFOV, 0.25f);
        }

    }

    public override void Use<t>(t CurrentHeldItem)
    {
        //if current item is egg or sniper or something t will be used, dont need it now
    }
}
