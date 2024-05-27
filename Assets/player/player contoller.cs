using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playercontroller : MonoBehaviour
{
    [Header ("Setting")]
    private float horizontalinput;
    private float verticalinput;
    [SerializeField] private AudioSource HitSound;
    [SerializeField] private GameObject prefab;
    [SerializeField] private HealthScript healthScript;
    [SerializeField] private int MinDamageValue = 0;
    [SerializeField] private int DamageValue;
    [SerializeField] private int MaxDamageValue;
    [SerializeField] private int ScoreAnimal = 0;
    public TMP_Text ScoreAnimalText;
    private Animator animator;
    [SerializeField] private GameObject GameOverPanel;
    public bool isAlive = true;
    private Collider _collider;

    [Header ("Setting Character")]
    [SerializeField] private float _speed;
    public float currentSpeed;
    public float walkingSpeed = 2f;
    public float runningSpeed = 6f;

    void Start()
    {
        animator = GetComponent<Animator>();
        HitSound = GetComponent<AudioSource>();
        _collider = GetComponent<BoxCollider>();
        GameOverPanel.SetActive(false);
    }

    /*void Run()
    {
        animationInterpolation = Mathf.Lerp(animationInterpolation, 1.5f, Time.deltaTime * 3);
        animator.SetFloat("X", Input.GetAxis("Horizontal") * animationInterpolation);
        animator.SetFloat("Y", Input.GetAxis("Vertical") * animationInterpolation);

        currentSpeed = Mathf.Lerp(currentSpeed, runningSpeed, Time.deltaTime * 3);
    }*/




    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalinput);//  transform.position += new Vector3(-speed,0,0)
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalinput);  


        animator.SetFloat("X", Input.GetAxis("Horizontal"));
        animator.SetFloat("Y", Input.GetAxis("Vertical"));  
     
        if (transform.position.x > 25)
        {
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -25)
        {
            transform.position = new Vector3(-25, transform.position.y, transform.position.z);
        }
         if (transform.position.z > 30)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 30);
        }
        if (transform.position.z < -15)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -15);
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }

        if (Input.GetKey(KeyCode.C))
        {
            animator.SetBool("Crouch", true);
            GetComponent<BoxCollider>().size = new Vector3(2,1,2);
            GetComponent<BoxCollider>().center = new Vector3(0, 0.1f, 0);

            //collider.size.y = 1.526458;
            //collider.center.y = 1.183514;
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalinput);
                animator.SetFloat("Y_Crouch", Input.GetAxis("Vertical"));
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalinput);
                animator.SetFloat("Y_Crouch", 0);
            }
        }
        else
        {
            GetComponent<BoxCollider>().size = new Vector3(2, 3, 2);
            GetComponent<BoxCollider>().center = new Vector3(0, 1, 0);
            animator.SetBool("Crouch", false);
        }
        

        
        if (Input.GetMouseButtonDown(0))
        {
            if (isAlive == true)
            {
                FireFood();
            }     
        }
        if (healthScript.healthBar.fillAmount <= 0)
        {
            GameOverPanel.SetActive(true);
            animator.SetBool("Death", true);
            Time.timeScale = 0;
            isAlive = false;

        }
    }
    public void FireFood()
        {
            Instantiate(prefab, (transform.position + new Vector3(0, 1, 1)), prefab.transform.rotation);
            HitSound.Play();
            animator.SetTrigger("Shoot");
        }
    void OnCollisionEnter(Collision collision)
    {
        

        print("check");
        if (collision.gameObject.CompareTag("Animal"))
        {
            
            Destroy(collision.gameObject);
            DamageValue = Random.Range(MinDamageValue, MaxDamageValue);
            healthScript.Damage(DamageValue);
        }
    }
    public void IncreaseScoreAnimal()
    {
        ScoreAnimal++;
        ScoreAnimalText.text = ScoreAnimal.ToString();
    }
}