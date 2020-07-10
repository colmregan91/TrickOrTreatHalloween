using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purse : MonoBehaviour
{
    public int SweetsAmount;
    private playerEventHandler PlayerEventHandler;
    [SerializeField] private Transform Bag;
    int targetAmount;
    private IPlayer player;
    RagdollstateMachine rsm => GetComponent<RagdollstateMachine>();
    public bool CanTake { get { return !rsm.goToRagdoll; } }
    private void Start()
    {
        player = GetComponent<IPlayer>();
        PlayerEventHandler = GetComponent<playerEventHandler>();
        PlayerEventHandler.playertoRgdEvent += DropPurse;
    }
    private void OnDestroy()
    {
        PlayerEventHandler.playertoRgdEvent -= DropPurse;

    }

    public void AddToPurse(int amount)
    {
        SweetsAmount += amount;
        PlayerEventHandler.RaiseHandleSweetPickUp(SweetsAmount);
    }
    public void TakeFromPurse(int amount)
    {
        SweetsAmount -= amount;
        PlayerEventHandler.RaiseHandleSweetDropped(SweetsAmount);
    }

    public void DropPurse()
    {

        LootSystem.PrepDropCandy(SweetsAmount, Bag);
        SweetsAmount = 0;
        PlayerEventHandler.RaiseHandleSweetDropped(SweetsAmount);
    }
}

