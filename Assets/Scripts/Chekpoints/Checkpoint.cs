using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Vector3Reference LastCheckpointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Global.PLAYERTAG))
        {
            LastCheckpointPosition.Value = transform.position;
        }
    }
}
