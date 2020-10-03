using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string triggerTag;

    public UnityEvent onEnter;
    public UnityEvent onLeave;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(triggerTag))
        {
            onEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            onLeave.Invoke();
        }
    }
}
