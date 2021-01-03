using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canKutusu : MonoBehaviour
{
    public Sprite[] anımasyonKareleri;
    SpriteRenderer spriteRenderer;
    float zaman = 0;
    int aksayac = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

 
    void Update()
    {
        zaman += Time.deltaTime;
            if (zaman>0.1f)
        {
            spriteRenderer.sprite = anımasyonKareleri[aksayac++];
            if (anımasyonKareleri.Length==aksayac)
            {
                aksayac = anımasyonKareleri.Length - 1;

            }
            zaman = 0;
        }
    }
}
