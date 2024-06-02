using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private ParticleSystem splash;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            splash.Emit(100);
        }
    }
}
