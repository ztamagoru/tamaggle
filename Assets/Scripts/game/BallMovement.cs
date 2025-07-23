using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;
    
    void Update()
    {
        transform.position += direction * Time.deltaTime;
    }
}
