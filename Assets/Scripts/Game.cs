using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Player Player;
    public Transform Floor;
    public Transform Finish;
    public GameObject Block;
    public GameObject HPPoint;

    public Vector3 StartPosition;
    public int DistanceBtwBarriers;

    List<GameObject> ArrayOfElements = new List<GameObject>();
    int currentLVL=1;
    int difficalty=5;
    int currentHP;

    private void Awake()
    {
        Application.targetFrameRate = 50;
    }

    void Start()
    {
        CreateLVL();
    }

    internal void FinishLVL()
    {
        Player.State = "Stop";
        Debug.Log("FINISH");
    }

    private void CreateLVL()
    {
        Floor.localScale = new Vector3(1, 1, difficalty + 1);
        //препятствия
        for(int i = 2; i < difficalty+1; i++)//этап
        {
            for(int j = -4; j < 5; j += 2)//элемент этапа
            {
                if (Random.Range(0, 3) == 0) ;
                else
                {
                    GameObject Element = Instantiate(Block, transform);
                    Element.transform.position = new Vector3(j, 0.5f, i * 10);
                    ArrayOfElements.Add(Element);
                }
                
            }
            
        }
        //еда
        for(int i = 2; i < difficalty+1; i++)//промежуток этапов
        {
            for (int j = -4; j < 5; j += 2)//элемент промежутка
            {
                if (Random.Range(0, 4) == 0)
                {
                    GameObject Element = Instantiate(HPPoint, transform);
                    Element.transform.position = new Vector3(j, 0.5f, i * 10+5);
                    ArrayOfElements.Add(Element);
                }

            }
        }
        Finish.position = new Vector3(0, 0.1f, (difficalty + 1) * 10);
    }
}
