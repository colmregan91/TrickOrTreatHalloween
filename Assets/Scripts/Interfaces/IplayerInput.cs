using System;
using UnityEngine;
public interface IplayerInput
{
    bool isassigned { get; set; }
    float Vertical { get; }
    float Horizontal { get; }

    Vector3 MoveVector { get; }
    float MouseX { get;  }
    
    float MouseY { get;  }
    bool Dodge { get; }
    bool shoot { get; }
    bool pause { get; }
    bool AimingWeapon { get; }
    bool isTakingSweets { get; }

    event Action DodgePressed;// subscribers : animblending, player, constraintcont


}