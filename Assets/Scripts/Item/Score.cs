using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
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
            GameManager.Instance.Score += 500;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == ("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
