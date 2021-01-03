    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
//using Packages.Rider.Editor;

public class Karakter_Kontrol : MonoBehaviour
    {
    public Sprite[] Bekleme;
    public Sprite[] Zıplama;
    public Sprite[] Yurume;
    public Text canText;
    public Text altınText;
    public Text bitirme;
    public Image SiyahArkaPlan;

    public int skor=0;
    int can = 100;
    int altın = 0;
    int Beklemesayac=0;
    int Yurumesayac=0;
    int Zıplamasayac=0;
   

    float Horizontal = 0;
    float Beklemezaman = 0;
    float Yurumezaman = 0;
    float siyaharkaplansayacı = 0;
    float AnaMenuZaman = 0;

    bool birzıpla = true;
    Rigidbody2D fizik;

    Vector3 vec;
    Vector3 kamera1;
    Vector3 kamera2;

    GameObject kamera;
    GameObject Sound;


    SpriteRenderer spriteRenderer;
        void Start()
        {
        
        Time.timeScale = 1;
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent <  Rigidbody2D>();
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (SceneManager.GetActiveScene().buildIndex> PlayerPrefs.GetInt("whichLevel"))
        {
         PlayerPrefs.SetInt("whichLevel", SceneManager.GetActiveScene().buildIndex) ;
        }
        
        kamera1 = kamera.transform.position - transform.position;
        canText.text = "Health " + can;
       altınText.text = "Gold:" + altın;
        }
    private void Update()
    {
        canText.text = "Health " + can;
        //sınırsız zıplama engelleme
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (birzıpla)
            {
fizik.AddForce(new Vector2(0, 1500));
                birzıpla = false; 
            }
            
        }

    }


    void FixedUpdate()
        {

        KarakterHareket();
        Animasyon();
        if (can<=0)
        {
            Time.timeScale = 0.3f;
            canText.enabled = false;
            siyaharkaplansayacı += 0.03f;
            SiyahArkaPlan.color = new Color(0, 0, 0, siyaharkaplansayacı);
            AnaMenuZaman += Time.deltaTime;
            if (AnaMenuZaman>1)
            {
                SceneManager.LoadScene("AnaMenu"); 
            }
        }
        }
    void LateUpdate()
    {
        KameraKontrol();

    }
    void KarakterHareket()
    {
     
        Horizontal = Input.GetAxisRaw("Horizontal");
       
     
        vec = new Vector3(Horizontal * 10, fizik.velocity.y, 0);
     
        fizik.velocity = vec;
     
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        birzıpla = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Bullet")
        {
            can--; 
            canText.text = "Health  " + can;
        }
        if (col.gameObject.tag == "SlimeKiller")
        {
            can-=10;
            canText.text = "Health  " + can;
        }
        if (col.gameObject.tag == "testere")
        {
            
            can -= 10;
            canText.text = "Health  " + can;
        }
        if (col.gameObject.tag == "levelBıtıs")
        {
            if (altın == 15)
            {
                skor++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                
            }
            else if (altın <= 15)
            {

                bitirme.text = ("Not Enough Gold!!!!!!");
            }
        }
        if (col.gameObject.tag == "canVer")
        {
       
            can+=10;
            canText.text = "Health  " + can;
            col.GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponent<canKutusu>().enabled = true;
            Destroy(col.gameObject, 2);
        }
        if (col.gameObject.tag == "Altın")
        {
            altın++;
            altınText.text = " Gold:" + altın ;
            col.GetComponent<BoxCollider2D>().enabled = false;
            
            Destroy(col.gameObject, 0.1f);
            if (altın == 15)
            {
                altınText.text = "Go to the door!!!!";
            }
                

        }
        if (col.gameObject.tag == "Water")
        {
            
            can -= 10;
            canText.text = "Health  " + can;
        }
    }
    void KameraKontrol()
    {
        kamera2 = kamera1 + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position,kamera2,0.1f);

    }
    void Animasyon()
    {
        if (birzıpla)
      { 
        if (Horizontal == 0)
        {
            Beklemezaman += Time.deltaTime;
            if (Beklemezaman > 0.05f)
            {


                spriteRenderer.sprite = Bekleme[Beklemesayac++];
                if (Beklemesayac == Bekleme.Length)
                {
                    Beklemesayac = 0;
                }
                Beklemezaman = 0;
            }
        }
        else if (Horizontal > 0)
        {
            Yurumezaman += Time.deltaTime;
            if (Yurumezaman > 0.01f)
            {
                spriteRenderer.sprite = Yurume[Yurumesayac++];
                if (Yurumesayac == Yurume.Length)
                {
                    Yurumesayac = 0;
                }
                Yurumezaman = 0;
            }
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Horizontal < 0)
        {
            Yurumezaman += Time.deltaTime;
            if (Yurumezaman > 0.01f)
            {
                spriteRenderer.sprite = Yurume[Yurumesayac++];
                if (Yurumesayac == Yurume.Length)
                {
                    Yurumesayac = 0;
                }
                Yurumezaman = 0;
            }
            transform.localScale = new Vector3(-1, 1, 1);
        }
      }
        else
        {
         spriteRenderer.sprite = Zıplama[0];
            if (Horizontal > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    
}
