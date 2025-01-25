using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelGenerator : MonoBehaviour
{
    
    public static LevelGenerator Instance;
    public int maxRoomsMin;
    public int maxRoomsMax;
    public List<GameObject> possibleRooms;
    public GameObject teleportPrefab;
    
    
    public List<Room> rooms = new();
    public Room _lastRoom;
    public List<Teleporter> teleports = new();
    
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(rooms.Count!=0)
                ClearDungeon();
            GenerateRooms();
            GenerateTeleport();
            InitializeDungeon();
        }
    }*/

    public void StartGeneration()
    {
        if(rooms.Count!=0)
            ClearDungeon();
        GenerateRooms();
        GenerateTeleport();
        InitializeDungeon();
    }


    public void GenerateRooms()
    {
        int maxRooms = Random.Range(maxRoomsMin, maxRoomsMax);
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

            Vector3 pos = new Vector3();
            
            switch (roomTransform.name)
            {
                case "Top":
                    pos.y = _lastRoom.transform.position.y+20;
                    pos.x = _lastRoom.transform.position.x;
                    break;
                case "Bottom":
                    pos.y = _lastRoom.transform.position.y-20;
                    pos.x = _lastRoom.transform.position.x;
                    break;
                case "TopLeft":
                    pos.x = _lastRoom.transform.position.x-30;
                    pos.y = _lastRoom.transform.position.y+10;
                    break;
                case "TopRight":
                    pos.x = _lastRoom.transform.position.x+30;
                    pos.y = _lastRoom.transform.position.y+10;
                    break;
                case "BottomLeft":
                    pos.x = _lastRoom.transform.position.x-30;
                    pos.y = _lastRoom.transform.position.y-10;
                    break;
                case "BottomRight":
                    print("BottomRight");
                    pos.x = _lastRoom.transform.position.x+30;
                    pos.y = _lastRoom.transform.position.y-10;
                    break;
            }
            
            
            room = Instantiate(possibleRooms[Random.Range(0, possibleRooms.Count)], pos, Quaternion.identity);
            rooms.Add(room.GetComponent<Room>());
            _lastRoom = room.GetComponent<Room>();

        }
    }

    public void ClearDungeon()
    {
        foreach (var room in rooms)
            Destroy(room.gameObject);

        foreach (var teleport in teleports)
            Destroy(teleport.gameObject);
            
        
        rooms.Clear();
        teleports.Clear();
    }

    public void GenerateTeleport()
    {
        foreach (Room room in rooms)
            foreach (var neighbour in room.GetNeighboursPositions())
            {
                bool foundTeleport = false;
                Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(neighbour.Value.position, 1.5f);
                foreach (var collider in collider2Ds)
                {
                    if (collider.CompareTag("Teleport"))
                    {
                        foundTeleport = true;
                        break;
                    }
                }

                if (!foundTeleport)
                {
                    var teleporter = Instantiate(teleportPrefab, neighbour.Value.position, Quaternion.identity, room.transform);
                    teleports.Add(teleporter.GetComponent<Teleporter>());
                    teleporter.GetComponent<Teleporter>().origin = room;
                    teleporter.GetComponent<Teleporter>().destination = neighbour.Key.GetComponentInParent<Room>();
                    
                }
            }
        
    }


    public void InitializeDungeon()
    {
        for (int i = 1; i < rooms.Count; i++)
        {
            rooms[i].GetComponent<Room>().DeactivateRoom();
        }
    }
    
}
