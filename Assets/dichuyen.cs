using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dichuyen : MonoBehaviour
{
    private bool isrun = true;
    private float trai_phai;
    public float toc_do;
    public Animator animator;
    private Rigidbody2D rb;
    public int docao;
    public float lucnhay = 5;
    private bool duocnhay;
    public Transform _duocnhay;
    public LayerMask san;
    [SerializeField] TMP_Text text;
    /*[SerializeField] int Mau;*/
    [SerializeField] TMP_Text vip;
    [SerializeField] int coin;
    public AudioClip colle;
    public GameObject vang;
    private AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    public bool duocphepnhay;
    public float jum;
    public AudioClip jump;
    public GameObject panelEndGame;



    public void Jum()
    {
        rb.AddForce(Vector2.up * jum, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
       /* Mau = 100;*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger vao: " + other.gameObject.tag);

        if (other.gameObject.tag == "coin")
        {
            audioSource.PlayOneShot(colle);
            coin += 10;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "vip")
        {
            duocphepnhay = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "vip")
        {
            duocphepnhay=false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va cham vao: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "nendat")
        {
           
            animator.SetBool("isGround", true);
            animator.SetBool("isRun", false);
        }
        else if (collision.gameObject.tag == "door")
        {
            SceneManager.LoadScene("Lv2");
        }
        else if (collision.gameObject.tag == "vat")
        {
           
           // Mau -= 20;
            Time.timeScale = 0;
            panelEndGame.SetActive(true);
        }
    }
    public void Restar()
    {
        panelEndGame.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        /*text.SetText("máu : " + Mau);*/
        vip.SetText("Điểm : " + coin);
        duocnhay = Physics2D.OverlapCircle(_duocnhay.position, 0.2f,san);
        
        trai_phai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(trai_phai * toc_do, rb.velocity.y);

        flip();

        animator.SetFloat("move", Mathf.Abs(trai_phai));


        if (Input.GetKeyDown(KeyCode.Space) && duocphepnhay)
        {
            rb.AddForce(Vector2.up * jum, ForceMode2D.Impulse);
        }


    }
    
    void flip()
    {
        if(isrun && trai_phai < 0 || !isrun && trai_phai > 0 ) 
        { 
            isrun = !isrun;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x =kich_thuoc.x * -1;
            transform.localScale = kich_thuoc;
        }
    }

}
