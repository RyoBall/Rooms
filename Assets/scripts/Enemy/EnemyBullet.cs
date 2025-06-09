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
    private void Start()
    {
        StartCoroutine(DestroySelf());
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
            Player.instance.Attacked(attack);
            Destroy(gameObject);
        }
    }
    public void Redir() //调整子弹朝向
    {
        Setdir(Player.instance.transform.position-transform.position);
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * dir;
    }
    public void Act(float angle)
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
        Setdir(angle);
        rb.velocity = speed * dir;
    }
    void Setdir(float angle) 
    {
        dir = new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad), Mathf.Sin(angle*Mathf.Deg2Rad));
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg - 180));
        }
        else if (dir.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg));
    }
    void Setdir(Vector2 vec) 
    {
        dir = vec.normalized;
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg - 180));
        }
        else if (dir.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg));
    }
    IEnumerator DestroySelf() 
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
