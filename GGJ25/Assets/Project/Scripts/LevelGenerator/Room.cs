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
            Collider2D[] roomCollider = Physics2D.OverlapCircleAll(dir.position, 1f);
            print(roomCollider.Length);
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
        return possibleDirections[Random.Range(0, possibleDirections.Count)];
    }


}
