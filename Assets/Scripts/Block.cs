using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMesh Text;
    public int BlockHP;

    private void Awake()
    {
        BlockHP = Random.Range(1, 11);
    }

    private void Update()
    {
        Text.text = BlockHP.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.State = "Stay";
            Debug.Log("On collision enter Block");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (BlockHP > 0)
        {
            BlockHP--;
            if (collision.collider.TryGetComponent(out Player player)) player.HP = -1;
        }
        else
        {
            gameObject.SetActive(false);
            if (collision.collider.TryGetComponent(out Player player))
            {
                if (player.HP == 0) player.State = "Stop";
                else player.State = "Roll";
            }
        }
        Debug.Log("On collision stay Block");
    }
}
