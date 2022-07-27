using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressWToStart : MonoBehaviour
{
    public UnityEvent events;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            events.Invoke();
        }
    }
}
