using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBullet : MonoBehaviour
{
    int Speed;
    public GameObject Warning;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0;
        //Instantiate(Warning, transform.position, transform.rotation);
        Invoke("BulltGo", 3f);
    }
    void BulltGo()
    {
        Destroy(Warning);
        Speed = 7;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0, Speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (Player.Instance.IsShield == false)
            {
                Player.Instance.Hp -= 1;
                Player.Instance.IsHit = true;
                Destroy(this.gameObject);
            }
            else if (Player.Instance.IsShield == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
