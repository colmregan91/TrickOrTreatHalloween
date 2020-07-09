using UnityEngine;

[RequireComponent(typeof(inventory))]
public class InventoryUse : MonoBehaviour
{
    private inventory _inventory;
    private IPlayer _player;
    private IplayerInput myPlayerInput;
    private void Start()
    {

        _inventory = GetComponent<inventory>();
        _player = GetComponent<IPlayer>();
        myPlayerInput = _player.input;
    }

    private void Update()
    {
        if (_inventory.ActiveItem == null || Pause.Active) return;

        foreach (var UseAction in _inventory.ActiveItem.Actions)
        {
            if (UseAction.TargetComponent.CanUse && WasPressed(UseAction.useMode))
            {
                ItemComponent Target = UseAction.TargetComponent;
                Target.Use(_inventory.ActiveItem.ObjectType);

            }

        }


    }

    private bool WasPressed(UseMode useMode)
    {
        switch (useMode)
        {
            case UseMode.leftClick:
                return myPlayerInput.shoot;
            case UseMode.RightClick:

                return myPlayerInput.AimingWeapon;


        }

        return false;
    }
}