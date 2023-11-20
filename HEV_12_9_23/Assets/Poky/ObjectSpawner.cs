using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] List<SpawnData> spawnData;

    float probSum;
    void Start()
    {
        probSum = spawnData.Sum(data => data.Probability);
        InvokeRepeating("CreateRandomPrefab", 0, 0.8f);
    }

    private void CreateRandomPrefab()
    {
        CreatePrefab(GetRandomPrefab());
    }

    private void CreatePrefab(GameObject prefab)
    {
        var g =Instantiate(prefab, GetRandomPosition(), Quaternion.identity, transform);
        var rb = g.GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * 3;
        rb.AddTorque(Vector3.up * 100);
        Destroy(g, 4f);
    }

    private GameObject GetRandomPrefab()
    {
        float rnd = Random.Range(0f, probSum);
        float sum = 0;
        for(int i = 0; i < spawnData.Count; i++)
        {
            sum += spawnData[i].Probability;
            if(rnd <= sum)
            {
                return spawnData[i].prefab;
            }
        }

        return spawnData[Random.Range(0, 2)].prefab;
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-3.77f, 3.77f),
            transform.position.y,
            transform.position.z
            );
    }
}

[System.Serializable]
class SpawnData
{
    public GameObject prefab;
    public float Probability;
}