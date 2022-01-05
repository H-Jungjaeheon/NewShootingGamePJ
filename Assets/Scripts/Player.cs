using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    public int Hp = 3, Damage = 1, Boomitem = 3, Shielditem = 2;
    public float Speed = 2, ShootTimer = 0, ShootDelay = 0.4f, moveX, moveY;
    public bool IsShield = false;
    public GameObject[] Bullet;
    public GameObject Boom;

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
        CameraIn();
        Attack();
        UseBoom();
        UseShield();
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (Damage < 3)
            {
                Damage += 1;
            }
            else if(Damage >= 3)
            {
                Damage += 0;
            }
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");
        Vector3 NowPos = transform.position;
        Vector3 NextPos = new Vector3(H, V, 0) * Speed * Time.deltaTime;
        transform.position = NowPos + NextPos;
    }
    void CameraIn()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        else if (pos.x > 1f) pos.x = 1f;
        else if (pos.y < 0f) pos.y = 0f;
        else if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.Z) && ShootTimer >= ShootDelay)
        {
            if (Damage == 1)
            {
                Instantiate(Bullet[0], this.transform.position, transform.rotation);
                ShootTimer = 0;
            }
            else if(Damage == 2)
            {
                Instantiate(Bullet[1], this.transform.position, transform.rotation);
                ShootTimer = 0;
            }
            else if (Damage == 3)
            {
                Instantiate(Bullet[2], this.transform.position, transform.rotation);
                ShootTimer = 0;
            }
        }
        ShootTimer += Time.deltaTime;
    }
    void UseBoom()
    {
        GameObject[] ENEMY = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetKey(KeyCode.X) && Boomitem > 0)
        {
            Boomitem -= 1;
            for (int i = 0; i < ENEMY.Length; i++)
            {
               
            }
        }
    }
    void UseShield()
    {
        if (Input.GetKey(KeyCode.C) && Shielditem > 0)
        {

        }
    }
}
