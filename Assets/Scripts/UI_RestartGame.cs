using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RestartGame : MonoBehaviour
{
    public Game game;

    public void OnBottonClick()
    {
        Game.RestartGame();
    }
}
