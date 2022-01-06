using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAwayEnemy : Enemy
{
    public GameObject EnemyBullet, Player;
    public float MaxShootCount = 5, ShootCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootCount += Time.deltaTime;
        Dead();
        Move();
        Shoot();
    }
    public override void Dead()
    {
        base.Dead();
    }
    public override void Move()
    {
        base.Move();
    }
    public void Shoot()
    {
        if(ShootCount >= MaxShootCount)
        {
            ShootCount = 0;
            Instantiate(EnemyBullet, this.transform.position, transform.rotation);
        }
    }
}
