using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float Score = 0;
    public GameObject[] HpIcon;
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
    }
}
