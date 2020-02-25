using System;
using System.Collections;
using System.Collections.Generic;
using Basic_Variables;
using Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils
{
    public class ControllerHandler : MonoBehaviour
    {
        #region Directional buttons
        [Header("Directional Buttons Variables")]
        [SerializeField] private BoolReference horizontalSinglePress;
        [SerializeField] private FloatReference horizontalAxis;
        [SerializeField] private GameEvent nonHorizontalAxisEvent;
        [SerializeField] private GameEvent leftButtonEvent;
        [SerializeField] private GameEvent rightButtonEvent;
        private bool isHorizontalAxisInUse = false;

        [SerializeField] private BoolReference verticalSinglePress;
        [SerializeField] private FloatReference verticalAxis;
        [SerializeField] private GameEvent upButtonEvent;
        [SerializeField] private GameEvent downButtonEvent;
        [SerializeField] private GameEvent nonVerticalAxisEvent;
        private bool isVerticalAxisInUse = false;
        
        [Header("Touch Variables")]
        [SerializeField] private FloatReference maxSwipeTime;
        [SerializeField] private FloatReference minSwipeDistance;
        private Touch touch;
        private float swipeStartTime;
        private bool couldBeSwipe;
        private Vector2 startPos;
        private int stationaryForFrames;
        private TouchPhase lastPhase;
        #endregion

        #region Action Buttons
        [Header("Action Buttons Variables")]
        [SerializeField] private GameEvent startButtonEvent;
        [SerializeField] private GameEvent squareButtonEvent;
        [SerializeField] private GameEvent xButtonEvent;

        private bool isStartAxisInUse = false;
        private bool isSquareAxisInUse = false;
        private bool isXAxisInUse = false;
        #endregion
        
        [Header("UI Active Variables")]
        [SerializeField] private BoolReference uiPanelActive;
        [SerializeField] private GameEvent uiChangeEvent;

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

        private IEnumerator CheckSwipes()
        {
            while (true)
            {
                foreach (var actualTouch in Input.touches)
                {
                    switch (actualTouch.phase)
                    {
                        case TouchPhase.Began:
                            couldBeSwipe = true;
                            startPos = actualTouch.position;
                            swipeStartTime = Time.time;
                            stationaryForFrames = 0;
                            break;
                        case TouchPhase.Stationary:
                            if (IsContinuallyStationary(frames: 8))
                            {
                                couldBeSwipe = false;
                                NoHorizontalActions();
                                NoVerticalActions();
                            }
                            break;
                        case TouchPhase.Ended:
                            if (IsASwipeHorizontal(actualTouch))
                            {
                                couldBeSwipe = false;
                                if (Mathf.Sign(actualTouch.position.x - startPos.x) == 1f)
                                    RightDirectionActions();
                                else if (Mathf.Sign(actualTouch.position.x - startPos.x) != 1f)
                                    LeftDirectionActions();
                            }
                            else if (IsASwipeVertical(actualTouch))
                            {
                                couldBeSwipe = false;
                                if (Mathf.Sign(actualTouch.position.y - startPos.y) == 1f)
                                    UpDirectionActions();
                                else
                                    DownDirectionActions();
                            }
                            else
                            {
                                var ped = new PointerEventData(EventSystem.current) {position = actualTouch.position};
                                var hits = new List<RaycastResult>();
                                EventSystem.current.RaycastAll(ped, hits);
                            }
                            break;
                        case TouchPhase.Moved:
                        case TouchPhase.Canceled:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    lastPhase = actualTouch.phase;
                }
                yield return null;
            }
        }

        private bool IsContinuallyStationary(int frames)
        {
            if (lastPhase == TouchPhase.Stationary)
                stationaryForFrames++;
            else
                stationaryForFrames = 1;
            return stationaryForFrames > frames;
        }

        private bool IsASwipeHorizontal(Touch targetTouch)
        {
            var swipeTime = Time.time - swipeStartTime;
            var swipeDistX = Mathf.Abs(targetTouch.position.x - startPos.x);
            return couldBeSwipe && swipeTime < maxSwipeTime.Value && swipeDistX > minSwipeDistance.Value;
        }

        private bool IsASwipeVertical(Touch targetTouch)
        {
            var swipeTime = Time.time - swipeStartTime;
            var swipeDistY = Mathf.Abs(targetTouch.position.y - startPos.y);
            return couldBeSwipe && swipeTime < maxSwipeTime.Value && swipeDistY > minSwipeDistance.Value;
        }
        #endregion

        #region Horizontal Functions

        private void CheckingHorizontalAxis()
        {
            if (Input.GetAxisRaw(Global.HorizontalAxis) < 0 && !isHorizontalAxisInUse)
                LeftDirectionActions();
            else if (Input.GetAxisRaw(Global.HorizontalAxis) > 0 && !isHorizontalAxisInUse)
                RightDirectionActions();
            else if (Input.GetAxisRaw(Global.HorizontalAxis) == 0)
                NoHorizontalActions();
        }

        private void NoHorizontalActions()
        {
            horizontalAxis.Value = 0;
            if (horizontalSinglePress.Value)
                isHorizontalAxisInUse = false;
            nonHorizontalAxisEvent.Raise();
        }

        private void RightDirectionActions()
        {
            horizontalAxis.Value = 1;
            if (horizontalSinglePress.Value)
                isHorizontalAxisInUse = true;
            rightButtonEvent.Raise();
        }

        private void LeftDirectionActions()
        {
            horizontalAxis.Value = -1;
            if (horizontalSinglePress.Value)
                isHorizontalAxisInUse = true;
            leftButtonEvent.Raise();
        }

        #endregion

        #region Vertical Functions
        private void CheckingVerticalAxis()
        {
            if (Input.GetAxisRaw(Global.VerticalAxis) < 0 && !isVerticalAxisInUse)
                DownDirectionActions();
            else if (Input.GetAxisRaw(Global.VerticalAxis) > 0 && !isVerticalAxisInUse)
                UpDirectionActions();
            else if (Input.GetAxisRaw(Global.VerticalAxis) == 0)
                NoVerticalActions();
        }

        private void NoVerticalActions()
        {
            verticalAxis.Value = 0;
            if (verticalSinglePress.Value)
                isVerticalAxisInUse = false;
            nonVerticalAxisEvent.Raise();
        }

        private void UpDirectionActions()
        {
            verticalAxis.Value = 1;
            if (verticalSinglePress.Value)
                isVerticalAxisInUse = true;
            upButtonEvent.Raise();
        }

        private void DownDirectionActions()
        {
            verticalAxis.Value = -1;
            if (verticalSinglePress.Value)
                isVerticalAxisInUse = true;
            downButtonEvent.Raise();
        }

        #endregion

        private void CheckingStartButton()
        {
            if (Input.GetAxisRaw(Global.StartAxis) != 0 && !isStartAxisInUse)
            {
                startButtonEvent.Raise();
                isStartAxisInUse = true;
            }
            else if (Input.GetAxisRaw(Global.StartAxis) == 0)
                isStartAxisInUse = false;
        }

        private void CheckingSquareButton()
        {
            if (Input.GetAxisRaw(Global.FireAxis) != 0 && !isSquareAxisInUse)
            {
                squareButtonEvent.Raise();
                isSquareAxisInUse = true;
            }
            else if (Input.GetAxisRaw(Global.FireAxis) == 0)
                isSquareAxisInUse = false;
        }

        private void CheckingXButton()
        {
            if (Input.GetAxisRaw(Global.JumpAxis) != 0 && !isXAxisInUse)
            {
                xButtonEvent.Raise();
                isXAxisInUse = true;
            }
            else if (Input.GetAxisRaw(Global.JumpAxis) == 0)
                isXAxisInUse = false;
        }

        private void CheckChangeButtonUi()
        {
            if (uiPanelActive.Value)
                uiChangeEvent.Raise();
        }
    }
}
