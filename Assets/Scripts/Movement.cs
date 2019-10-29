using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private FloatReference HorizontalAxis;
    [SerializeField]
    private FloatReference VerticalAxis;
    [SerializeField]
    private FloatReference MoveSpeed;

    public void Move()
    {
        Vector3 oldPosition = transform.position;
        float newDirectionX = HorizontalAxis.Value * MoveSpeed.Value * Time.deltaTime;
        float newDirectionY = VerticalAxis.Value * MoveSpeed.Value * Time.deltaTime;
        transform.position = new Vector3(oldPosition.x + newDirectionX, oldPosition.y + newDirectionY, 1);
    }
}
