using System;
using System.Collections.Generic;
using DG.Tweening;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    public Room origin;
    public Room destination;

    public Color activeColor;
    public Color inactiveColor;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = inactiveColor;
        EnemySpawner.Instance.OnRoomClear.AddListener(ToggleTeleport);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(EnemySpawner.Instance.enemies.Count != 0)
            return;
        if (other.CompareTag("Player"))
        {
            Room nextRoom = null;
            if (PlayerStats.Instance.activeRoom == destination)
            {
                
                destination.DeactivateRoom();
                origin.ActivateRoom();
                other.gameObject.transform.position = origin.transform.position;
                nextRoom = origin;
                Camera.main?.transform.DOMove(origin.transform.position, 0.5f).SetEase(Ease.Linear);
                PlayerStats.Instance.activeRoom = origin;
            }
            else
            {
                origin.DeactivateRoom();
                destination.ActivateRoom();
                other.gameObject.transform.position = destination.transform.position;
                nextRoom = destination;
                Camera.main?.transform.DOMove(destination.transform.position, 0.5f).SetEase(Ease.Linear);
                PlayerStats.Instance.activeRoom = destination;
                (origin, destination) = (destination, origin);
            }

            LevelGenerator.Instance.AdjustTeleport();
            
            if (nextRoom != null && !nextRoom.hasSpawned && !nextRoom.gameObject.CompareTag("End"))
            {
                foreach (var point in nextRoom.GetComponentsInChildren<SpawnPoint>())
                    EnemySpawner.Instance.SpawnEnemy(point.transform.position);
                
                nextRoom.hasSpawned = true;
            }
        }
    }


    public void ToggleTeleport()
    {
        gameObject.GetComponent<SpriteRenderer>().color = activeColor;
    }
    

    
 
    
}
