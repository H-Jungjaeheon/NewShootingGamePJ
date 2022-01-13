using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdBoss : Enemy
{
    public float MaxMoveCount = 5, MoveCount = 0, MaxPattonCount = 7, PattonCount = 0, MaxHP = 0;
    public GameObject Bullet;
    public GameObject[] PattonSpawn, SpawnEnemy;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            HP = 0;
        }
        if (GameManager.Instance.IsStop == true)
        {
            Speed = 0;
        }
        if (HP <= 0)
        {
            GameManager.Instance.IsClear = true;
        }
    }
    private void FixedUpdate()
    {
        MoveCount += Time.deltaTime;
        PattonCount += Time.deltaTime;
        Dead();
        HpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        NULLHpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        HpSprite.fillAmount = HP / MaxHP;
        if (MoveCount <= MaxMoveCount)
        {
            Move();
        }
        else
        {
            HorizontalMove();
        }
        if (PattonCount >= MaxPattonCount)
        {
            PattonCount = 0;
            patton();
        }
        if(HP < 100)
        {
            if(Speed < 0)
            {
                Speed = -2;
            }
            else
            {
                Speed = 2;
            }
        }
    }
    void patton()
    {
        PattonCount = 0;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(Bullet, PattonSpawn[i].transform.position, transform.rotation);
        }
        Invoke("patton2", 5f);
    }
    void patton2()
    {
        PattonCount = 0;
        for (int i = 3; i < 7; i++)
        {
            Instantiate(Bullet, PattonSpawn[i].transform.position, transform.rotation);
        }
        Invoke("patton3", 5f);
    }
    void patton3()
    {
        PattonCount = 0;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Bullet, PattonSpawn[i].transform.position, transform.rotation);
        }
        for (int i = 4; i < 7; i++)
        {
            Instantiate(Bullet, PattonSpawn[i].transform.position, transform.rotation);
        }
        Invoke("patton4", 5f);
    }
    void patton4()
    {
        PattonCount = 0;       
        int Rand = Random.Range(0, 2);      
        Instantiate(SpawnEnemy[Rand], this.transform.position, transform.rotation);
        Instantiate(SpawnEnemy[Rand], this.transform.position + new Vector3(-0.5f, 0.2f, 0), transform.rotation);
        Instantiate(SpawnEnemy[Rand], this.transform.position + new Vector3(0.5f, 0.2f, 0), transform.rotation);
    }
    public override void Dead()
    {
        base.Dead();
    }
    
    public override void Move()
    {
        base.Move();
    }
    void HorizontalMove()
    {
        this.transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Player.Instance.Hp -= 3;
            Player.Instance.IsHit = true;
        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            HP -= Player.Instance.Damage;
        }
        if (collision.gameObject.tag == ("L,RWall"))
        {
            Speed *= -1;
        }
    }
}
