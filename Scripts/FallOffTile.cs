using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FallOffTile : MonoBehaviour
{
    public UnityEvent Event;
    public float timeToDisableTile;
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        Invoke("invokeEvent", timeToDisableTile);
    }
    void invokeEvent()
    {
        Destroy(this);
    }
}
