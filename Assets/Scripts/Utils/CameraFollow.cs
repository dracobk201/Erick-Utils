using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

    public FloatReference CameraSmoothSpeed;
    public Vector3Reference Offset;

    private void LateUpdate()
    {
        if (GameObject.FindGameObjectWithTag(Global.PLAYERTAG) == null)
            return;
        target = GameObject.FindGameObjectWithTag(Global.PLAYERTAG).GetComponent<Transform>();
        Vector3 desiredPosition = target.position + Offset.Value;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, CameraSmoothSpeed.Value);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }

}
