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
            gameObject.transform.position += new Vector3(0, 20, 0);
            GetComponent<AudioSource>().Play();
        }
    }
    public void Restore()
    {
        gameObject.transform.position -= new Vector3(0, 20, 0);
    }
}
