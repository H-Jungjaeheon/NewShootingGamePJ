using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EditorOnly")
        {
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
        if (GameManager.Instance.IsStop == true)
        {
            Speed = 0;
        }
        else
        {
            Speed = 6;
        }
    }
    void MoveBullet()
    {
        this.transform.position += new Vector3(0, Speed * Time.deltaTime, 0);
    }
}
