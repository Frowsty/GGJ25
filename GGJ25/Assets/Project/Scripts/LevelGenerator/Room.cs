using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Room : MonoBehaviour
{

    public List<Transform> directions = new ();
    public Collider2D roomCollider2D;
    
    
    
    
    public List<Transform> GetPossibleDirections()
    {
        List<Transform> possibleDirections = new(directions);
        foreach (var dir in directions)
        {
            Collider2D[] roomCollider = Physics2D.OverlapCircleAll(dir.position, 3.5f);
            foreach (var c in roomCollider)
            {
                if(c == roomCollider2D)
                    continue;
                possibleDirections.Remove(dir);
            }
        }
        return possibleDirections;
    }

    public Transform GetRandomDirection()
    {
        List<Transform> possibleDirections = GetPossibleDirections();
        if(possibleDirections.Count == 0)
            return null;
        return possibleDirections[Random.Range(0, possibleDirections.Count)];
    }

    public Dictionary<GameObject,Transform> GetNeighboursPositions()
    {
        Dictionary<GameObject,Transform> neighbours = new();
        foreach (var dir in directions)
        {
            Collider2D[] roomCollider = Physics2D.OverlapCircleAll(dir.position, 3.5f);
            foreach (var c in roomCollider)
            {
                if(c == roomCollider2D)
                    continue;
                neighbours.TryAdd(c.gameObject, dir);
                
            }
        }
        return neighbours;
    }


    public void DeactivateRoom()
    {
        
        roomCollider2D.enabled = false;

        List<SpriteRenderer> roomSpriteRenderers = new (GetComponentsInChildren<SpriteRenderer>());

        foreach (var renderer in roomSpriteRenderers)
        {
            renderer.enabled = false;
        }
        
    }

    public void ActivateRoom()
    {
        
        roomCollider2D.enabled = true;

        List<SpriteRenderer> roomSpriteRenderers = new (GetComponentsInChildren<SpriteRenderer>());

        foreach (var renderer in roomSpriteRenderers)
        {
            renderer.enabled = true;
        }
        
    }
}
