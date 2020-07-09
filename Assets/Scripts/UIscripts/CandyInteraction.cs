using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyInteraction : MonoBehaviour
{
    public int candyAmount;
    private int CandyinfoIndex = 0;
    private IPlayer player;
    private IplayerInput playerInput;
    private float nextUseTime = 0;
    bool playerEntered;

    public bool CanUse => Time.time >= nextUseTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!CanUse) return;
        playerEntered = true;
        player = other.GetComponent<IPlayer>();

        if (player != null)
        {
            player.eventHandler.RaisetriggerEnterEvent(CandyinfoIndex);

            player.eventHandler.AwardSweetsEvent += HandleAwardSweets;

            playerInput = player.input;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!playerEntered) return;

        player = other.GetComponent<IPlayer>();
        if (player != null)
        {
            playerEntered = false;
            player.eventHandler.AwardSweetsEvent -= HandleAwardSweets;
            player.eventHandler.RaisetriggerExitEvent();
            player = null;
        }
    }

    private void Update()
    {
        if (player == null || !CanUse) return;

        bool isInteracting = playerInput.isTakingSweets;

        if (isInteracting)
        {
            player.eventHandler.RaiseTakingSweetseEvent();
        }
    }

    private void HandleAwardSweets()
    {
        LootSystem.AddCandy(candyAmount);
        player.purse.AddToPurse(candyAmount);

        nextUseTime = Time.time + 5;
    }
}
