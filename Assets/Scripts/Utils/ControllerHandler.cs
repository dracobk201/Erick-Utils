using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerHandler : MonoBehaviour
{
    #region Directional buttons
    [Header("Directional Buttons Variables")]
    [SerializeField]
    private BoolReference HorizontalSinglePress;
    [SerializeField]
    private FloatReference HorizontalAxis;
    [SerializeField]
    private GameEvent NonHorizontalAxisEvent;
    [SerializeField]
    private GameEvent LeftButtonEvent;
    [SerializeField]
    private GameEvent RightButtonEvent;
    private bool isHorizontalAxisInUse = false;

    [SerializeField]
    private BoolReference VerticalSinglePress;
    [SerializeField]
    private FloatReference VerticalAxis;
    [SerializeField]
    private GameEvent UpButtonEvent;
    [SerializeField]
    private GameEvent DownButtonEvent;
    [SerializeField]
    private GameEvent NonVerticalAxisEvent;
    private bool isVerticalAxisInUse = false;
    #endregion

    #region Action Buttons
    [Header("Action Buttons Variables")]
    [SerializeField]
    private GameEvent StartButtonEvent;
    [SerializeField]
    private GameEvent SquareButtonEvent;
    [SerializeField]
    private GameEvent XButtonEvent;

    private bool isStartAxisInUse = false;
    private bool isSquareAxisInUse = false;
    private bool isXAxisInUse = false;
    #endregion

    [Header("UI Active Variables")]
    [SerializeField]
    private BoolReference UIPanelActive;
    [SerializeField]
    private GameEvent UIChangeEvent;

    private void Update()
    {
        CheckingVerticalAxis();
        CheckingHorizontalAxis();
        CheckingStartButton();
        CheckingSquareButton();
        CheckingXButton();
    }

    private void CheckingHorizontalAxis()
    {
        if (HorizontalSinglePress.Value)
        {
            if (Input.GetAxisRaw(Global.HorizontalAxis) < 0 && !isHorizontalAxisInUse)
            {
                HorizontalAxis.Value = -1;
                isHorizontalAxisInUse = true;
                LeftButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.HorizontalAxis) > 0 && !isHorizontalAxisInUse)
            {
                HorizontalAxis.Value = 1;
                isHorizontalAxisInUse = true;
                RightButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.HorizontalAxis) == 0)
            {
                HorizontalAxis.Value = 0;
                isHorizontalAxisInUse = false;
                NonHorizontalAxisEvent.Raise();
            }
        }
        else
        {
            if (Input.GetAxisRaw(Global.HorizontalAxis) < 0)
            {
                HorizontalAxis.Value = -1;
                LeftButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.HorizontalAxis) > 0)
            {
                HorizontalAxis.Value = 1;
                RightButtonEvent.Raise();
            }
            else
            {
                HorizontalAxis.Value = 0;
                NonHorizontalAxisEvent.Raise();
            }
        }
    }

    private void CheckingVerticalAxis()
    {
        if (VerticalSinglePress.Value)
        {
            if (Input.GetAxisRaw(Global.VerticalAxis) < 0 && !isVerticalAxisInUse)
            {
                VerticalAxis.Value = -1;
                isVerticalAxisInUse = true;
                DownButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.VerticalAxis) > 0 && !isVerticalAxisInUse)
            {
                VerticalAxis.Value = 1;
                isVerticalAxisInUse = true;
                UpButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.VerticalAxis) == 0)
            {
                VerticalAxis.Value = 0;
                isVerticalAxisInUse = false;
                NonVerticalAxisEvent.Raise();
            }
        }
        else
        {
            if (Input.GetAxisRaw(Global.VerticalAxis) < 0)
            {
                VerticalAxis.Value = -1;
                DownButtonEvent.Raise();
            }
            else if (Input.GetAxisRaw(Global.VerticalAxis) > 0)
            {
                VerticalAxis.Value = 1;
                UpButtonEvent.Raise();
            }
            else
            {
                VerticalAxis.Value = 0;
                NonVerticalAxisEvent.Raise();
            }
        }
    }

    private void CheckingStartButton()
    {
        if (Input.GetAxisRaw(Global.StartAxis) != 0 && !isStartAxisInUse)
        {
            StartButtonEvent.Raise();
            isStartAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.StartAxis) == 0)
        {
            isStartAxisInUse = false;
        }
    }

    private void CheckingSquareButton()
    {
        if (Input.GetAxisRaw(Global.FireAxis) != 0 && !isSquareAxisInUse)
        {
            SquareButtonEvent.Raise();
            isSquareAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.FireAxis) == 0)
        {
            isSquareAxisInUse = false;
        }
    }

    private void CheckingXButton()
    {
        if (Input.GetAxisRaw(Global.JumpAxis) != 0 && !isXAxisInUse)
        {
            XButtonEvent.Raise();
            isXAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.JumpAxis) == 0)
        {
            isXAxisInUse = false;
        }
    }

    private void CheckChangeButtonUI()
    {
        if (UIPanelActive.Value)
            UIChangeEvent.Raise();
    }
}
