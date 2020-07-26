using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAimer : ItemComponent
{
    [SerializeField] private float aimRange;
 private float CamDefaultFOV = 70;

    protected IplayerInput myPlayerInput;
    private Camera cam;
    private FireworkObject CurrentItem;
    private bool aim;
    protected IPlayer _player;
    private inventory _inventory;
    public bool PlayerCanAim;
    private PlayerStateMachine playerStateMachine;
    private float TargetFOV;
    public bool isAiming;
    public virtual void Start()
    {
        _player = transform.root.GetComponent<IPlayer>();
        cam = _player._PlayerCamera;

        myPlayerInput = _player.input;

        playerStateMachine = _player.playerstateMachine;

        playerStateMachine.HandleStateChange += HandleStateChange;

    }
    public virtual void OnDisable()
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
    public virtual void Update()
    {
        if (Pause.Active) return;

        ControlCamZoom();

    }
    void ControlCamZoom()
    {
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
        Debug.Log("using");
    }
}
