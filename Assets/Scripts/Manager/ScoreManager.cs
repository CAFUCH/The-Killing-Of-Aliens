using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score { get; set; }
    private float timer = 1;
    private Text scoretxt = null;
    private Text timertxt = null;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        scoretxt = GameObject.Find("TextCanvas/Score").GetComponent<Text>();
        timertxt = GameObject.Find("TextCanvas/Timer").GetComponent<Text>();
    }
    private void Update()
    {
        scoretxt.text = $"Score : {score}";
        timer += Time.deltaTime;
        timertxt.text = $"PlayTime : {Mathf.Floor(timer)}s";
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Timer", Mathf.Floor(timer));
    }
}
