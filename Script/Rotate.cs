using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed, sensitivity, UpMax, UpMin;
    private float x, y, Limit;

    public void RotateCamera(Vector3 Drag)
    {
        // joystick angles
        x = -Drag.z * speed * sensitivity;
        y = Drag.x * speed * sensitivity;

        // Rotate the camera
        transform.Rotate(Vector3.right, x);
        transform.Rotate(Vector3.up, y);

        Limit = transform.eulerAngles.x + x;
         if (Limit > 180)
        {
            Limit -= 360;
        }
        Limit = Mathf.Clamp(Limit, UpMin, UpMax);

        // limit pitch for camera rotation
        transform.rotation = Quaternion.Euler(Limit, transform.eulerAngles.y, 0);   
    }
}
