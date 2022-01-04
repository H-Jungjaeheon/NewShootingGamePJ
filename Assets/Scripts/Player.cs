using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 3;
    public int Damage = 1;
    public float Speed = 2;
    public int Boomitem = 3;
    public int Shielditem = 2;
    public bool IsShield = false;
    float moveX, moveY;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraIn();
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
}
