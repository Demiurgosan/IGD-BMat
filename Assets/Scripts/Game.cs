using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player Player;
    public Transform Floor;
    public Transform Finish;
    public GameObject Block;
    public GameObject HPPoint;
    public GameObject WinScreen;
    public GameObject LooseScreen;
    public Text LvlText;
    public Text HPText;

    public Vector3 StartPosition;
    public int DistanceBtwBarriers;

    List<GameObject> ArrayOfElements = new List<GameObject>();
    int currentLVL=1;
    int difficalty=5;
    int HPonLvlStart;

    private void Awake()
    {
        Application.targetFrameRate = 50;
    }

    void Start()
    {
        LvlText.text = currentLVL.ToString();
        CreateLVL();
        HPonLvlStart = Player.HP;
    }
    private void Update()
    {
        HPText.text = Player.HP.ToString();
    }

    internal void PlayerDied()
    {
        Player.State = "Stop";
        LooseScreen.SetActive(true);
    }

    public void Restart()
    {
        Player.HP = HPonLvlStart;
        Player.transform.position = StartPosition;
    }

    internal void FinishLVL()
    {
        Player.State = "Stop";
        Debug.Log("FINISH");
    }

    private void CreateLVL()
    {
        Floor.localScale = new Vector3(1, 1, difficalty + 1);
        //�����������
        for(int i = 2; i < difficalty+1; i++)//����
        {
            for(int j = -4; j < 5; j += 2)//������� �����
            {
                if (Random.Range(0, 3) == 0) ;//������
                else
                {
                    GameObject Element = Instantiate(Block, transform);
                    Element.transform.position = new Vector3(j, 0.5f, i * 10);
                    ArrayOfElements.Add(Element);
                }
                
            }
            
        }
        //���
        for(int i = 1; i < difficalty+1; i++)//���������� ������
        {
            for (int j = -4; j < 5; j += 2)//������� ����������
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
