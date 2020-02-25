using Basic_Variables;
using UnityEngine;

namespace Utils
{
    public class CameraFollow : MonoBehaviour {

        private Transform target;
        [SerializeField] private FloatReference cameraSmoothSpeed;
        [SerializeField] public Vector3Reference offset;
        private GameObject playerGameObject;
        private Transform playerTransform;
        private bool IsPlayerGameObjectNull;

        private void Start()
        {
            IsPlayerGameObjectNull = playerGameObject == null;
            playerGameObject = GameObject.FindGameObjectWithTag(Global.PlayerTag);
            playerTransform = playerGameObject.transform;
        }

        private void LateUpdate()
        {
            if (IsPlayerGameObjectNull)
                return;
            target = playerTransform;
            var desiredPosition = target.position + offset.Value;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothSpeed.Value);
            transform.position = smoothedPosition;
        }
    }
}
