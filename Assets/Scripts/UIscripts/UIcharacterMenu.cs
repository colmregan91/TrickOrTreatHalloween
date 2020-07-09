using UnityEngine;

public class UIcharacterMenu : MonoBehaviour
{
    [SerializeField] private UICharacterSelectionPrefab leftPanel;
    [SerializeField] private UICharacterSelectionPrefab rightPanel;

    public UICharacterSelectionPrefab LeftPanel { get { return leftPanel; } }
    public UICharacterSelectionPrefab RightPanel { get { return rightPanel; } }
    public GameObject startGameTxt;

    private playerSelectionMarker[] markers;
    private bool startEnabled;

    private void Awake()
    {
        startGameTxt.SetActive(false);
        markers = GetComponentsInChildren<playerSelectionMarker>();
    }

    private void Update()
    {
        int playersIn = 0;
        int playersLockedIn = 0;
        foreach (var marker in markers)
        {
            if (marker.isPlayerIn)
            {
                playersIn++;
            }
            if (marker.isLockedIn)
            {
                playersLockedIn++;
            }
        }

        startEnabled = playersIn > 0 && playersIn == playersLockedIn;
        startGameTxt.SetActive(startEnabled);
    }

    public void startGame()
    {
        if (startEnabled)
        {
            PlayButton.LoadScene();
            gameObject.SetActive(false);
        }
    }
}
