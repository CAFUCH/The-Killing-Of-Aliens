using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Transform minpos = null;
    [SerializeField] Transform maxpos = null;

    public PlayerHP playerHp { get; set; } = null;
    public GameObject player { get; set; } = null;

    public Transform Minpos => minpos;
    public Transform Maxpos => maxpos;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        playerHp = GameObject.Find("Player").GetComponent<PlayerHP>();
        player = GameObject.Find("Player");
    }
}
