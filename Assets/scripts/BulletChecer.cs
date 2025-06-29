using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChecer : MonoBehaviour
{
    [SerializeField] bullet dad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            dad.enemysin.Add(collision.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            dad.enemysin.Remove(collision.gameObject);
        }
    }
}
