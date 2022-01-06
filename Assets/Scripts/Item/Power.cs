using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        this.transform.position -= new Vector3(0, MoveSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            if (Player.Instance.Damage < 3)
            {
                Player.Instance.Damage += 1;
                Destroy(this.gameObject);
            }
            else if (Player.Instance.Damage >= 3)
            {
                Player.Instance.Damage = 3;
                GameManager.Instance.Score += 300;
                Destroy(this.gameObject);
            }
        }
    }
}