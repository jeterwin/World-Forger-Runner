using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FallOffTile : MonoBehaviour
{
    public UnityEvent Event;
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        Invoke("invokeEvent", 2f);
    }
    void invokeEvent()
    {
        Event.Invoke();
    }
}
