using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerHandler : MonoBehaviour
{
   
    [Header("Directional Buttons Variables")]
    [SerializeField]
    private FloatReference HorizontalAxis;
    [SerializeField]
    private FloatReference VerticalAxis;
    [SerializeField]
    private GameEvent LeftButtonEvent;
    [SerializeField]
    private GameEvent RightButtonEvent;
    [SerializeField]
    private GameEvent UpButtonEvent;
    [SerializeField]
    private GameEvent DownButtonEvent;
    [SerializeField]
    private GameEvent NonHorizontalAxisEvent;
    [SerializeField]
    private GameEvent NonVerticalAxisEvent;

    [Header("Action Buttons Variables")]
    [SerializeField]
    private GameEvent StartButtonEvent;
    [SerializeField]
    private GameEvent SquareButtonEvent;
    [SerializeField]
    private GameEvent XButtonEvent;

    [Header("UI Active Variables")]
    [SerializeField]
    private BoolReference UIPanelActive;
    [SerializeField]
    private GameEvent UIChangeEvent;

    private bool isStartAxisInUse = false;
    private bool isFireAxisInUse = false;
    private bool isJumpAxisInUse = false;

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

    private void CheckingVerticalAxis()
    {
        if (Input.GetAxisRaw(Global.VerticalAxis) < 0)
        {
            VerticalAxis.Value = -1;
            DownButtonEvent.Raise();
            CheckChangeButtonUI();
        }
        else if (Input.GetAxisRaw(Global.VerticalAxis) > 0)
        {
            VerticalAxis.Value = 1;
            UpButtonEvent.Raise();
            CheckChangeButtonUI();
        }
        else
        {
            VerticalAxis.Value = 0;
            NonVerticalAxisEvent.Raise();
        }
    }

    private void CheckingStartButton()
    {
        if (Input.GetAxisRaw(Global.StartAxis) != 0 && !isStartAxisInUse)
        {
            //Debug.Log("Pausé");
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
        if (Input.GetAxisRaw(Global.FireAxis) != 0 && !isFireAxisInUse)
        {
            //Debug.Log("Disparé");
            SquareButtonEvent.Raise();
            isFireAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.FireAxis) == 0)
        {
            isFireAxisInUse = false;
        }
    }

    private void CheckingXButton()
    {
        if (Input.GetAxisRaw(Global.JumpAxis) != 0 && !isJumpAxisInUse)
        {
            //Debug.Log("Salté");
            XButtonEvent.Raise();
            isJumpAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.JumpAxis) == 0)
        {
            isJumpAxisInUse = false;
        }
    }

    private void CheckChangeButtonUI()
    {
        if (UIPanelActive.Value)
            UIChangeEvent.Raise();
    }
}
