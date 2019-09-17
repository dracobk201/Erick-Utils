using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [Header("Touch Variables")]
    [SerializeField]
    private FloatReference MaxSwipeTime;
    [SerializeField]
    private FloatReference MinSwipeDistance;
    private Touch touch;
    private float swipeStartTime;
    private bool couldBeSwipe;
    private Vector2 startPos;
    private int stationaryForFrames;
    private TouchPhase lastPhase;
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

    private void Start()
    {
        StartCoroutine(CheckSwipes());
    }

    private void Update()
    {
        CheckingVerticalAxis();
        CheckingHorizontalAxis();
        CheckingStartButton();
        CheckingSquareButton();
        CheckingXButton();
    }

    #region Touch Functions
    public IEnumerator CheckSwipes()
    {
        while (true)
        {                                                                   //Hago este Loop para que lo haga infinitamente
            foreach (Touch touch in Input.touches)
            {                                   //Por cada toque en el Input.touches, ya que es un arreglo
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        couldBeSwipe = true;
                        startPos = touch.position;
                        swipeStartTime = Time.time;
                        stationaryForFrames = 0;
                        break;
                    case TouchPhase.Stationary:
                        if (IsContinouslyStationary(frames: 8))
                        {
                            couldBeSwipe = false;
                            NoHorizontalActions();
                            NoVerticalActions();
                        }
                        break;
                    case TouchPhase.Ended:
                        if (IsASwipeHorizontal(touch))
                        {
                            couldBeSwipe = false;
                            if (Mathf.Sign(touch.position.x - startPos.x) == 1f)
                            {
                                RightDirectionActions();
                            }
                            else if (Mathf.Sign(touch.position.x - startPos.x) != 1f)
                            {
                                LeftDirectionActions();
                            }
                        }
                        else if (IsASwipeVertical(touch))
                        {
                            couldBeSwipe = false;                                   //Ya terminó el swipe
                            if (Mathf.Sign(touch.position.y - startPos.y) == 1f)
                            {
                                UpDirectionActions();
                            }
                            else
                            {
                                DownDirectionActions();
                            }
                        }
                        else
                        {                                                               //Si son sólo toques para la UI
                            PointerEventData ped = new PointerEventData(EventSystem.current);   //Se crea el PointerEventData
                            ped.position = touch.position;                                      //Se obtiene la posición del dedo
                            List<RaycastResult> hits = new List<RaycastResult>();               //Crear una lista vacia en donde se guardaran los resultados del Raycast
                            EventSystem.current.RaycastAll(ped, hits);                          //Checkea los rayos y los guarda en la lista
                            foreach (RaycastResult r in hits)
                            {
                                //if (SceneManager.GetActiveScene().name != GlobalVariables.MainMenuSceneName)
                                //{
                                //    if (r.gameObject.name == "Pause")
                                //    {
                                //        GameMaster.instance.isPaused = !GameMaster.instance.isPaused;
                                //    }
                                //    else
                                //    {
                                //        player.GetComponent<PlayerController>().ControllerAnimation(r.gameObject.name);
                                //    }
                                //}
                            }
                        }
                        break;
                }
                lastPhase = touch.phase;
            }
            yield return null;
        }
    }

    private bool IsContinouslyStationary(int frames)
    {
        if (lastPhase == TouchPhase.Stationary)
            stationaryForFrames++;
        else
            stationaryForFrames = 1;
        return stationaryForFrames > frames;
    }

    private bool IsASwipeHorizontal(Touch touch)
    {
        float swipeTime = Time.time - swipeStartTime;
        float swipeDistx = Mathf.Abs(touch.position.x - startPos.x);
        return couldBeSwipe && swipeTime < MaxSwipeTime.Value && swipeDistx > MinSwipeDistance.Value;
    }

    private bool IsASwipeVertical(Touch touch)
    {
        float swipeTime = Time.time - swipeStartTime;
        float swipeDist = Mathf.Abs(touch.position.y - startPos.y);
        return couldBeSwipe && swipeTime < MaxSwipeTime.Value && swipeDist > MinSwipeDistance.Value;
    }
    #endregion

    #region Horizontal Functions

    private void CheckingHorizontalAxis()
    {
        if (Input.GetAxisRaw(Global.HORIZONTALAXIS) < 0 && !isHorizontalAxisInUse)
        {
            LeftDirectionActions();
        }
        else if (Input.GetAxisRaw(Global.HORIZONTALAXIS) > 0 && !isHorizontalAxisInUse)
        {
            RightDirectionActions();
        }
        else if (Input.GetAxisRaw(Global.HORIZONTALAXIS) == 0)
        {
            NoHorizontalActions();
        }
    }

    private void NoHorizontalActions()
    {
        HorizontalAxis.Value = 0;
        if (HorizontalSinglePress.Value)
            isHorizontalAxisInUse = false;
        NonHorizontalAxisEvent.Raise();
    }

    private void RightDirectionActions()
    {
        HorizontalAxis.Value = 1;
        if (HorizontalSinglePress.Value)
            isHorizontalAxisInUse = true;
        RightButtonEvent.Raise();
    }

    private void LeftDirectionActions()
    {
        HorizontalAxis.Value = -1;
        if (HorizontalSinglePress.Value)
            isHorizontalAxisInUse = true;
        LeftButtonEvent.Raise();
    }

    #endregion

    #region Vertical Functions
    private void CheckingVerticalAxis()
    {
        if (Input.GetAxisRaw(Global.VERTICALAXIS) < 0 && !isVerticalAxisInUse)
        {
            DownDirectionActions();
        }
        else if (Input.GetAxisRaw(Global.VERTICALAXIS) > 0 && !isVerticalAxisInUse)
        {
            UpDirectionActions();
        }
        else if (Input.GetAxisRaw(Global.VERTICALAXIS) == 0)
        {
            NoVerticalActions();
        }
    }

    private void NoVerticalActions()
    {
        VerticalAxis.Value = 0;
        if (VerticalSinglePress.Value)
            isVerticalAxisInUse = false;
        NonVerticalAxisEvent.Raise();
    }

    private void UpDirectionActions()
    {
        VerticalAxis.Value = 1;
        if (VerticalSinglePress.Value)
            isVerticalAxisInUse = true;
        UpButtonEvent.Raise();
    }

    private void DownDirectionActions()
    {
        VerticalAxis.Value = -1;
        if (VerticalSinglePress.Value)
            isVerticalAxisInUse = true;
        DownButtonEvent.Raise();
    }

    #endregion

    private void CheckingStartButton()
    {
        if (Input.GetAxisRaw(Global.STARTAXIS) != 0 && !isStartAxisInUse)
        {
            StartButtonEvent.Raise();
            isStartAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.STARTAXIS) == 0)
        {
            isStartAxisInUse = false;
        }
    }

    private void CheckingSquareButton()
    {
        if (Input.GetAxisRaw(Global.FIREAXIS) != 0 && !isSquareAxisInUse)
        {
            SquareButtonEvent.Raise();
            isSquareAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.FIREAXIS) == 0)
        {
            isSquareAxisInUse = false;
        }
    }

    private void CheckingXButton()
    {
        if (Input.GetAxisRaw(Global.JUMPAXIS) != 0 && !isXAxisInUse)
        {
            XButtonEvent.Raise();
            isXAxisInUse = true;
        }
        else if (Input.GetAxisRaw(Global.JUMPAXIS) == 0)
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
