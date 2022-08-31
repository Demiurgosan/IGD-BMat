using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LooseBotton : MonoBehaviour
{
    public Game Game;
    public void OnBottonClick()
    {
        Game.Restart();
    }
}
