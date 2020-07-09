using TMPro;
using UnityEngine.UI;

public class interactionStringInfo
{


    private string SweetInteractionTxt = "Hold triangle to take sweets!";
    private string[] interactionInfo => new string[] { SweetInteractionTxt };
    private Image _panel;
    private TextMeshProUGUI _tmpro;

    public interactionStringInfo(Image panel, TextMeshProUGUI tmpro)
    {
        _panel = panel;
        _tmpro = tmpro;
    }
    public void ShowInfoPiece(int currentinfoPiece)
    {
        _panel.enabled = true;
        _tmpro.text = interactionInfo[currentinfoPiece];
    }
    public void DisableTxt()
    {
        _panel.enabled = false;
        _tmpro.text = "";
    }
}