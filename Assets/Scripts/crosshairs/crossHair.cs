using UnityEngine;
using UnityEngine.UI;

public class crossHair : MonoBehaviour
{
    [SerializeField] private Transform crosshairImageHolder;
    [SerializeField] private Image[] crosshairImages;
    public Image[] _crosshairImages => crosshairImages;
    // [SerializeField] private playerSettings settings;
    bool playerhasItem = false;
    private playerEventHandler uibind;
    private CrossHairSeparation CHsepsration;
    [SerializeField] private Transform RandomPointVisual;
    private void Start()
    {
        uibind = transform.root.GetComponent<playerEventHandler>();
        CHsepsration = GetComponent<CrossHairSeparation>();
        uibind.HandleItemChange += HandleActiveTiemChange;
        uibind.playertoRgdEvent += HandleDropLoot;
        uibind.RgdtoPlayerEvent += HandlePickUPLoot;
    }
    private void OnDisable()
    {
        uibind.HandleItemChange -= HandleActiveTiemChange;
        uibind.playertoRgdEvent -= HandleDropLoot;
        uibind.RgdtoPlayerEvent -= HandlePickUPLoot;
    }

    private void HandleActiveTiemChange(Item item)
    {
        playerhasItem = true;
        for (int i = 0; i < crosshairImages.Length; i++)
        {

            crosshairImages[i].sprite = item.crosshairDefinition.crossHairHolder[i];
        }

        if (!crosshairImageHolder.gameObject.activeSelf)
        {
            crosshairImageHolder.gameObject.SetActive(true);
        }

    }
    private void HandleDropLoot()
    {
        if (playerhasItem)
            crosshairImageHolder.gameObject.SetActive(false);
    }
    private void HandlePickUPLoot()
    {
        if (playerhasItem)
            crosshairImageHolder.gameObject.SetActive(true);
    }

    public Vector3 RandomPointTick()
    {
        RectTransform TopRecticle = CHsepsration.CurrentCrosshairImages[0].rectTransform;
        RectTransform BottomRecticle = CHsepsration.CurrentCrosshairImages[1].rectTransform;

        RectTransform leftRecticle = CHsepsration.CurrentCrosshairImages[2].rectTransform;
        RectTransform RightRecticle = CHsepsration.CurrentCrosshairImages[3].rectTransform;

        float randomPointX = Random.Range(leftRecticle.localPosition.x, RightRecticle.localPosition.x);
        float randomPointY = Random.Range(TopRecticle.localPosition.y, BottomRecticle.localPosition.y);

        Vector3 randomPos = new Vector3(randomPointX, randomPointY);
        RandomPointVisual.position = randomPos;
        return RandomPointVisual.localPosition.normalized;
    }
}
