using UnityEngine;

public class HPPoint : MonoBehaviour
{
    public int HPvalue;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            player.HP = HPvalue;
            gameObject.SetActive(false);
        }
    }
}
