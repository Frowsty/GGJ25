using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGenerator : MonoBehaviour
{
    
    public static LevelGenerator instance;
    public int maxRooms;
    public List<GameObject> possibleRooms;
    public GameObject teleportPrefab;
    
    
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
            GenerateTeleport();
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
            while (roomTransform == null)
            {
                _lastRoom=rooms[Random.Range(0, rooms.Count)];
                roomTransform = _lastRoom.GetRandomDirection();
            }
            
            
            Vector3 pos = new Vector3(_lastRoom.gameObject.transform.position.x, _lastRoom.gameObject.transform.position.y, _lastRoom.gameObject.transform.position.z);
            pos+=roomTransform.localPosition*2;
            
            room = Instantiate(possibleRooms[Random.Range(0, possibleRooms.Count)], pos, Quaternion.identity);
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

    public void GenerateTeleport()
    {
        foreach (Room room in rooms)
            foreach (var neighbour in room.GetNeighboursPositions())
            {
                var teleporter = Instantiate(teleportPrefab, neighbour.Value.position, Quaternion.identity);
                teleporter.GetComponent<Teleporter>().origin = room;
                teleporter.GetComponent<Teleporter>().destination = neighbour.Key.GetComponentInParent<Room>();
            }
        
    }
    
}
