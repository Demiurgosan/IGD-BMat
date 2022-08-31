using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player Player;
    int currentStage;
    int currentHP;

    private void Awake()
    {
        Application.targetFrameRate = 50;
    }

    void Start()
    {

    }

    internal void Finish()
    {
        Player.State = "Stop";
        Debug.Log("FINISH");
    }
}
