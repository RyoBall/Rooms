using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController instance;
    public Vector3[,] rooms = new Vector3[5, 5];
    public GameObject room;
    public List<GameObject> instanrooms;
    public float xdistance;
    public float ydistance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        xdistance = 20;
        ydistance = 15;
        Initroomlist();
        Vector2[] a = new Vector2[4];
        a[0] = new Vector2(0, 0);
        a[1] = new Vector2(1, 1);
        a[2] = new Vector2(2, 4);
        a[3] = new Vector2(3, 0);
        Initlevel(a);
    }

    // Update is called once per frame
    void Update()
    {
    }
    GameObject InitRoom(int x,int y)
    {
        GameObject a;
        Vector3 temp = rooms[x, y];
        a=Instantiate(room, temp, Quaternion.identity);
        return a;
    }
    void Initlevel(Vector2[] positions)
    {
        for(int i = 0; i < positions.Length; i++) 
        {
            instanrooms.Add(InitRoom((int)positions[i].x, (int)positions[i].y));
        }
        Player.instance.currentRoom = instanrooms[0].transform;
    }
    void Initroomlist() 
    {
        for(int i = 0; i < 5; i++) 
        {
            for(int j = 0; j < 5; j++) 
            {
                rooms[i,j] = new Vector3(i*xdistance,j*ydistance,0);
            }
        }
    }
}
