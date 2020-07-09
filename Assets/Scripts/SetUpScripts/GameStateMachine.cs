using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameStateMachine : MonoBehaviour
{
    public static GameStateMachine Instance;
    public static event Action<Istate> HandleGameStateChange;

    public event Action HandleBeginGame;
    public event Action<IplayerInput> HandleAddingPlayersToGame;

    private Pause _Pause;
    private Play _play;
    private LoadLevel _loadLevel;
    private MainMenu _MainMenu;
    private CharacterSelectionScene _charSelection;

    private static bool Initialised;
    private StateMachine _GameStateMachine;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _GameStateMachine = new StateMachine();

        _GameStateMachine.HandleStateChange += state => HandleGameStateChange?.Invoke(state);

        _Pause = new Pause();
        _play = new Play();
        _loadLevel = new LoadLevel();
        _MainMenu = new MainMenu();
        _charSelection = new CharacterSelectionScene();



        _GameStateMachine.AddTransition(_play, _Pause, () =>  Pause.Active);
        _GameStateMachine.AddTransition(_Pause, _play, () => !Pause.Active);

        _GameStateMachine.AddTransition(_loadLevel, _play, ()=> PlayButton.inPlay && _loadLevel.completed());
        _GameStateMachine.AddTransition(_loadLevel, _charSelection, () => PlayButton.inCharSelection && _loadLevel.completed());
        _GameStateMachine.AddTransition(_charSelection, _loadLevel, () => PlayButton.LeveltoLoad != null);

        _GameStateMachine.AddTransition(_Pause, _MainMenu, () => RestartButton.Pressed);
        _GameStateMachine.AddTransition(_MainMenu, _loadLevel, () => PlayButton.LeveltoLoad != null);

        _GameStateMachine.SetState(_MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        _GameStateMachine.Tick();
    }
    public void AddPlayer(IplayerInput cont)
    {
        HandleAddingPlayersToGame?.Invoke(cont);
    }

}

public class CharacterSelectionScene : Istate
{
    public void OnEnter()
    {

    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
    }
}
