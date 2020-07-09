using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroyParticle : MonoBehaviour
{
    // If true, deactivate the object instead of destroying it
    public bool OnlyDeactivate;

    void OnEnable()
    {
        StartCoroutine("CheckIfAlive");
    }

    IEnumerator CheckIfAlive()
    {
        ParticleSystem ps = this.GetComponent<ParticleSystem>();

        while (true && ps != null)
        {
            yield return new WaitForSeconds(0.5f);
            if (!ps.IsAlive(true))
            {
                if (OnlyDeactivate)
                {
                    transform.parent.gameObject.SetActive(false);
                }
                else
                    GameObject.Destroy(this.gameObject);
                break;
            }
        }
    }
}
