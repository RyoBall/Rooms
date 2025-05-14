using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class damageText : MonoBehaviour
{
    public float disapeartime=1;
    public float forcemin;
    public float forcem;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up*Random.Range(forcemin,forcem),ForceMode2D.Impulse);
        GetComponentInChildren<TMP_Text>().DOColor(new Color(0, 0, 0, 0), disapeartime);
        StartCoroutine(DisappearCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }
    private IEnumerator DisappearCoroutine() 
    {
        yield return new WaitForSeconds(disapeartime);
        Destroy(gameObject);
    }
}
