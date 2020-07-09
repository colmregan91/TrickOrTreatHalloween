using System.Collections;

using UnityEngine;


public class PauseCanvas : MonoBehaviour
{

    [SerializeField] private GameObject PausePanel;

    private void Awake()
    {
        GameStateMachine.HandleGameStateChange += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameStateMachine.HandleGameStateChange -= HandleStateChanged;
    }

    void HandleStateChanged (Istate state)
    {
        PausePanel.SetActive(state is Pause);
    }
}
