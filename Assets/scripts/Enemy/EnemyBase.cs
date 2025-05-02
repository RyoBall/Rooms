using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private SpriteRenderer render;
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public float health;
    public GameObject deadparticle;
    public GameObject exp;
    public float CorrectingFactor;
    public int dropExpNum;
    public float attack;
    [Header("state")]
    public float icytime;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        move();
        Dead();
    }
    public virtual void move()
    {
        if (icytime <= 0) 
        {
            dir = -new Vector2(transform.position.x - Player.instance.transform.position.x, transform.position.y - Player.instance.transform.position.y);
            dir = dir.normalized;
            rb.velocity = speed * dir;
        }
    }
    public virtual void Dead()
    {
        if (health <= 0)
        {
            Instantiate(deadparticle, transform.position, Quaternion.identity);
            expdrop(dropExpNum);
            Destroy(gameObject);
        }
    }
    void icytimecount() 
    {
        if (icytime > 0) 
        {
            icytime -= Time.deltaTime;
        }
    }
    public void expdrop(int nums) 
    {
        for(int i = 0; i < nums; i++) 
        {
            Instantiate(exp,transform.position+new Vector3(Random.Range(-CorrectingFactor,CorrectingFactor), Random.Range(-CorrectingFactor, CorrectingFactor),0),Quaternion.identity);
        }
    }
    protected void attackanim() 
    {
        render.color = Color.blue;
        StartCoroutine(attackroutine());
    }
    IEnumerator attackroutine() 
    {
        yield return new WaitForSeconds(0);
        render.color = Color.white;
    }
}
