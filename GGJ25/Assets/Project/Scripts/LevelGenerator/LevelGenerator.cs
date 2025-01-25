using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGenerator : MonoBehaviour
{
    
    public static LevelGenerator instance;
    public int maxRooms;
    public List<GameObject> possibleRooms;
    
    
    public List<Room> rooms = new();
    public Room _lastRoom;
    
    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(rooms.Count!=0)
                ClearDungeon();
            GenerateRooms();
        }
    }


    public void GenerateRooms()
    {
        for (int i = 0; i < maxRooms; i++)
        {
            GameObject room;
            if(rooms.Count == 0)
            {
                room = Instantiate(possibleRooms[Random.Range(0, possibleRooms.Count)], Vector3.zero, Quaternion.identity);
                rooms.Add(room.GetComponent<Room>());
                _lastRoom = room.GetComponent<Room>();
            }
            Transform roomTransform = _lastRoom.GetRandomDirection();
            roomTransform.position = _lastRoom.transform.position+roomTransform.localPosition*2;
            
            room = Instantiate(possibleRooms[Random.Range(0, possibleRooms.Count)], roomTransform.position, Quaternion.identity);
            rooms.Add(room.GetComponent<Room>());
            _lastRoom = room.GetComponent<Room>();

        }
    }

    public void ClearDungeon()
    {
        foreach (var room in rooms)
            Destroy(room.gameObject);
        
        rooms.Clear();
    }
    
    
}
