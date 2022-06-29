using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Text scoretxt = null;
    private int score = 0;
    private Text timertxt = null;
    private float timer = 0;
    private void Awake()
    {
        scoretxt = GameObject.Find("TextCanvas/Score").GetComponent<Text>();
        timertxt = GameObject.Find("TextCanvas/Timer").GetComponent<Text>();
    }
    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        timer = PlayerPrefs.GetFloat("Timer", 0);
        scoretxt.text = $"Score : {score}";
        timertxt.text = $"PlayTime : {timer}";
    }
}
