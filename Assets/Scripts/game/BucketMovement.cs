using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMovement : MonoBehaviour
{
    public float speed;
    public float minX = -4f;
    public float maxX = 4f;

    bool isMovingRight = true;
    bool moving = true;

    private void Update()
    {
        if (moving)
        {
            if (isMovingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= maxX)
                {
                    transform.position.Set(maxX, transform.position.y, 0);
                    isMovingRight = !isMovingRight;
                }
            }
            else
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
                if (transform.position.x <= minX)
                {
                    transform.position.Set(minX, transform.position.y, 0);
                    isMovingRight = !isMovingRight;
                }
            }
        }
    }
}
