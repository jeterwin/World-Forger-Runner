using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI scoreTxt1;
    public float score;
    public float speed;
    void FixedUpdate()
    {
        score += speed * Time.deltaTime;
        scoreTxt.text = "Score: " + score.ToString("#");
        scoreTxt1.text = "Score: " + score.ToString("#");
    }
    public void LastScore()
    {

    }

}
