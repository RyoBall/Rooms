using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FightText : MonoBehaviour
{
    private TMP_Text tMP_Text;
    // Start is called before the first frame update
    void Start()
    {
        tMP_Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tMP_Text.text = enemyGeneratorController.instance.fightTime.ToString();
        if (enemyGeneratorController.instance.fightTime <= 0)
            tMP_Text.enabled = false;
        else
            tMP_Text.enabled = true;
    }
}
