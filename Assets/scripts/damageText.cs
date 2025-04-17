using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class damageText : MonoBehaviour
{
    public float disapeartime=1;
    // Start is called before the first frame update
    void Start()
    {
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
