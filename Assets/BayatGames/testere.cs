using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class testere : MonoBehaviour
{
    GameObject[] gidileceknoktalar;
    bool mesafeyibirkereal = true;
    bool ilerigeri = true;
    Vector3 aradakiMesafe;
    int aradakimesafesayacı = 0;
    
    void Start()
    {
        gidileceknoktalar = new GameObject[transform.childCount];
        for(int i =0; i < gidileceknoktalar.Length; i++)
        {
            gidileceknoktalar[i] = transform.GetChild(0).gameObject;
            gidileceknoktalar[i].transform.SetParent(transform.parent);
        }
    }

    
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 5);
        noktalaraGit();

    }
    void noktalaraGit()
    {
        if (mesafeyibirkereal)
        {
            aradakiMesafe = (gidileceknoktalar[aradakimesafesayacı].transform.position - transform.position).normalized;
            mesafeyibirkereal = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidileceknoktalar[aradakimesafesayacı].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * 10;
        if (mesafe< 0.5f)
        {
            mesafeyibirkereal = true;
            if (aradakimesafesayacı==gidileceknoktalar.Length-1)
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


#if UNITY_EDITOR
    void OnDrawGizmos()
    { for(int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
      for(int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);

        }

    }
#endif
}




#if UNITY_EDITOR
[CustomEditor(typeof(testere))]
    [System.Serializable]

 class testereEditor: Editor
{
    public override void OnInspectorGUI()
    {
        testere script = (testere)target;
        if (GUILayout.Button("ÜRET", GUILayout.Width(100)))
        {
            GameObject yeniObjem = new GameObject();
            yeniObjem.transform.parent = script.transform;
            yeniObjem.transform.position = script.transform.position;
            yeniObjem.name = script.transform.childCount.ToString();
        }
    }
    

}
#endif