using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float RotationSpeed = 500;
    public Transform CameraAxisTransform;
    public float MinAngle = -30;
    public float MaxAngle = 60;
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime, 0);
        var CAT_Rot_X = CameraAxisTransform.localEulerAngles.x - Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        if (CAT_Rot_X > 180)
            CAT_Rot_X -= 360;
        CAT_Rot_X = Mathf.Clamp(CAT_Rot_X, MinAngle, MaxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(CAT_Rot_X, 0, 0);
    }
}
