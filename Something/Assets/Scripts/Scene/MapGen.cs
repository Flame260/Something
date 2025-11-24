using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGen : MonoBehaviour
{
    public GameObject Room;
    public GameObject HorDoor;
    public GameObject VertDoor;
    public GameObject FirstRoom;
    public GameObject LastRoom;
    public List<GameObject> LongRoom;
    Vector3 position;
    Boolean WentRight = false;
    Boolean WentLeft = false;
    Boolean WentUp = false;
    Boolean RoomUp = false;
    Boolean RoomRight = false;
    Boolean RoomLeft = false;
    Boolean MakeRoom = false;
    Boolean first = true;
    Boolean last = false;
    int roomAllowed ;
    int randChoice;
    int roomChoice;

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
        //for loop that spawns x number of small rooms
        for (int i = 0; i < 10; i++)
        {
            if (i == 1)
            {
                first = false;
            }
            if (i >= 8)
            {
                roomAllowed = 0;
            }
            if (i == 9)
            {
                last = true;
                roomAllowed = 5;
            }
            Choice();
        }
    }

    void Choice()
    {
        //spawn for the last big room at the end of the hallway
        if (last)
        {
            SpawnDoor();
            position.y += 10.15f;
            Instantiate(LastRoom, position, Quaternion.identity);
            WentRight = false;
            WentLeft = false;
            WentUp = true;
            return;
        }
        randChoice = UnityEngine.Random.Range(0, 3);
        int bigRoom = UnityEngine.Random.Range(0, 5);
        //spawns the long room and resets the counter
        if (bigRoom == 4 && roomAllowed >= 3)
        {
            roomAllowed = 0;
            SpawnRoom();
        }
        //spawns doors for the first room
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

        //spawning the rooms, sets a boolean on where its going, it also forces the room to go up if theres a room on the left or right so it doesn't just collide
        //if it will collide, then it just redoes the choice function
        if (RoomLeft || RoomRight)
        {
            randChoice = 0;
            SpawnDoor();
            position.y += 10.15f;
            Instantiate(Room, position, Quaternion.identity);
            WentRight = false;
            WentLeft = false;
            WentUp = true;
            roomAllowed += 1;
        }
        else if (randChoice == 0 && WentUp == false && RoomUp == false)
        {
            SpawnDoor();
            position.y += 10.15f;
            Instantiate(Room, position, Quaternion.identity);
            WentRight = false;
            WentLeft = false;
            WentUp = true;
            roomAllowed += 1;
        } else if (randChoice == 1 && WentLeft == false && RoomLeft == false)
        {
            SpawnDoor();
            position.x += 10.15f;
            WentRight = true;
            WentLeft = false;
            WentUp = false;
            roomAllowed += 1;
            Instantiate(Room, position, Quaternion.identity);
        } else if (randChoice == 2 && WentRight == false && RoomRight == false)
        {
            SpawnDoor();
            position.x -= 10.15f;
            WentRight = false;
            WentLeft = true;
            WentUp = false;
            roomAllowed += 1;
            Instantiate(Room, position, Quaternion.identity);
        }
        else
        {
            Choice();
        }

    }

        //functions the same as the small rooms
    void SpawnRoom()
    {
        MakeRoom = true;
        RoomUp = false;
        RoomLeft = false;
        RoomRight = false;
        roomChoice = UnityEngine.Random.Range(0, 3);
        if (roomChoice == 0)
        {
            position.y += 10.15f;
            Instantiate(LongRoom[0], position, Quaternion.identity);
            position.y -= 10.15f;
            RoomUp = true;
        }
        else if (randChoice == 1 && WentLeft == false)
        {
            position.x += 5.15f;
            position.y += 5.15f;
            Instantiate(LongRoom[1], position, Quaternion.Euler(0,0,-90));
            position.x -= 5.15f;
            position.y -= 5.15f;
            RoomRight = true;
        }
        else if (randChoice == 2 && WentRight == false)
        {
            position.x -= 5.15f;
            position.y += 5.15f;
            Instantiate(LongRoom[2], position, Quaternion.Euler(0, 0, 90));
            position.x += 5.15f;
            position.y -= 5.15f;
            RoomLeft = true;
        }
        else
        {
           SpawnRoom();
        }
    }

    //be warned this is extremely jank, its basically literally every possibility of movement using the movement choice and
    //where you've moved off the boolean and if there's a longer room and it places the walls (I call them doors) on the small room prefab. It works and thats what matters
    void SpawnDoor()
    {
        if (last)
        {
            randChoice = 0;
        }
        if (MakeRoom)
        {
            if (WentUp == true && randChoice == 1 && RoomLeft)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0,0,90));
                position.y -= 10;
                MakeRoom = false;
            }
            if (WentUp == true && randChoice == 2 && RoomUp)
            {
                Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
                position.y -= 5;
                position.x -= 5;
                MakeRoom = false;
            }
            if (WentUp == true && randChoice == 1 && RoomUp)
            {
                Instantiate(VertDoor, new Vector3(position.x -= 5, position.y += 5, position.z), Quaternion.identity);
                position.y -= 5;
                position.x += 5;
                MakeRoom = false;
            }
            else if (WentUp == true && randChoice == 2 && RoomRight)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y += 10, position.z), Quaternion.Euler(0, 0, 90));
                position.y -= 10;
                MakeRoom = false;
            } 
            else if (WentLeft == true && randChoice == 0 && RoomLeft)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
                MakeRoom = false;
            } 
            else if (WentLeft == true && randChoice == 2 && RoomUp)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
                MakeRoom = false;
            }
            else if (WentRight == true && randChoice == 0 && RoomRight)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
                MakeRoom = false;
            }
            else if (WentRight == true && randChoice == 1)
            {
                Instantiate(HorDoor, new Vector3(position.x, position.y, position.z), Quaternion.Euler(0, 0, 90));
                MakeRoom = false;
            }
            else if (WentUp &&  randChoice == 0 && RoomLeft)
            {

                Instantiate(VertDoor, new Vector3(position.x += 5, position.y += 5, position.z), Quaternion.identity);
                position.y -= 5;
                position.x -= 5;
                MakeRoom = false;
            }
            else if (WentUp && randChoice == 0 && RoomRight)
            {

                Instantiate(VertDoor, new Vector3(position.x -= 5, position.y += 5, position.z), Quaternion.identity);
                position.y -= 5;
                position.x += 5;
                MakeRoom = false;
            }
        }
        else if (WentUp == true && randChoice == 0)
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
