using UnityEngine;

public class UICharacterSelectionPrefab : MonoBehaviour
{
    [SerializeField] private Player character;

    public Player _character { get { return character; } }
}
