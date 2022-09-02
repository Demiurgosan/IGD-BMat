using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Player Player;
    public Transform Floor;
    public Transform Finish;
    public ParticleSystem FinishPS;
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
        LvlText.text = currentLVL.ToString();
        HPText.text = Player.HP.ToString();
    }

    internal void PlayerDied()
    {
        Player.State = "Stop";
        LooseScreen.SetActive(true);
    }

    internal void PlayerWin()
    {
        Player.State = "Stop";
        WinScreen.SetActive(true);
    }

    public void Restart()
    {
        Player.HP = HPonLvlStart;
        Player.transform.position = StartPosition;
        Player.State = "Roll";
        foreach(GameObject element in ArrayOfElements)
        {
            if (element.transform.position.y > 10) 
            {
                if (element.TryGetComponent(out HPPoint hppoint))
                {
                    hppoint.Restore();
                }
                if (element.TryGetComponent(out Block block))
                {
                    block.Restore();
                }
            }
            

        }
        LooseScreen.SetActive(false);
    }

    internal static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLvl()
    {
        currentLVL++;
        difficalty++;
        foreach(GameObject element in ArrayOfElements)
        {
            Destroy(element);
        }
        ArrayOfElements.Clear();
        WinScreen.SetActive(false);
        HPonLvlStart = Player.HP;
        Player.transform.position = StartPosition;
        Player.State = "Roll";
        FinishPS.Stop();
        CreateLVL();
    }

    private void CreateLVL()
    {
        Floor.localScale = new Vector3(1, 1, difficalty + 1);
        //препятствия
        for(int i = 2; i < difficalty+1; i++)//этап
        {
            for(int j = -4; j < 5; j += 2)//элемент этапа
            {
                if (Random.Range(0, 3) == 0) ;//ничего
                else
                {
                    GameObject Element = Instantiate(Block, transform);
                    Element.transform.position = new Vector3(j, 0.5f, i * 10);
                    ArrayOfElements.Add(Element);
                }
                
            }
            
        }
        //еда
        for(int i = 1; i < difficalty+1; i++)//промежуток этапов
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
        FinishPS.transform.position = new Vector3(0, 0, (difficalty + 1) * 10);
    }
}
