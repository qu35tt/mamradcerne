using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 8f;

    Vector3 xcesta = Vector3.zero;
    Vector2 InputVector = Vector2.zero; 
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            if (xcesta != Vector3.back)
            {
                InputVector.Set(1, 0);
                xcesta = Vector3.forward;

            }
        }
        

        if (Input.GetKey(KeyCode.S))
        {
            
            if (xcesta != Vector3.forward)
            {
                InputVector.Set(-1, 0);
                xcesta = Vector3.back;

            }

        }
        

        if (Input.GetKey(KeyCode.A))
        {
            if (xcesta != Vector3.right)
            {
                InputVector.Set(0, 1);
                xcesta = Vector3.left;

            }


        }
        

        if (Input.GetKey(KeyCode.D))
        {
            if (xcesta != Vector3.left)
            {
                InputVector.Set(0,-1);
                xcesta = Vector3.right;

            }

        }

        InputVector = InputVector.normalized;
        Vector3 moveDir = new Vector3(InputVector.x, 0, InputVector.y) * Time.deltaTime*movementSpeed;

        if(transform.position.z > 12 || transform.position.z < -12 || transform.position.x > 12 || transform.position.x < -12)
        {
            Skoooore.score.Die();
        }

        transform.position += moveDir;


    }
}
