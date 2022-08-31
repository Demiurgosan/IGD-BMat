using UnityEngine;

public class Controls : MonoBehaviour
{
    public Player Player;
    public float Speed;
    public float WallDistance;
    private Vector3 _prevMousePos;

    void Update()
    {
        if (Player.State != "Stop" && Input.GetMouseButton(0))
        { 
            Vector3 delta = Input.mousePosition - _prevMousePos;
            Player.transform.position = new Vector3
                (Player.transform.position.x + delta.x * Speed, Player.transform.position.y, Player.transform.position.z);
        }

        if (Player.transform.position.x > WallDistance) Player.transform.position = new Vector3
                (WallDistance , Player.transform.position.y, Player.transform.position.z);
        if (Player.transform.position.x < -WallDistance) Player.transform.position = new Vector3
                (-WallDistance, Player.transform.position.y, Player.transform.position.z);

        _prevMousePos = Input.mousePosition;
    }
}
