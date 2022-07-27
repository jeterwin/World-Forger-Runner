using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerScript : MonoBehaviour
{
    public string Tag;
    public UnityEvent @event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            @event.Invoke();
        }
    }
}
