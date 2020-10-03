using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public List<string> triggerTag;

    public UnityEvent onEnter;
    public UnityEvent onLeave;

    public bool oneTime = false;

    private bool used;
    private void OnTriggerEnter(Collider other)
    {
        if (oneTime && used)
            return;

        if(triggerTag.Contains(other.tag))
        {
            onEnter.Invoke();
        }

        used = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (oneTime && used)
            return;

        if (triggerTag.Contains(other.tag))
        {
            onLeave.Invoke();
        }

        used = true;
    }
}
