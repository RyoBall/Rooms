using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController instance;
    public Vector3[,] RoomPosition = new Vector3[6, 6];
    public GameObject UnknownRoom;
    public GameObject FightRoom;
    public GameObject GuardRoom;
    public GameObject StartRoom;
    public List<GameObject> instanrooms;
    public float xdistance;
    public float ydistance;
    public Vector3[] Roomlist;
    public static Vector3[][][] LevelRoomlist;
    public static Vector3[][] Level1Roomlist;
    public static Vector3[][] Level2Roomlist;
    public static Vector3[][] Level3Roomlist;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        xdistance = 28.8f;
        ydistance = 18;
        Initroomlist();
        Initlevel(LevelRoomlist[gameManager.currentlevel-1][Random.Range(0, LevelRoomlist[gameManager.currentlevel-1].Length)]);
    }

    // Update is called once per frame
    void Update()
    {
    }
    GameObject GenerateRoom(int x,int y,int type=0)
    {
        GameObject a;
        Vector3 temp = RoomPosition[x, y];
        switch (type) 
        {
            case 1:
                a=Instantiate(UnknownRoom, temp, Quaternion.identity);
                break;
            case 2:
                a=Instantiate(FightRoom, temp, Quaternion.identity);
                break;
            case 3:
                a=Instantiate(GuardRoom, temp, Quaternion.identity);
                break;
            case 4:
                a=Instantiate(StartRoom, temp, Quaternion.identity);
                break;
            default:
                a = null;
                break;
        }
        return a;
    }
    void Initlevel(Vector3[] positions)
    {
        for(int i = 0; i < positions.Length; i++) 
        {
            GameObject a = GenerateRoom((int)positions[i].x, (int)positions[i].y, (int)positions[i].z);
            instanrooms.Add(a);
            a.GetComponent<RoomPosition>().Position = new Vector2(positions[i].x, positions[i].y);
        }
    }
    void Initroomlist()//初始化每个房间的坐标 
    {
        for(int i = 0; i < 5; i++) 
        {
            for(int j = 0; j < 5; j++) 
            {
                RoomPosition[i,j] = new Vector3(i*xdistance,j*ydistance,0);
            }
        }
    }
    static RoomController()//在游戏开始初始化关卡列表
    {
        Level1Roomlist = new Vector3[][] { new Vector3[] { new Vector3(1, 0, 3), new Vector3(2, 0, 2), Vec(2, 1, 1), Vec(3, 1, 1), Vec(0, 2, 1), Vec(1, 2, 1), Vec(2, 2, 2), Vec(3, 2, 1), Vec(3, 3, 1), Vec(1, 3, 4) }, new Vector3[] { Vec(0, 0, 1), Vec(1, 0, 1), Vec(3, 0, 4), Vec(1, 1, 1), Vec(2, 1, 2), Vec(3, 1, 1), Vec(1, 2, 2), Vec(2, 2, 1), Vec(0, 3, 3), Vec(1, 3, 1) }, new Vector3[] { Vec(0, 0, 1), Vec(1, 0, 1), Vec(3, 0, 4), Vec(1, 1, 1), Vec(2, 1, 2), Vec(3, 1, 1), Vec(1, 2, 2), Vec(2, 2, 1), Vec(0, 3, 3), Vec(1, 3, 1) }, new Vector3[] { Vec(0, 0, 1), Vec(1, 0, 1), Vec(2, 0, 2), Vec(3, 0, 1), Vec(0, 1, 3), Vec(2, 1, 1), Vec(1, 2, 4), Vec(2, 2, 1), Vec(2, 3, 2), Vec(3, 3, 1) } };
        Level2Roomlist = new Vector3[][] { new Vector3[] { Vec(0, 0, 1), Vec(2, 0, 2), Vec(3, 0, 1), Vec(4, 0, 3), Vec(0, 1, 1), Vec(2, 1, 1), Vec(0, 2, 1), Vec(1, 2, 2), Vec(2, 2, 1), Vec(3, 2, 1), Vec(1, 3, 1), Vec(3, 3, 2), Vec(1, 4, 4), Vec(3, 4, 1), Vec(4, 4, 1) }, new Vector3[] { Vec(2, 0, 1), Vec(1, 1, 1), Vec(2, 1, 2), Vec(3, 1, 1), Vec(4, 1, 1), Vec(0, 2, 4), Vec(2, 2, 1), Vec(4, 2, 2), Vec(0, 3, 1), Vec(1, 3, 2), Vec(2, 3, 1), Vec(4, 3, 1), Vec(0, 4, 1), Vec(3, 4, 3), Vec(4, 4, 1) }, new Vector3[] { Vec(2, 0, 2), Vec(3, 0, 1), Vec(0, 1, 1), Vec(1, 1, 3), Vec(3, 1, 4), Vec(0, 2, 2), Vec(2, 2, 1), Vec(3, 2, 1), Vec(4, 2, 1), Vec(0, 3, 1), Vec(1, 3, 1), Vec(3, 3, 2), Vec(4, 3, 1), Vec(1, 4, 1), Vec(2, 4, 11), Vec(3, 4, 1) }, new Vector3[] { Vec(0, 0, 4), Vec(1, 0, 1), Vec(3, 0, 1), Vec(1, 1, 2), Vec(2, 1, 1), Vec(3, 1, 1), Vec(4, 1, 1), Vec(1, 2, 1), Vec(2, 2, 1), Vec(3, 2, 2), Vec(0, 3, 2), Vec(1, 3, 1), Vec(3, 3, 1), Vec(2, 4, 3), Vec(3, 4, 1) } };
        ;
        Level3Roomlist = new Vector3[][] { new Vector3[] { Vec(2, 0, 2), Vec(3, 0, 1), Vec(0, 1, 2), Vec(2, 1, 1), Vec(4, 1, 1), Vec(0, 2, 1), Vec(2, 2, 1), Vec(3, 2, 1), Vec(4, 2, 2), Vec(0, 3, 1), Vec(1, 3, 2), Vec(2, 3, 1), Vec(4, 3, 1), Vec(0, 4, 1), Vec(1, 4, 1), Vec(4, 4, 1), Vec(5, 4, 1), Vec(1, 5, 4), Vec(3, 5, 3), Vec(4, 5, 1) }, new Vector3[] { Vec(2, 0, 1), Vec(5, 0, 3), Vec(1, 1, 2), Vec(2, 1, 1), Vec(3, 1, 1), Vec(5, 1, 1), Vec(1, 2, 1), Vec(3, 2, 1), Vec(4, 2, 1), Vec(5, 2, 1), Vec(1, 3, 1), Vec(2, 3, 1), Vec(4, 3, 2), Vec(2, 4, 2), Vec(3, 4, 1), Vec(4, 4, 1), Vec(5, 4, 1), Vec(0, 5, 4), Vec(1, 5, 1), Vec(2, 5, 1) }, new Vector3[] { Vec(0, 0, 2), Vec(1, 0, 1), Vec(2, 0, 1), Vec(3, 0, 3), Vec(1, 1, 1), Vec(4, 1, 1), Vec(5, 1, 2), Vec(1, 2, 2), Vec(2, 2, 1), Vec(3, 2, 1), Vec(4, 2, 4), Vec(2, 3, 1), Vec(4, 3, 1), Vec(5, 3, 1), Vec(2, 4, 1), Vec(4, 4, 1), Vec(5, 4, 1), Vec(2, 5, 1), Vec(3, 5, 1), Vec(4, 5, 2) }, new Vector3[] { Vec(2, 0, 1), Vec(3, 0, 1), Vec(0, 1, 1), Vec(1, 1, 1), Vec(2, 1, 1), Vec(3, 1, 2), Vec(4, 1, 1), Vec(0, 2, 4), Vec(2, 2, 1), Vec(4, 2, 1), Vec(5, 2, 1), Vec(0, 3, 1), Vec(3, 3, 1), Vec(4, 3, 2), Vec(5, 3, 1), Vec(0, 4, 1), Vec(1, 4, 2), Vec(3, 5, 3), Vec(4, 5, 1) } };
        LevelRoomlist = new Vector3[][][]{Level1Roomlist,Level2Roomlist,Level3Roomlist};
    }
    static Vector3 Vec(int x,int y,int z) 
    {
        return new Vector3(x, y, z);
    }
}
