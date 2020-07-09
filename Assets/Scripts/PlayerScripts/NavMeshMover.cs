using UnityEngine;
using UnityEngine.AI;

public class NavMeshMover : IMover // nav mesh mover not used at all, implement the Imover interace if you wqnt alternate ways of moving
{
    private readonly Player _Player;
    private readonly NavMeshAgent _agent;

    public NavMeshMover(Player player)
    {
        _Player = player;
        _agent = _Player.GetComponent<NavMeshAgent>();
        _agent.enabled = true;
    }
    
    public void Tick(float Speed)
    {
        if (UnityEngine.Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition), out var HitInfo))
            {
                _agent.SetDestination(HitInfo.point);
                _agent.speed = Speed;
            }
            
        }
    }
}