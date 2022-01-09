using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnceBoss : Enemy
{
    public float MaxMoveCount = 5, MoveCount = 0, MaxSpawnCount = 6, SpawnCount = 0, MaxHp;
    public GameObject[] SpawnEnemy;
    public Image HpSprite, NULLHpSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCount += Time.deltaTime;
        SpawnCount += Time.deltaTime;
        Dead();
        HpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        NULLHpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        HpSprite.fillAmount = HP / MaxHp;
        if (MoveCount <= MaxMoveCount)
        {
            Move();
        }
        else
        {
            HorizontalMove();
        }
        if(SpawnCount >= MaxSpawnCount)
        {
            Spawn();
        }
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
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.1f) Speed *= -1;
        else if (pos.x > 0.9f) Speed *= -1;
    }
    public void Spawn()
    {
        Instantiate(SpawnEnemy[0], this.transform.position, transform.rotation);
        SpawnCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Player.Instance.Hp -= 3;
        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            HP -= Player.Instance.Damage;
        }
    }
}
