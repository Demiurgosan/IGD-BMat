using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishReach : MonoBehaviour
{
    public Game Game;

    private void OnTriggerEnter(Collider other)
    {
        Game.Finish();
    }
}
