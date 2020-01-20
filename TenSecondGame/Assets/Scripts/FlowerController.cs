using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D flower = gameObject.GetComponent<Rigidbody2D>();
        flower.angularVelocity = Random.value * 300 - 150;
        flower.AddForce(new Vector2(Random.value * 300 - 150, Random.value * -10f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
