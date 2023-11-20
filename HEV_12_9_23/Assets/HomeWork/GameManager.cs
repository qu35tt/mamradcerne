using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private List<Colllleeect> points = new();
    private List<GameObject> prekazky = new();

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
    }

    void Update()
    {
        Debug.Log(points.Count);
    }

    public void addPoint(Colllleeect point)
    {
        points.Add(point);
    }

    public void Collect(Colllleeect point)
    {
        Skoooore.score.Collect();
        points.Remove(point);
    }

    public void addPrekazka(GameObject g)
    {
        prekazky.Add(g);
    }

    public int getPoints()
    {
        return points.Count;
    }

    public void newLevel()
    {
        foreach(var g in prekazky)
        {
            Destroy(g);
        }
    }
}
