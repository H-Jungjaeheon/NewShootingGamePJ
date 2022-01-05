using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
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
            if (Player.Instance.Shielditem < 2)
            {
                Player.Instance.Shielditem += 1;
                Destroy(this.gameObject);
            }
            else if (Player.Instance.Shielditem >= 2)
            {
                Player.Instance.Shielditem = 3;
                GameManager.Instance.Score += 700;
                Destroy(this.gameObject);
            }
        }
    }
}
