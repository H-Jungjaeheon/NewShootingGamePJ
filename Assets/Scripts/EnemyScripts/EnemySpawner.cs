using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemy, Spawn;
    public float MaxSpawnCount, SpawnCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCount += Time.deltaTime;
        Enemyspawner();
    }
    void Enemyspawner()
    {
        if(SpawnCount >= MaxSpawnCount)
        {
            int EnemyRand = Random.Range(0, 4);
            int SpawnRand = Random.Range(0, 7);
            Instantiate(Enemy[EnemyRand], Spawn[SpawnRand].transform.position, transform.rotation);
            SpawnCount = 0;
        }
        if(GameManager.Instance.MonsterDead >= 50 && GameManager.Instance.MonsterDead < 100)
        { 
            MaxSpawnCount = 5;
        }
        else if (GameManager.Instance.MonsterDead >= 100)
        {
            MaxSpawnCount = 2;
        }
    }
}
