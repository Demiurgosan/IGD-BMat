using UnityEngine;

public class FinishReach : MonoBehaviour
{
    public Game Game;
    public ParticleSystem ParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        Game.PlayerWin();
        ParticleSystem.Play();
    }
}
