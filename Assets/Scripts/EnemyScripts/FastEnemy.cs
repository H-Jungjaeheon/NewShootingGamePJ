using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastEnemy : Enemy
{
    public GameObject Warning;
    bool GO = false;
    public int MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0;
        warning();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dead();
        HpSprite.transform.position = this.transform.position + new Vector3(0, 0.4f, 0);
        NULLHpSprite.transform.position = this.transform.position + new Vector3(0, 0.4f, 0);
        HpSprite.fillAmount = HP / MAxHP;
        if (GameManager.Instance.IsStop == true)
        {
            Speed = 0;
        }
        else
        {
            Speed = 4;
        }
    }
    void warning()
    {
        //Instantiate(Warning, this.transform.position, transform.rotation);
        Invoke("Go", 4);
    }
    void Go()
    {
        GO = true;
        Speed = 6;
    }
    public override void Dead()
    {
        base.Dead();
    }
    public override void Move()
    {
        if (GO == true)
        {
            Warning.SetActive(false);
            base.Move();
        }
    }
}
