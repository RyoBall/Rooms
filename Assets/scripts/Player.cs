using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("move")]
    public Rigidbody2D rb;
    public float speed;
    [Header("shoot")]
    public float cd;
    public float cdm;
    public GameObject bullet;
    [Header("level")]
    public float exp;
    public int level;
    public float levelfactor;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        levelup();
    }
    void Move()
    {
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), speed * Input.GetAxisRaw("Vertical"));
    }
    void cdcount()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
    }
    void shoot()
    {
        if (cd <= 0 && Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
    void levelup()
    {
        if (exp >= 10 + level * levelfactor) 
        {
            exp = 0;
            level++;
        }
    }
}
