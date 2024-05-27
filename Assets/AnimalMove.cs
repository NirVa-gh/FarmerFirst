using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour

{
    public float speed;
    private GameObject player;
    public playercontroller PlayerController;
    public HealthScript healthScript;
    public int MinDamageValue = 0;
    private int DamageValue;
    public int MaxDamageValue;

    void Start()
    {
        player = GameObject.Find("player");
        PlayerController = player.GetComponent<playercontroller>();
        healthScript = player.GetComponent<HealthScript>();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < -15)
        {
            Destroy(gameObject);
            DamageValue = Random.Range(MinDamageValue, MaxDamageValue);
            healthScript.Damage(DamageValue);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerController.IncreaseScoreAnimal();
        }
    }
} 
