using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    public float WallDistance;
    private Vector3 _prevMousePos;

    void Update()
    {
        if (Input.GetMouseButton(0)) 
        { 
            Vector3 delta = Input.mousePosition - _prevMousePos;
            Player.position = new Vector3
                (Player.position.x - delta.x * Speed, Player.position.y, Player.position.z);
        }

        if (Player.position.x > WallDistance) Player.position = new Vector3
                (WallDistance , Player.position.y, Player.position.z);
        if (Player.position.x < -WallDistance) Player.position = new Vector3
                (-WallDistance, Player.position.y, Player.position.z);

        _prevMousePos = Input.mousePosition;
    }
}
