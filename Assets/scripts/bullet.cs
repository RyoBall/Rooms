using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 dir;
    public float speed;
    public float speedfactor;
    public WeaponBase dad;
    public GameObject disapearparticle;
    public GameObject damagetex;
    public float damagetexcorecfactor;
    public float attack;
    [Header("ÕÛÉä")]
    private int bumpoint;
    private bool inbum;
    private GameObject nochec;
    private List<GameObject> enemysin = new List<GameObject>();
    [Header("±¬Õ¨")]
    private int bombpoint;
    [SerializeField] private GameObject bomber;
    // Start is called before the first frame update
    void Start()
    {
        speedfactor = 1;
        rb = GetComponent<Rigidbody2D>();
        bumpoint = dad.bumattacklevel;
        bombpoint = dad.bombattacklevel;
        //
        Redir();
        //
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
        if (collision.tag == "Enemy" && collision.gameObject != nochec)
        {
            Instantiate(disapearparticle, transform.position, Quaternion.identity);
            collision.GetComponent<EnemyBase>().health -= attack;
            GameObject tex = Instantiate(damagetex, transform.position + new Vector3(Random.Range(-damagetexcorecfactor, damagetexcorecfactor), Random.Range(-damagetexcorecfactor, damagetexcorecfactor), 0), Quaternion.identity);
            tex.GetComponentInChildren<TMP_Text>().text = attack.ToString();
            //icychec
            collision.GetComponent<EnemyBase>().icytime += dad.icyattacklevel;
            //bombchec
            bombroutine(transform.position);
            //ÕÛÉächec
            nochec = collision.gameObject;
            if (bumpoint > 0)
            {
                bumpoint--;
                DIR();
            }
            //½áÊø
            else
                Destroy(gameObject);
        }
    }
    public virtual void DIR()
    {
        GameObject closestenemy = FindEnemy();
        if (closestenemy != null)
            dir = new UnityEngine.Vector2(closestenemy.transform.position.x - transform.position.x, closestenemy.transform.position.y - transform.position.y);
        else
            Debug.Log("noenemy");
        dir = dir.normalized;
        Redir();
    }
    void Redir() //µ÷Õû×Óµ¯³¯Ïò
    {
        if (dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg - 180));
        }
        else if (dir.x > 0)
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg));
        rb.velocity = speed * dir * speedfactor;
    }
    public GameObject FindEnemy()
    {
        float closestdistance = 0;
        GameObject closest = null;
        for (int i = 0; i < enemysin.Count; i++)
        {
            GameObject enemy = enemysin[i];
            if (i == 0)
            {
                closest = enemy;
                closestdistance = (enemy.transform.position.x - transform.position.x) * (enemy.transform.position.x - transform.position.x) + (enemy.transform.position.y - transform.position.y) * (enemy.transform.position.y - transform.position.y);
            }
            else
            {
                float distance = (enemy.transform.position.x - transform.position.x) * (enemy.transform.position.x - transform.position.x) + (enemy.transform.position.y - transform.position.y) * (enemy.transform.position.y - transform.position.y);
                if (distance < closestdistance)
                {
                    closest = enemy;
                    closestdistance = distance;
                }
            }
        }
        return closest;
    }
    IEnumerator bombroutine(Vector3 position)
    {
        yield return new WaitForSeconds(.05f);
        if (bombpoint > 0)
        {
            bombpoint--;
            GameObject bomb = Instantiate(bomber, position, Quaternion.identity);
            bomb.GetComponent<bomb>().damage = (int)(attack * .3f);
            StartCoroutine(bombroutine(position));
        }
    }
}
