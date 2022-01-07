using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int Score = 0, MonsterDead = 0;
    public bool IsBossSpawn = false;
    public GameObject[] HpIcon, BoomIcon, ShieldIcon;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AllIcon();
        BossSpawn();
    }
    void AllIcon()
    {
        switch (Player.Instance.Hp)
        {
            case 2:
                HpIcon[0].SetActive(false);
                break;
            case 1:
                HpIcon[1].SetActive(false);
                break;
            case 0:
                HpIcon[2].SetActive(false);
                break;
        }
        switch (Player.Instance.Boomitem)
        {
            case 3:
                BoomIcon[0].SetActive(true);
                BoomIcon[1].SetActive(true);
                BoomIcon[2].SetActive(true);
                break;
            case 2:
                BoomIcon[0].SetActive(false);
                BoomIcon[1].SetActive(true);
                BoomIcon[2].SetActive(true);
                break;
            case 1:
                BoomIcon[1].SetActive(false);
                BoomIcon[2].SetActive(true);
                break;
            case 0:
                BoomIcon[0].SetActive(false);
                BoomIcon[1].SetActive(false);
                BoomIcon[2].SetActive(false);
                break;
        }
        switch (Player.Instance.Shielditem)
        {
            case 2:
                ShieldIcon[0].SetActive(true);
                ShieldIcon[1].SetActive(true);
                break;
            case 1:
                ShieldIcon[0].SetActive(false);
                ShieldIcon[1].SetActive(true);
                break;
            case 0:
                ShieldIcon[0].SetActive(false);
                ShieldIcon[1].SetActive(false);
                break;
        }
    }
    void BossSpawn()
    {
        switch (MonsterDead)
        {
            case 25:
                IsBossSpawn = true;
                break;
            case 75:
                IsBossSpawn = true;
                break;
            case 125:
                IsBossSpawn = true;
                break;
        }
    }
}
