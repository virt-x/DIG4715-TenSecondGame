using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem particle = GetComponent<ParticleSystem>();
        particle.Play();
        Destroy(gameObject, particle.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
