using UnityEngine;

public class Pause : Istate
{
    public static bool Active { get; set; }

    public void OnEnter()
    {
        Active = true;

        Time.timeScale = 0;
    }

    public void OnExit()
    {
        Active = false;
        Time.timeScale = 1;
    }

    public void OnUpdate()
    {

    }
}
