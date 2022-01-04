using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance {get; private set;}
    public int Hp = 3;
    public int Damage = 1;
    public float Speed = 2;
    float ShootTimer = 0;
    float ShootDelay = 0.4f;
    public int Boomitem = 3;
    public int Shielditem = 2;
    public bool IsShield = false;
    public GameObject Bullet;
    public GameObject Boom;
    float moveX, moveY;

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
    public void Move()
    {
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");
        Vector3 NowPos = transform.position;
        Vector3 NextPos = new Vector3(H, V, 0) * Speed * Time.deltaTime;
        transform.position = NowPos + NextPos;
    }
    public void CameraIn()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        else if (pos.x > 1f) pos.x = 1f;
        else if (pos.y < 0f) pos.y = 0f;
        else if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    public void Attack()
    {
        if (Input.GetKey(KeyCode.Z) && ShootTimer >= ShootDelay)
        {
            Instantiate(Bullet, this.transform.position, transform.rotation);
            ShootTimer = 0;
        }
        ShootTimer += Time.deltaTime;
    }
}
