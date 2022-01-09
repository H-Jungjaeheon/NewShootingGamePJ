using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwiceBoss : Enemy
{
    public float MaxMoveCount = 5, MoveCount = 0, MaxPattonCount = 6, PattonCount = 0, MaxHp;
    public GameObject Bullet;
    public GameObject[] PattonSpawn;
    public Image HpSprite, NULLHpSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCount += Time.deltaTime;
        PattonCount += Time.deltaTime;
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
        if (PattonCount >= MaxPattonCount)
        {
            PattonCount = 0;
            patton();
        }
    }
    public void patton()
    {
        Instantiate(Bullet, PattonSpawn[0].transform.position, transform.rotation);
        Instantiate(Bullet, PattonSpawn[2].transform.position, transform.rotation);
        Instantiate(Bullet, PattonSpawn[4].transform.position, transform.rotation);
        Instantiate(Bullet, PattonSpawn[6].transform.position, transform.rotation);
        Invoke("patton2", 5);
    }
    void patton2()
    {
        PattonCount = 0;
        Instantiate(Bullet, PattonSpawn[1].transform.position, transform.rotation);
        Instantiate(Bullet, PattonSpawn[3].transform.position, transform.rotation);
        Instantiate(Bullet, PattonSpawn[5].transform.position, transform.rotation);
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
