using UnityEngine;

public class Block : MonoBehaviour
{
    public int BlockHP;
    public TextMesh Text;
    public int BlockHPatStart;
    Renderer GraduationComp;
    float _graduation;

    private void Awake()
    {
        BlockHP = Random.Range(1, 11);
        BlockHPatStart = BlockHP;
        _graduation = (float)BlockHP / 10;
        Debug.Log(_graduation);
        GraduationComp = GetComponent<Renderer>();
        GraduationComp.material.SetFloat(Shader.PropertyToID("_DangerOfBlock"), _graduation);
        
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
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (player.HP > 0&& BlockHP>0)
            {
                BlockHP--;
                player.HP = -1;
            }
            else if (player.HP <= 0)
            {
                gameObject.transform.position += new Vector3(0, 20, 0);
                player.State = "Stop";
            }
            else
            {
                gameObject.transform.position += new Vector3(0, 20, 0);
                player.State = "Roll";
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void Restore()
    {
        BlockHP = BlockHPatStart;
        gameObject.transform.position -= new Vector3(0, 20, 0);
    }
}
