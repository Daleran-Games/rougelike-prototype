using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.Characters;

namespace DaleranGames
{
    public class PlayState : GameState
    {

        public event StateChangeHandler RequestMenuEvent;
        public event StateChangeHandler PlayerExitEvent;
        public event StateChangeHandler PlayerDieEvent;

        bool playerIsMoving = false;
        public bool PlayerIsMoving
        {
            get { return playerIsMoving; }
            private set{ playerIsMoving = value; }
        }

        bool playerHighlightingTarget = false;
        public bool PlayerHighlightingTarget
        {
            get { return playerHighlightingTarget; }
            private set { playerHighlightingTarget = value; }
        }




        Player player;
        SaveData save;
        ConfigSettings config;

        private void Start()
        {
            save = GameManager.Instance.Save;
            config = GameManager.Instance.Config;
        }

        void OnEnable()
        {
            if (StateEnabled != null)
                StateEnabled(this);

            player = GameObject.FindGameObjectWithTag("Player").GetRequiredComponent<Player>();

            GameInput.Instance.LeftAbilityEvent += PlayerLeftAbility;
            GameInput.Instance.RightAbilityEvent += PlayerRightAbility;
            GameInput.Instance.QuitEvent += OnRequestMenu;
            player.PlayerExitEvent += OnPlayerExit;
            player.PlayerDeathEvent += OnPlayerDeath;

        }

        private void Update()
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(player.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position, player.attackRange);
            PlayerHighlightingTarget = false;

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D h in hits)
                {

                    ConditionBehaviour cond = h.transform.gameObject.GetComponent<ConditionBehaviour>();

                    if (cond != null && cond.Condition > 0 && cond.tag != "Player")
                        PlayerHighlightingTarget = true;
                }
            }

        }

        private void FixedUpdate()
        {
            if (HandlePlayerInput() || player.ActionTimer > 0)
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = config.InititalFixedDeltaTime;
                PlayerIsMoving = true;
            }
            else
            {
                Time.timeScale = save.SlowTimeScale;
                Time.fixedDeltaTime = config.InititalFixedDeltaTime * Time.timeScale;
                PlayerIsMoving = false;
            }

        }

        void OnDisable()
        {
            GameInput.Instance.LeftAbilityEvent -= PlayerLeftAbility;
            GameInput.Instance.RightAbilityEvent -= PlayerRightAbility;
            GameInput.Instance.QuitEvent -= OnRequestMenu;
            player.PlayerExitEvent -= OnPlayerExit;
            player.PlayerDeathEvent -= OnPlayerExit;

            if (StateEnabled != null)
                StateDisabled(this);
        }


        void OnRequestMenu()
        {
            if (RequestMenuEvent != null)
                RequestMenuEvent(this);
        }

        void OnPlayerExit()
        {

            if (PlayerExitEvent != null)
                PlayerExitEvent(this);
        }

        void OnPlayerDeath()
        {
            if (PlayerDieEvent != null)
                PlayerDieEvent(this);
        }


        bool HandlePlayerInput()
        {
            bool inputEncountered = false;

            float hz = GameInput.Instance.Horizontal.GetAxisValue();
            float vr = GameInput.Instance.Vertical.GetAxisValue();
            bool skip = GameInput.Instance.skipTurn.IsPressed();

            if (hz != 0f || vr != 0f)
            {
                inputEncountered = true;
                player.MovePlayer(new Vector2(hz,vr));
            }

            if (skip)
                inputEncountered = true;

            if (hz == 0 && vr == 0)
                player.StopPlayer();

            return inputEncountered;

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

    } 
}
