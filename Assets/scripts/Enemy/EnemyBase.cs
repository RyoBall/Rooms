using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public float health;
    public GameObject deadparticle;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        move();
        Dead();
    }
    public virtual void move()
    {
        dir = -new Vector2(transform.position.x - Player.instance.transform.position.x, transform.position.y - Player.instance.transform.position.y);
        dir = dir.normalized;
        rb.velocity = speed * dir;
    }
    public virtual void Dead()
    {
        if (health <= 0)
        {
            Instantiate(deadparticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            
        }
    }
    
    
    
}
