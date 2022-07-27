using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class O2System : MonoBehaviour
{
    public Image IconO2;
    public float speed;
    public float SprintSpeedO2;
    public float addO2;
    public UnityEvent ranOutOfO2;
    void FixedUpdate()
    {
        IconO2.fillAmount -= Time.deltaTime * speed;
        if (IconO2.fillAmount <= 0.05f)
        {
            ranOutOfO2.Invoke();
            this.enabled = false;
        }
    }
    public void AddO2()
    {
        IconO2.fillAmount += addO2;
    }
}
