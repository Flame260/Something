using System;
using System.Threading;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public GameObject Room;
    public GameObject HorDoor;
    public GameObject VertDoor;
    public GameObject FirstRoom;
    Vector3 position;
    Boolean WentRight = false;
    Boolean WentLeft = false;
    Boolean WentUp = false;
    Boolean first = true;
    Boolean last = false;
    int randChoice;

    void Start()
    {
        position = FirstRoom.transform.position;
        SpawnRooms();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRooms()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 1)
            {
                first = false;
            }
            Choice();
        }
    }

    void Choice()
    {
        randChoice = UnityEngine.Random.Range(0, 3);
        if (first)
        {
            if(randChoice == 0)
            {
                Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
                Instantiate(VertDoor, new Vector3(position.x -= 10, position.y, position.z), Quaternion.identity);
                position.x += 5;
                position.y -= 5;
            }else if (randChoice == 1)
            {
                Instantiate(VertDoor, new Vector3(position.x -= 5, position.y += 5, position.z), Quaternion.identity);
                Instantiate(HorDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.Euler(0, 0, 90));
                position.y -= 10;
            }
            else if (randChoice == 2)
            {
                Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
                Instantiate(HorDoor, new Vector3(position.x -= 5, position.y += 5, position.z), Quaternion.Euler(0, 0, 90));
                position.y -= 10;
            }
        }
        if (randChoice == 0)
        {
            SpawnDoor();
            position.y += 10.15f;
            Instantiate(Room, position, Quaternion.identity);
            WentRight = false;
            WentLeft = false;
            WentUp = true;
        } else if (randChoice == 1 && WentLeft == false)
        {
            SpawnDoor();
            position.x += 10.15f;
            WentRight = true;
            WentLeft = false;
            WentUp = false;
            Instantiate(Room, position, Quaternion.identity);
        }else if (randChoice == 2 && WentRight == false)
        {
            SpawnDoor();
            position.x -= 10.15f;
            WentRight = false;
            WentLeft = true;
            WentUp = false;
            Instantiate(Room, position, Quaternion.identity);
        }
        else
        {
            Choice();
        }
                
    }

    void SpawnDoor()
    {
        if (WentUp == true && randChoice == 0)
        {
            Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
            Instantiate(VertDoor, new Vector3(position.x -= 10, position.y, position.z), Quaternion.identity);
            position.x += 5;
            position.y -= 5;
        } else if (WentUp == true && randChoice == 1)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0,0,90));
            Instantiate(VertDoor, new Vector3(position.x -= 5, position.y -= 5, position.z), Quaternion.identity);
            position.x += 5;
            position.y -= 5;
        } else if (WentUp == true && randChoice == 2)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0, 0, 90));
            Instantiate(VertDoor, new Vector3(position.x += 5, position.y -= 5, position.z), Quaternion.identity);
            position.x -= 5;
            position.y -= 5;
        } else if (WentLeft == true && randChoice == 0)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
            Instantiate(VertDoor, new Vector3(position.x -= 5, position.y += 5, position.z), Quaternion.identity);
            position.x += 5;
            position.y -= 5;
        } else if (WentLeft == true && randChoice == 2)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
            Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0, 0, 90));
            position.y -= 10;
        }
        else if (WentRight == true && randChoice == 0)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
            Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
            position.x -= 5;
            position.y -= 5;
        }
        else if (WentRight == true && randChoice == 1)
        {
            Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
            Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0, 0, 90));
            position.y -= 10;
        }
    }
    }
