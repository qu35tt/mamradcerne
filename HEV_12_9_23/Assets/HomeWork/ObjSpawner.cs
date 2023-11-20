using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;
    GameManager gameManager;
    private int count = 6;
    private void Start()
    {
        this.gameManager = GameManager.gameManager;
        Spawnlevel();
    }

    private void Update()
    {
        if (gameManager.getPoints() == 0)
        {
            gameManager.newLevel();
            count += 3;
            Spawnlevel();
        }
    }

    public void Spawnlevel()
    {
        for (int i = 0; i < count; i++)
        {
            if (i >= count / 2)
            {
                Spawn(prefabs[0]);
            }
            else
            {
                Spawn(prefabs[1]);
            }
        }
    }

    public void Spawn(GameObject prefab)
    {
        Vector3 vector3 = new Vector3(SpawnRange(), 1f,SpawnRange());
        var g = Instantiate(prefab, vector3,Quaternion.identity, transform);
        var r = g.GetComponent<Colllleeect>();

        if (prefab == prefabs[0])
        {
            r._active = true;
            gameManager.addPoint(r);
        }
        else
        {
            gameManager.addPrekazka(g);
        }
        
    }

    public int SpawnRange()
    {
        int rnd = Random.Range(-11, 11);
        return rnd;
    }



       
}
