using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public AudioSource DestroyingSound;
     [Range(0, 50)] public int speed = 20;

    void Start()
    {
        DestroyingSound = GetComponent<AudioSource>();
    }
    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (gameObject.transform.position.z > 40)
        {
            Destroy(gameObject);
            DestroyingSound.Play();
        }
    } 
}