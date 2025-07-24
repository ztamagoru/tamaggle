using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector3 direction = Vector3.zero;
    
    private Rigidbody2D rb;

    private float stillTime = 0.0f;
    private float stillThreshold = 2.0f;
    private float speedThreshold = 0.05f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime;

        if (rb.velocity.magnitude < speedThreshold)
        {
            stillTime += Time.deltaTime;

            if (stillTime >= stillThreshold)
            {
                StartCoroutine(PegDeletion.pegDeletion.DestroyPegs());
            }
        }
        else
        {
            stillTime = 0.0f;
        }
    }
}
