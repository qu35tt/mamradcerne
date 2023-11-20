using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClickToMove : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent player;
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if( Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                player.SetDestination(hit.point);
            }
            
        }
    }
}
