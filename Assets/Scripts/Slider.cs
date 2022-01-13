using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource Effect_Source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setmusicvolume(float Volume)
    {
        audioSource.volume = Volume;
    }
    public void Effectvolume(float Effect)
    {
        Effect_Source.volume = Effect;
    }
}
