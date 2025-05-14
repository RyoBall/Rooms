using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public GameObject disapearparticle;
    public float attack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Redir();

    }
    // Update is called once per frame
    void Update()
    {

    }
    Vector2 Dir()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector3 dir = mousepos - Player.instance.transform.position;
        dir.z = 0;
        dir = dir.normalized;
        Vector2 shootdir = new Vector2(dir.x, dir.y);
        return dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(disapearparticle, transform.position, Quaternion.identity);
            Player.instance.health -= attack;
            Destroy(gameObject);
        }
    }
    void Redir() //调整子弹朝向
    {
        dir = Player.instance.transform.position - transform.position;
        dir = dir.normalized;
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg - 180));
        }
        else if (dir.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg));
        rb.velocity = speed * dir;
    }
}
