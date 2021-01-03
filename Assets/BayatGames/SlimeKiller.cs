using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SlimeKiller : MonoBehaviour
{
    GameObject[] gidileceknoktalar;
    GameObject karakter;
    RaycastHit2D ray;
   public LayerMask layermask;
    bool mesafeyibirkereal = true;
    bool ilerigeri = true;
    Vector3 aradakiMesafe;
    int aradakimesafesayacı = 0;
    int hız = 5;
    public GameObject bullet;
    float fireRate=10;
   

    void Start()
    {
        gidileceknoktalar = new GameObject[transform.childCount];
        karakter = GameObject.FindGameObjectWithTag("Player");
       
        for (int i = 0; i < gidileceknoktalar.Length; i++)
        {
            gidileceknoktalar[i] = transform.GetChild(0).gameObject;
            gidileceknoktalar[i].transform.SetParent(transform.parent);
        }
    }


    void FixedUpdate()
    {
        KillerGorus();
        
        if (ray.collider.tag=="Player")
        {
            hız = 10;
            fire();
    }
        else
        {
            hız = 3; 
        }

        noktalaraGit();

    }
    void fire()
    {
        fireRate += Time.deltaTime;

        if (fireRate > Random.Range(0.01f, 0.02f))
            {
            
            Instantiate(bullet, transform.position, Quaternion.identity);

            fireRate = 0;

}
        
    }
    void KillerGorus()
    {
        Vector3 rayYonum = karakter.transform.position - transform.position;
        ray = Physics2D.Raycast(transform.position,rayYonum,1000,layermask);
        Debug.DrawLine(transform.position, ray.point, Color.magenta);

    }
    void noktalaraGit()
    {
        if (mesafeyibirkereal)
        {
            aradakiMesafe = (gidileceknoktalar[aradakimesafesayacı].transform.position - transform.position).normalized;
            mesafeyibirkereal = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidileceknoktalar[aradakimesafesayacı].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * hız;
        if (mesafe < 0.5f)
        {
            mesafeyibirkereal = true;
            if (aradakimesafesayacı == gidileceknoktalar.Length - 1)
            {
                ilerigeri = false;
            }
            else if (aradakimesafesayacı == 0)
            {
                ilerigeri = true;
            }
            if (ilerigeri)
            {
                aradakimesafesayacı++;
            }
            else
            {
                aradakimesafesayacı--;
            }

        }

    }
   public  Vector2 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);

        }

    }
#endif
}




#if UNITY_EDITOR
[CustomEditor(typeof(SlimeKiller))]
[System.Serializable]

class SlimeKillerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SlimeKiller script = (SlimeKiller)target;
        if (GUILayout.Button("ÜRET", GUILayout.Width(100)))
        {
            GameObject yeniObjem = new GameObject();
            yeniObjem.transform.parent = script.transform;
            yeniObjem.transform.position = script.transform.position;
            yeniObjem.name = script.transform.childCount.ToString();
        }
        EditorGUILayout.PropertyField(serializedObject.FindProperty("layermask"));
       
        EditorGUILayout.PropertyField(serializedObject.FindProperty("bullet"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();
    }


}
#endif