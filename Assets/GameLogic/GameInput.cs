using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DalLib;

public delegate void ToggleKeyHandler(bool newValue);
public delegate void EventKeyHandler();

public class GameInput : MonoBehaviour {

    protected GameInput() { }

    public static GameInput Instance = null;

    private EventKey continueEvent = new EventKey("Skip");
    public event EventKeyHandler ContinueEvent;

    private EventKey quitKey = new EventKey("Cancel");
    public event EventKeyHandler QuitEvent;

    private ControlAxis horizontal = new ControlAxis("Horizontal");
    public ControlAxis Horizontal
    {
        get { return horizontal; }
        set { horizontal = value; }
    }

    private ControlAxis vertical = new ControlAxis("Vertical");
    public ControlAxis Vertical
    {
        get { return vertical; }
        set { vertical = value; }
    }

    public EventKey leftAbility = new EventKey("Fire1");
    public event EventKeyHandler LeftAbilityEvent;

    public EventKey rightAbility = new EventKey("Fire1");
    public event EventKeyHandler RightAbilityEvent;

    public EventKey skipTurn = new EventKey("Skip");

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Update()
    {

        if (continueEvent.IsPressedOnce() && ContinueEvent != null)
            ContinueEvent();

        if (quitKey.IsPressedOnce() && QuitEvent != null)
            QuitEvent();
       

    }

    private void FixedUpdate()
    {
        if (leftAbility.IsPressedOnce() && LeftAbilityEvent != null)
            LeftAbilityEvent();

        if (rightAbility.IsPressedOnce() && RightAbilityEvent != null)
            RightAbilityEvent();

    }

    public class ToggleKey
    {
        bool isAxisInUse = false;
        bool keyState = false;
        string axis;

        public ToggleKey(string axisName, bool startingState)
        {
            axis = axisName;
            keyState = startingState;
        }

        public string GetAxisName()
        {
            return axis;
        }

        public bool GetToggleState()
        {
            return keyState;
        }

        public bool SetToggleState()
        {
            if (Input.GetAxisRaw(axis) != 0)
            {
                if (isAxisInUse == false)
                {
                    keyState = !keyState;

                    isAxisInUse = true;
                    return true;
                }
            }
            if (Input.GetAxisRaw(axis) == 0)
            {
                isAxisInUse = false;
                
            }
            return false;
        }

    }

    public class EventKey
    {
        string axis;
        bool alreadyPressed = false;

        public EventKey(string axisName)
        {
            axis = axisName;
        }

        public string GetAxisName()
        {
            return axis;
        }

        public bool IsPressed()
        {
            if (Input.GetAxisRaw(axis) != 0f)
                return true;
            else
                return false;
        }

        public bool IsPressedOnce()
        {
            if (Input.GetAxisRaw(axis) != 0f && alreadyPressed == false)
            {
                alreadyPressed = true;
                return true;
            }
            else if (Input.GetAxisRaw(axis) != 0f && alreadyPressed == true)
            {
                return false;
            }
            else if (Input.GetAxisRaw(axis) == 0f && alreadyPressed == true)
            {
                alreadyPressed = false;
                return false;
            }
            else
                return false;

        }
    }

    public class ControlAxis
    {
        string axis;

        public ControlAxis(string axisName)
        {
            axis = axisName;
        }

        public string GetAxisName()
        {
            return axis;
        }

        public float GetAxisValue()
        {
            return Input.GetAxis(axis);
        }

        public float GetAxisRaw ()
        {
            return Input.GetAxisRaw(axis);
        }

        public bool IsAxisInUse()
        {
            if (Input.GetAxis(axis) != 0)
                return true;
            else
                return false;
        }

        public bool IsPositiveAndInUse()
        {
            if (Input.GetAxis(axis) > 0 && IsAxisInUse())
                return true;
            else
                return false;
        }

    }
}
