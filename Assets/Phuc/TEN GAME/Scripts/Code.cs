using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour
{
   float score;
    void Start()
    {
        //score += 10;
        //PlayerPrefs.SetFloat("score",score);
        //Debug.Log(score);
        //float _Score = PlayerPrefs.GetFloat("score");
        //Debug.Log(_Score);
        score = PlayerPrefs.GetFloat("score", 0);
        score += 10;
        PlayerPrefs.SetFloat("score", score);
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
