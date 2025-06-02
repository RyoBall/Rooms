using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeControl : MonoBehaviour
{
    public float disappeartime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
        GetComponent<SpriteRenderer>().material.SetFloat("_StartTime",Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Disappear() 
    {
        yield return new WaitForSeconds(disappeartime);
        Destroy(gameObject);
    }
}
