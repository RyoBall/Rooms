using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private int reward;
    
    void Start()
    {
        reward = Random.Range(0, 2);
    }

    private void OnMouseDown()
    {
        if(reward == 0)
        {
            int rand = Random.Range(1, 4);
            gameManager.instance.GetChip(rand, 1);
        }
        else if(reward == 1)
        {
            //����Դ�������ֵ����player���Ǹ�gamemanager
        }
    }
}
