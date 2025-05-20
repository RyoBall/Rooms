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
    public static Vector3[][] Level1Roomlist;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        xdistance = 20;
        ydistance = 15;
        Initroomlist();
        Initlevel(Level1Roomlist[0]);
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
            instanrooms.Add(GenerateRoom((int)positions[i].x, (int)positions[i].y, (int)positions[i].z));
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
        Level1Roomlist = new Vector3[][] { new Vector3[]{ new Vector3(1, 0, 3), new Vector3(2, 0, 2), Vec(2, 1, 1), Vec(3, 1, 1), Vec(0, 2, 1), Vec(1, 2, 1), Vec(2, 2, 2), Vec(3, 2, 1), Vec(3, 3, 1), Vec(1, 3, 4) }, new Vector3[]{ Vec(0, 0, 1), Vec(1, 0, 1), Vec(3, 0, 4), Vec(1, 1, 1), Vec(2, 1, 2), Vec(3, 1, 1), Vec(1, 2, 2), Vec(2, 2, 1), Vec(0, 3, 3), Vec(1, 3, 1) }, new Vector3[]{ Vec(0, 0, 1), Vec(1, 0, 1), Vec(3, 0, 4), Vec(1, 1, 1), Vec(2, 1, 2), Vec(3, 1, 1), Vec(1, 2, 2), Vec(2, 2, 1), Vec(0, 3, 3), Vec(1, 3, 1) }, new Vector3[]{ Vec(0, 0, 1), Vec(1, 0, 1), Vec(2, 0, 2), Vec(3, 0, 1), Vec(0, 1, 3), Vec(2, 1, 1), Vec(1, 2, 4), Vec(2, 2, 1), Vec(2, 3, 2), Vec(3, 3, 1) } }
        ;

    }
    static Vector3 Vec(int x,int y,int z) 
    {
        return new Vector3(x, y, z);
    }
}
