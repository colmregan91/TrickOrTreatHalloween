using UnityEngine;

public class RagdollUpdater
{
    private Transform _RGDSpine;
    private Transform _PlayerHolder;

    public RagdollUpdater(Transform RGDSpine, Transform playerHolder)
    {
        _RGDSpine = RGDSpine;
        _PlayerHolder = playerHolder;
    }

    public void Tick()
    {

        Vector3 raypos = _RGDSpine.position + Vector3.up * 0.01f;
        Ray ray = new Ray(raypos, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
        {
            Vector3 rootPos = new Vector3(hit.point.x, _PlayerHolder.position.y, hit.point.z);

            _PlayerHolder.position = rootPos;
        }
    }

}

