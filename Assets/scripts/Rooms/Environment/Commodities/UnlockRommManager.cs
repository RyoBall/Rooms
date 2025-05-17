using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRommManager : MonoBehaviour
{
    public static UnlockRommManager instance;
    public bool[] unlockRooms;

    public GameObject[] roomPrefabs;
    //0储物间/1饮料室/2研究室3走廊/4商店/5宁静花园/6图书室
    private void Awake()
    {
        instance = this;
        unlockRooms = new bool[7] {false,false,false,true,true,true,true};

    }

    public void UnlovkRoom(int i)
    {
        unlockRooms[i] = true;
    }
}
