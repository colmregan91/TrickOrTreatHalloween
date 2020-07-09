using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public partial class playerSelectionMarker : MonoBehaviour
{
    [SerializeField] private playerController player;
    [SerializeField] private Image LockImage;
    [SerializeField] private Image SelectionToggleImage;

    private UIcharacterMenu SelectionMenu;
    public bool initialising;
    public bool initialized;

    public bool isLockedIn { get; private set; }
    public bool isPlayerIn { get { return player.hasController; } }

    private void Awake()
    {
        SelectionMenu = GetComponentInParent<UIcharacterMenu>();
        LockImage.gameObject.SetActive(false);
        SelectionToggleImage.gameObject.SetActive(false);
    }

    private void Update()
    {

        if (!isPlayerIn) return;

        if (!initialising)
        {
            StartCoroutine(initialize());
        }
        if (!initialized) return;

        if (player.controller.Dodge)
        {
      
            lockPlayer();
        }

        if (!isLockedIn)
        {
            if (player.controller.Horizontal > 0.5f)
            {
                MoveToPosition(SelectionMenu.RightPanel);
                player.character = SelectionMenu.RightPanel._character;

            }
            else if (player.controller.Horizontal < -0.5f)
            {
                MoveToPosition(SelectionMenu.LeftPanel);
                player.character = SelectionMenu.LeftPanel._character;
            }
        }
        else
        {
            if (player.controller.pause)
            {
                SelectionMenu.startGame();
            }

            if (player.controller.shoot)
            {
                UnlockPlayer();
            }
        }


    }

    private void lockPlayer()
    {

        LockImage.gameObject.SetActive(true);
        isLockedIn = true;
    }
    private void UnlockPlayer()
    {
        LockImage.gameObject.SetActive(false);
        isLockedIn = false;
    }

    private void MoveToPosition(UICharacterSelectionPrefab panel)
    {
        transform.position = panel.transform.position;
    }


    private IEnumerator initialize()
    {
        initialising = true;
        yield return new WaitForSeconds(0.5f);
        SelectionToggleImage.gameObject.SetActive(true);
        initialized = true;
    }
}