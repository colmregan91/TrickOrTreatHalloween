using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadLevel : Istate
{
    public bool completed() => operations.TrueForAll(t => t.isDone); // left in incase more scenes need to be added

    private List<AsyncOperation> operations = new List<AsyncOperation>();

    public void OnEnter()
    {

        operations.Add(SceneManager.LoadSceneAsync(PlayButton.LeveltoLoad));

    }

    public void OnExit()
    {
    
        operations.Clear();
        PlayButton.LeveltoLoad = null;
    }

    public void OnUpdate()
    {
       
    }
}
