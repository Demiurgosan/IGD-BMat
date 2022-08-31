using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    public Player Player;
    public Vector3 Offset;

    void Update()
    {
        transform.position = new Vector3(0, 0, Player.transform.position.z) + Offset;
        //Vector3 targetPosition = new Vector3(0, 0, Player.transform.position.z) + Offset;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Player.PlayerSpeed* 2 * Time.deltaTime);
    }
}
