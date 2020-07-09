using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(ITemShooter))]
[RequireComponent(typeof(ItemAimer))]
public class Item : MonoBehaviour
{
    [SerializeField] private Sprite icon;
    public Sprite _icon => icon;
    public bool wasPickedUp;
    [SerializeField] private UseAction[] _Actions;
    [SerializeField] private crosshairDefinition _crosshairDefinition;
    public UseAction[] Actions => _Actions;
    private ITemShooter _itemShooter => GetComponent<ITemShooter>();
    private ItemAimer _itemAimer => GetComponent<ItemAimer>();
    public ScriptableObject ObjectType;
    private Collider col;
    private Rigidbody Rb;
    private IPlayer player;

    public crosshairDefinition crosshairDefinition => _crosshairDefinition;

    private void Start()
    {
        col = GetComponent<Collider>();
        Rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other) // turn this into an event subscbribe when equipped
    {
        if (wasPickedUp)
        {
            return;
        }

         player = other.GetComponent<IPlayer>();

        if (player != null)
        {
            Rb.isKinematic = true;
            player.eventHandler.playertoRgdEvent += fall;
            player.eventHandler.RgdtoPlayerEvent += GoBacktoPlayersHand;
            player.inventory.Equip(this);
            wasPickedUp = true;
            _itemShooter.enabled = true;
            _itemAimer.enabled = true;

        }
    }
    private void OnDestroy()
    {
        if (wasPickedUp)
        {
            player.eventHandler.playertoRgdEvent -= fall;
            player.eventHandler.RgdtoPlayerEvent -= GoBacktoPlayersHand;
        }
    }
    void GoBacktoPlayersHand()
    {
        col.isTrigger = true;
        Rb.isKinematic = true;
    }
    void fall()
    {
        Debug.Log("fal");
        col.isTrigger = false;
        Rb.isKinematic = false;
    }
}