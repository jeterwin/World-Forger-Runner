using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public float score;
    public int speed;
    void FixedUpdate()
    {
        score += speed * Time.deltaTime;
        scoreTxt.text = "Score: " + score.ToString("#");
    }
    public void LastScore()
    {

    }

}
