using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CrossHair")]
public class crosshairDefinition : ScriptableObject
{
    public Sprite Top;
    public Sprite Bottom;
    public Sprite Left;
    public Sprite Right;

    public Sprite[] crossHairHolder => new Sprite[] { Top, Bottom, Left, Right };
}
