using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public WeaponBase dad;
    public GameObject disapearparticle;
    public GameObject damagetex;
    public float damagetexcorecfactor;
    public float attack;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (dir.x < 0) 
        {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan(dir.y / dir.x )* Mathf.Rad2Deg-180));
        }
        else if(dir.x>0)
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg));
        rb.velocity = speed * dir;   
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
        if (collision.tag == "Enemy") 
        {
            Instantiate(disapearparticle,transform.position,Quaternion.identity);
            collision.GetComponent<EnemyBase>().health -= attack;
            GameObject tex = Instantiate(damagetex, transform.position + new Vector3(Random.Range(-damagetexcorecfactor, damagetexcorecfactor), Random.Range(-damagetexcorecfactor, damagetexcorecfactor), 0),Quaternion.identity);
            tex.GetComponentInChildren<TMP_Text>().text = attack.ToString();
            collision.GetComponent<EnemyBase>().icytime+=dad.icyattacklevel;
            Destroy(gameObject);
        }
    }
}
