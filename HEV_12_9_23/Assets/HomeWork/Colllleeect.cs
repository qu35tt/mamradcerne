using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colllleeect : MonoBehaviour
{
    public bool _active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_active)
        {
            GameManager.gameManager.Collect(this);
            Destroy(gameObject);
        }
        else
        {
            Skoooore.score.Die();
        }
    }
}
