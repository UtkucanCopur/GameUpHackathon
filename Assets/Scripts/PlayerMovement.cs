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
        if (collision.tag != "Untagged")
        {
            OnProjectileSave?.Invoke(10);
            Destroy(collision.gameObject);
        }
    }


}
