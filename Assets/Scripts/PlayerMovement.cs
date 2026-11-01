using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static event Action<int> OnProjectileSave;

    public float speed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale <= 0f) return;
        Movement();


    }


    private void Movement()
    {
        float movement = Input.GetAxisRaw("Horizontal");


        transform.position += Vector3.right * speed * movement * Time.deltaTime;

        float x = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile1")
        {
            OnProjectileSave?.Invoke(5);
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Projectile2")
        {
            OnProjectileSave?.Invoke(10);
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Projectile3")
        {
            OnProjectileSave?.Invoke(15);
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Bomb")
        {
            PlayerDeadZone.ProjectileHit(20);
            collision.gameObject.SetActive(false);
        }

    }


}
