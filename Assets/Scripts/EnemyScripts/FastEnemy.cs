using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    public GameObject Warning;
    bool GO = false;
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
    }
    void warning()
    {
        Instantiate(Warning, this.transform.position, transform.rotation);
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
