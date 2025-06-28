using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthImage : MonoBehaviour
{
    [SerializeField] private EnemyBase enemy;
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemy.health / enemy.healthm;
    }
}
