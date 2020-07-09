using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class sweetAmount : MonoBehaviour
{
    private TextMeshProUGUI Text;
    private playerEventHandler uiBind;
    void Start()
    {
        uiBind = transform.root.GetComponent<playerEventHandler>();
        Text = GetComponent<TextMeshProUGUI>();

        uiBind.HandleSweetPickUp += HandleSweetPickedUp;
        uiBind.HandleSweetDropped += HandleSweetsDropped;

    }
    private void OnDestroy()
    {
        uiBind.HandleSweetPickUp -= HandleSweetPickedUp;
        uiBind.HandleSweetDropped -= HandleSweetsDropped;
    }
    private void HandleSweetPickedUp(int amount)
    {
        Text.text = amount.ToString();
    }
    private void HandleSweetsDropped(int amount)
    {
        Text.text = amount.ToString();
    }
}
