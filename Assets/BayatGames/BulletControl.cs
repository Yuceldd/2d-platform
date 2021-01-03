 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    SlimeKiller slimeKiller;
    Rigidbody2D fizik;

    void Start()
    {
        slimeKiller = GameObject.FindGameObjectWithTag("SlimeKiller").GetComponent<SlimeKiller>();
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(slimeKiller.getYon()*500);
        
    }

   
    void Update()
    {
        
    }
}
