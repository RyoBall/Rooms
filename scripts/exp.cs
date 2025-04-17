using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class exp : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool active;
    public GameObject disappearpart;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (active) 
        {
            rb.velocity = DIR() * speed;
        }
    }
    Vector2 DIR() 
    {
        Vector2 dir;
        dir = -new Vector2(transform.position.x - Player.instance.transform.position.x, transform.position.y - Player.instance.transform.position.y);
        dir = dir.normalized;
        return dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            Instantiate(disappearpart, transform.position, Quaternion.identity);
            Player.instance.exp++;
            Destroy(gameObject);
        }
    }
}
