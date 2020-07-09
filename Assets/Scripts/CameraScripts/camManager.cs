using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camManager : MonoBehaviour
{
    public CamControl CamCont;
    private Camera rgdCam;
    public Camera PlayerCam;

    [SerializeField] private Transform posTarget;
    public Transform aimTarget;
    private IplayerInput myPlayerInput;
    public float RotationSpeed;
    private RagdollstateMachine _RagdollstateMachine;
    private IPlayer player;
    bool ready;
    private void Awake()
    {
        player = transform.root.GetComponent<IPlayer>();
    }

    private IEnumerator Start()
    {
        Camera _camera = GetComponentInChildren<Camera>();
        CameraSetUp.AddCameraForPlayer(_camera);

        _RagdollstateMachine = transform.root.GetComponent<RagdollstateMachine>();
        _RagdollstateMachine.HandleStateChanged += TakeAwayControl;


        yield return new WaitUntil(() => player.initialised == true);
        IplayerInput input = player.input;
        CamCont = new CamControl(_camera, transform, input, RotationSpeed);
        Invoke("SetReady", 0.1f);

    }
    void SetReady()
    {
        ready = true;
        Detach();
    }

    public void Detach()
    {
        transform.SetParent(null);
    }
    private void OnDisable()
    {
        _RagdollstateMachine.HandleStateChanged -= TakeAwayControl;
    }

    private void Update()
    {
        if (Pause.Active || !ready)
        {
            return;
        }

        CamCont.Tick();
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, posTarget.position, 1f);
    }

    public void TakeAwayControl(Istate state)
    {
        if (CamCont == null) return;
        if (state is CorrectingCameraPositionAndLerpingTransforms)
        {
            CamCont.cancontrol = false;
        }
        if (state is RagdollInactive)
        {
            CamCont.cancontrol = true;
        }

    }
}


