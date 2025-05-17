using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRommManager : MonoBehaviour
{
    public static UnlockRommManager instance;
    public bool[] unlockRooms;

    public GameObject[] roomPrefabs;
    //0�����/1������/2�о���3����/4�̵�/5������԰/6ͼ����
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
