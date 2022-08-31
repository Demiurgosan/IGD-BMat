using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WinBotton : MonoBehaviour
{
    public Game Game;

    public void OnBottonClick()
    {
        Game.NextLvl();
    }
}
