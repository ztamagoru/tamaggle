using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowMouse : MonoBehaviour
{
    public Collider2D mouseArea;

    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mouseArea.OverlapPoint((Vector2)mouseWorldPosition))
        {
            RotateTowardsMouse();
        }
    }

    void RotateTowardsMouse()
    {
        Vector2 worldposmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 relativepos = worldposmouse - (Vector2)transform.position;

        float rot_z = Mathf.Atan2(relativepos.y, relativepos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90f);
    }
}
