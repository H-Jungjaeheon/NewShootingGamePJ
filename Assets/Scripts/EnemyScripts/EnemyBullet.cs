using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int Speed = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Player.Instance.Hp -= 1;
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        this.transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }
}
