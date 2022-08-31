using UnityEngine;

public class HPPoint : MonoBehaviour
{
    public int HPvalue;
    public TextMesh Text;

    private void Awake()
    {
        HPvalue = Random.Range(1, 4);
        Text.text = HPvalue.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out Player player))
        {
            player.HP = HPvalue;
            gameObject.SetActive(false);
        }
    }
}
