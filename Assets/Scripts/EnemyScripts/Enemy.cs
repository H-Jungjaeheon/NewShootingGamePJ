using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    public GameObject PowerUp, Boom, Shield, Coin;
    public Image HpSprite, NULLHpSprite;
    public int HP, Score, MaxHp;
    public float Speed, MAxHP;

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
        Move();
        Dead();
        HpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        NULLHpSprite.transform.position = this.transform.position + new Vector3(0, 0.8f, 0);
        HpSprite.fillAmount = HP / MAxHP;
    }
    public virtual void Move()
    {
        this.transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }
    public virtual void Dead()
    {
        if (HP <= 0)
        {
            if(GameManager.Instance.IsBossSpawn == false)
            {
                GameManager.Instance.MonsterDead += 1;
            }
            GameManager.Instance.Score += Score;
            int RandItem = Random.Range(0, 10);
            if(RandItem == 0 || RandItem == 1 || RandItem == 2)
            {
                Instantiate(PowerUp, this.transform.position, transform.rotation);
            }
            else if(RandItem == 3 || RandItem == 4)
            {
                Instantiate(Boom, this.transform.position, transform.rotation);
            }
            else if (RandItem == 5)
            {
                Instantiate(Shield, this.transform.position, transform.rotation);
            }
            else if (RandItem == 6 || RandItem == 7 || RandItem == 8)
            {
                Instantiate(Coin, this.transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
    public void BoomHit(int Dmg)
    {
        HP -= Dmg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Bullet"))
        {
            HP -= Player.Instance.Damage;
        }
        if (collision.gameObject.tag == ("Player"))
        {
            if (Player.Instance.IsShield == false)
            {
                Player.Instance.Hp -= 1;
                Player.Instance.IsHit = true;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
