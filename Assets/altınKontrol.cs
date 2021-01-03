using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altınKontrol : MonoBehaviour
{
    public Sprite[] anımasyonKareleri;
    SpriteRenderer spriteRenderer;
    float zaman = 0;
    int altınsayac = 0;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 0.1f)
        {
            spriteRenderer.sprite = anımasyonKareleri[altınsayac++];
            if (anımasyonKareleri.Length == altınsayac)
            {
                altınsayac = anımasyonKareleri.Length - 1;
                altınsayac = 0;
            }
            zaman = 0;
        }
    }
}
