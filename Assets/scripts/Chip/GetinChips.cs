using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetinChips : MonoBehaviour
{
    public List<ChipBase> chips;
    public static GetinChips instance;
    public const int UIcaolayer = 6;
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        ;   
    }
}
