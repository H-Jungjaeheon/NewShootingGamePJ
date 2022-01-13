using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem particleObject;
    // Start is called before the first frame update
    void Start()
    {
        particleObject.Play();
        Invoke("End", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void End()
    {
        Destroy(this.gameObject);
    }
}
