using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum State { Energy, Chip };
    public State currentState;
    private void OnMouseDown()
    {
        switch (currentState)
        {
            case State.Energy:
                Player.instance.energy += Random.Range(5, 31);
                break;
            case State.Chip:
                if (Random.value > .9f)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        gameManager.instance.GetChipButton(3, gameManager.instance.chipsDic[3].Count, i);
                    }
                    ChoosePanel.instance.Enter();
                }
                else 
                {
                    int a = Random.Range(0, 3);
                    for (int i = 0; i < 3; i++)
                    {
                        gameManager.instance.GetChipButton(a, gameManager.instance.chipsDic[a].Count, i);
                    }
                    ChoosePanel.instance.Enter();
                }
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
