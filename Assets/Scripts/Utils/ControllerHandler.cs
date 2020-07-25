using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    private InputMaster inputActions;
    [SerializeField] private Vector2Reference movementAxis = null;
    [SerializeField] private Vector2Reference cameraAxis = null;
    [SerializeField] private GameEvent movementAxisPerformed = null;
    [SerializeField] private GameEvent movementAxisCanceled = null;
    [SerializeField] private GameEvent cameraAxisPerformed = null;
    [SerializeField] private GameEvent cameraAxisCanceled = null;
    [SerializeField] private GameEvent startButtonEvent = null;
    [SerializeField] private GameEvent squareButtonEvent = null;
    [SerializeField] private GameEvent xButtonEvent = null;
    
    [Header("UI Active Variables")]
    [SerializeField] private BoolReference uiPanelActive = null;
    [SerializeField] private GameEvent uiChangeEvent = null;

    private void Start()
    {
        inputActions = new InputMaster();
        inputActions.PlayerControls.Movement.performed += context => MovementPerformed(context.ReadValue<Vector2>());
        inputActions.PlayerControls.Movement.canceled += context => MovementCanceled();
        inputActions.PlayerControls.CameraRotation.performed += context => CameraPerformed(context.ReadValue<Vector2>());
        inputActions.PlayerControls.CameraRotation.canceled += context => CameraCanceled();
        inputActions.PlayerControls.Pause.performed += context => startButtonEvent.Raise();
        inputActions.PlayerControls.Shoot.performed += context => squareButtonEvent.Raise();
        inputActions.PlayerControls.Interact.performed += context => xButtonEvent.Raise();
    }

    private void OnEnable()
    {
        inputActions.PlayerControls.Enable();
    }

    private void OnDisable()
    {
        inputActions.PlayerControls.Disable();
    }

    private void MovementPerformed(Vector2 axisValue)
    {
        movementAxis.Value = axisValue;
        movementAxisPerformed.Raise();
    }

    private void MovementCanceled()
    {
        movementAxis.Value = Vector2.zero;
        movementAxisCanceled.Raise();
    }

    private void CameraPerformed(Vector2 axisValue)
    {
        cameraAxis.Value = axisValue;
        cameraAxisPerformed.Raise();
    }

    private void CameraCanceled()
    {
        cameraAxis.Value = Vector2.zero;
        cameraAxisCanceled.Raise();
    }
}