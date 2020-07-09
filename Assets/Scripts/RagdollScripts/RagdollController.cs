using System.Collections;
using UnityEngine;

public class RagdollController : MonoBehaviour
{

    public Transform Ragdoll;
    public Transform AJ;
    private Player _player => GetComponent<Player>();
    private GameObject ragdollGO;
    private GameObject AJGameObject;
    private Rigidbody AJRB;
    private Rigidbody RagdollRB;
    private animInformationReceiver _animInformationReceiver;


    public Transform camPos;

    public Transform GetUpAJ;
    [HideInInspector] public RagdollEventHandler RdgEventHandler; // do this properly
    private TransformSlerperRagdoll _AnimTemplateSlerper;
    private RagdollSetter _rdgSetter;
   // private RagdollUpdater _rdgUpdater;
    private RagdollCamSlerper _rdgCamSlerp;
    private RagdollTransformData rgdTransData;
    private float SLerpStartTime;
    private float SLerpDuration;

    public bool _slerpCam;
    public bool slerpTransNow;
    // Start is called before the first frame update
    void Awake()
    {
        _animInformationReceiver = GetComponentInChildren<animInformationReceiver>();

        RdgEventHandler = new RagdollEventHandler(AJ, Ragdoll, _animInformationReceiver);
        rgdTransData = new RagdollTransformData();
 //       _rdgSetter = new RagdollSetter(RdgEventHandler, rgdTransData);


     //   ragdollGO = Ragdoll.gameObject;
        AJGameObject = AJ.gameObject;
        RagdollRB = ragdollGO.GetComponent<Rigidbody>();
        AJRB = AJGameObject.GetComponent<Rigidbody>();
        ragdollGO.SetActive(false);

     //   Transform camHolder = GetComponent<Player>()._CamHolder;
        _AnimTemplateSlerper = new TransformSlerperRagdoll(RdgEventHandler, rgdTransData, _animInformationReceiver, AJ, GetUpAJ);

      //  _rdgUpdater = new RagdollUpdater(Spine, transform);
       // _rdgCamSlerp = new RagdollCamSlerper(RdgEventHandler, head, Spine, transform, camHolder);
    }

    // set rdg event
    // cam slerp 
    //anim slerp
    //get up
    // swap cams back

    //public void CallPlayerHitEvent()
    //{
    //    PlayerHit?.Invoke();
    //}

    private IEnumerator RagdollCoRo() 
    {
        
     //  _player.stateControl.isRagdoll = true;


         RdgEventHandler.SetRagdollEv();

        yield return new WaitForSeconds(5f);
        RdgEventHandler.CamSlerpToPositionEv();
        float slrpdurDivider = _rdgCamSlerp._slerpDuration / 3;
        yield return new WaitForSeconds(slrpdurDivider);

        RdgEventHandler.setPlayerEv();
        
        bool getUpVector = _rdgCamSlerp.upwards();

        RdgEventHandler.SetTemplatePoseEv(getUpVector);

        RdgEventHandler.AnimSlerpToPoseEv();

        yield return new WaitForSeconds(_AnimTemplateSlerper.SLerpDuration);
   
        RdgEventHandler.StandUpPlayerEv(getUpVector);

    }
    private void OnEnable()
    {
        RdgEventHandler.PlayerHit += PlayerHitEvent;
        //  RdgEventHandler.PlayerRecovered += CallPlayerRecoveredEvent;
      //  _player.stateControl.isRagdoll = false;

    }
    private void OnDisable()
    {
        RdgEventHandler.PlayerHit -= PlayerHitEvent;
        //    RdgEventHandler.PlayerRecovered -= CallPlayerRecoveredEvent;
        //PlayerRecovered(); Debug.Log("Folly Code here"); // add them to the event
        //_rdgCamSlerp.ResetSlerpCam();
        //_AnimTemplateSlerper.ResetAnimSlerp();
    }


    void PlayerHitEvent()
    {
        StartCoroutine("RagdollCoRo");

    }
    public void CallPlayerRecoveredEvent() // NEED TO MAKE SURE EVERYTHING IS RESET AFTER RAGDOLL
    {

        RdgEventHandler.PlayerRecoveredEv();
     //   _player.stateControl.isRagdoll = false;//subscribe to plyer recovered ev

    }


    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.L))
        {
            //if (!_player.stateControl.isRagdoll)
            //{


            //    RdgEventHandler.PlayerHitEv();

            //}
        }

        //if (_player.stateControl.isRagdoll)
        //{
        // //   _rdgUpdater.Tick();
        //}

        _rdgCamSlerp.Tick();



        _AnimTemplateSlerper.Tick();
    }
}

