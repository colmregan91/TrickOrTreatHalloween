using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InteractionInfo : MonoBehaviour // state machine?? NO
{
    private TextMeshProUGUI TMPro;
    private interactionStringInfo interactionStringInfo;
    private Image BackgroundPanel;
    public Image FillerImage;
    public float fillAmountSpeed;
    private playerEventHandler eventHandler;
    private Purse purse;
    private void Awake()
    {
        eventHandler = transform.root.GetComponent<playerEventHandler>();

        BackgroundPanel = GetComponent<Image>();
        TMPro = GetComponentInChildren<TextMeshProUGUI>();
        interactionStringInfo = new interactionStringInfo(BackgroundPanel, TMPro);
        HideInfo();

        eventHandler.triggerEnterEvent += ShowInfo;
        eventHandler.triggerExitEvent += HideInfo;
        eventHandler.TakingSweetseEvent += FillImageAwardSweetsWhenFilled;

    }

    private void OnDisable()
    {

        eventHandler.triggerEnterEvent -= ShowInfo;
        eventHandler.triggerExitEvent -= HideInfo;
        eventHandler.TakingSweetseEvent -= FillImageAwardSweetsWhenFilled;
    }

    public void FillImageAwardSweetsWhenFilled()
    {
        FillerImage.enabled = true;
        FillerImage.fillAmount += Time.deltaTime * fillAmountSpeed;
        if (FillerImage.fillAmount >= 1)
        {
            FillerImage.fillAmount = 0;
            FillerImage.enabled = false;
            eventHandler.RaiseAwardSweetsEvent();
        }

    }
    public void ShowInfo(int currentInfoPiece)
    {
        FillerImage.enabled = true;
        interactionStringInfo.ShowInfoPiece(currentInfoPiece);
    }
    public void HideInfo()
    {
        FillerImage.enabled = false;
        FillerImage.fillAmount = 0;
        interactionStringInfo.DisableTxt();
    }
}
