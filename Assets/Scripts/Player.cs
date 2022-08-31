using UnityEngine;

public class Player : MonoBehaviour
{
    public float PlayerSpeed;
    private int _hp = 5;
    public int DistBtwTail;
    public GameObject[] PTail;
    int CountOfPoints;
    Vector3[] waypoints;
    public string State = "Roll";

    private void Awake()
    {
        CountOfPoints = DistBtwTail * (PTail.Length + 1);
        waypoints = new Vector3[CountOfPoints];
        SetActiveTail(1);

    }

    private void Update()
    {
        if (State == "Roll") transform.position = transform.position + new Vector3(0, 0, PlayerSpeed * Time.deltaTime);
        for (int i = 0; i < PTail.Length; i++)
        {
            PTail[i].transform.position = waypoints[DistBtwTail*(i+1)];
        }
        Debug.Log(_hp);
    }

    private void FixedUpdate()
    {
        for (int i = CountOfPoints - 1; i > 0; i--)
        {
            waypoints[i] = waypoints[i - 1];
        }
        waypoints[0] = transform.position;
    }

    public int HP
    {
        get { return _hp; }
        set 
        { 
            _hp += value;
            if (_hp >= 1 && _hp < 10) SetActiveTail(1);
            if (_hp >= 10 && _hp < 20) SetActiveTail(2);
            if (_hp >= 20 && _hp < 30) SetActiveTail(3);
            if (_hp >= 30 && _hp < 40) SetActiveTail(4);
            if (_hp >= 40 && _hp < 50) SetActiveTail(5);
            if (_hp >= 50) SetActiveTail(6);
            if (_hp <= 0) Debug.Log("You loose.");
        }
    }

    void SetActiveTail(int i)
    {
        foreach (GameObject go in PTail) go.SetActive(false);

        for(int j = 0; j < i; j++)
        {
            PTail[j].SetActive(true);
        }
    }
}
