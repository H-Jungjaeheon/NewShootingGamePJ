using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int Speed = 7;
    public GameObject Warning;
    bool GO = false;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 0;
        warning();
    }
    void warning()
    {
        Instantiate(Warning, this.transform.position, transform.rotation);
        Invoke("Go", 3);
    }
    // Update is called once per frame
    void Update()
    {
        MoveBullet();
        if (GO == true)
        {
            Warning.SetActive(false);
        }
    }
    void MoveBullet()
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
                Destroy(this.gameObject);
            }
            else if (Player.Instance.IsShield == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Go()
    {
        GO = true;
        Speed = 7;
    }
}
