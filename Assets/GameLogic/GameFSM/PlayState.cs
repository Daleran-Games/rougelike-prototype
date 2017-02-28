using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{

    public event StateChangeHandler RequestMenuEvent;
    public event StateChangeHandler PlayerExitEvent;
    public event StateChangeHandler PlayerDieEvent;

    bool playerIsMoving = false;
    public bool PlayerIsMoving
    {
        get { return playerIsMoving; }
        private set { playerIsMoving = value; }
    }



    Player player;
    SaveData save;

    private void Start()
    {
        save = GameManager.Instance.Save;
    }

    void OnEnable()
    {
        if (StateEnabled != null)
            StateEnabled(this);

        player = GameObject.FindGameObjectWithTag("Player").GetRequiredComponent<Player>();

        GameInput.Instance.LeftAbilityEvent += PlayerLeftAbility;
        GameInput.Instance.RightAbilityEvent += PlayerRightAbility;
        GameInput.Instance.SkipEvent += PlayerSkipTurn;
        GameInput.Instance.MenuEvent += OnRequestMenu;
        player.PlayerExitEvent += OnPlayerExit;
        player.PlayerDeathEvent += OnPlayerExit;

    }

    private void FixedUpdate()
    {
        if (HandlePlayerInput () || player.ActionTimer > 0)
        {
            Time.timeScale = 1f;
            PlayerIsMoving = true;
        }
        else
        {
            Time.timeScale = save.SlowTimeScale;
            PlayerIsMoving = false;
        }
            
    }

    void OnDisable()
    {
        RemoveEvents();

        if (StateEnabled != null)
            StateDisabled(this);
    }


    void OnRequestMenu()
    {
        if(RequestMenuEvent != null)
            RequestMenuEvent(this);
    }

    void OnPlayerExit ()
    {
        if (PlayerExitEvent !=null)
            PlayerExitEvent(this);
    }

    void OnPlayerDeath()
    {
        if (PlayerDieEvent != null)
            PlayerDieEvent(this);
    }


    bool HandlePlayerInput ()
    {
        bool inputEncountered = false;

        float hz = GameInput.Instance.Horizontal.GetAxisValue();
        float vr = GameInput.Instance.Vertical.GetAxisValue();

        if (hz != 0f || vr != 0f)
        {
            inputEncountered = true;
            MovePlayer(hz, vr, Input.mousePosition);
        }

        return inputEncountered;

    }

    void MovePlayer (float horizontal, float vertical, Vector2 mousePos)
    {
        player.Move(horizontal, vertical, mousePos);
    }

    void PlayerLeftAbility()
    {
        if (player.ActionTimer == 0)
        {
            PlayerIsMoving = true;
            player.UseLeftAbility();
        }
    }

    void PlayerRightAbility()
    {
        if (player.ActionTimer == 0)
        {
            PlayerIsMoving = true;
            player.UseRightAbility();
        }

    }

    void PlayerSkipTurn ()
    {
        PlayerIsMoving = true;
    }

    void RemoveEvents ()
    {
        GameInput.Instance.LeftAbilityEvent -= PlayerLeftAbility;
        GameInput.Instance.RightAbilityEvent -= PlayerRightAbility;
        GameInput.Instance.SkipEvent -= PlayerSkipTurn;
        GameInput.Instance.MenuEvent += OnRequestMenu;
        player.PlayerExitEvent -= OnPlayerExit;
        player.PlayerDeathEvent -= OnPlayerExit;
    }
}
