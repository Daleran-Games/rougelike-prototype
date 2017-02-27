using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

    public int damage = 1;
    public int attackCost = 2;
    public int moveCost = 1;
    public int healAmount = 4;
    public int healCost = 10;
    public Color32 hitColor;
    public Color32 healColor;
    public Color32 chargeColor;
    public float flashDuration = 0.2f;
    public AudioClip[] moveSounds;
    public AudioClip[] healSounds;
    public AudioClip[] chargeSounds;


    bool tutorialState = true;
    bool tutorialKeyInUse = false;
    Animator playerAnimator;
    EnergyBehaviour playerEnergy;
    ConditionBehaviour playerCondition;
    SpriteRenderer playerRenderer;

    private void Awake()
    {
        playerAnimator = gameObject.GetRequiredComponent<Animator>();
        playerEnergy = gameObject.GetRequiredComponent<EnergyBehaviour>();
        playerCondition = gameObject.GetRequiredComponent<ConditionBehaviour>();
        playerRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
    }

    // Use this for initialization
    protected override void Start ()
    {
        playerEnergy.Energy = GameManager.instance.playerSave.PlayerEnergy;
        playerCondition.Condition = GameManager.instance.playerSave.PlayerCondition;

        if (GameManager.instance.Zone > 1)
            tutorialState = false;

        base.Start();
	}

    private void OnEnable()
    {
        playerEnergy.EnergyStatChange += OnEnergyChange;
        playerCondition.ConditionStatChange += OnConditionChange;
    }

    private void OnDisable()
    {
        GameManager.instance.playerSave.PlayerEnergy = playerEnergy.Energy;
        GameManager.instance.playerSave.PlayerCondition = playerCondition.Condition;
        playerEnergy.EnergyStatChange -= OnEnergyChange;
        playerCondition.ConditionStatChange -= OnConditionChange;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;

        SetTutorialKeyState();

        if (horizontal != 0 || vertical != 0)
            AttemptMove<ConditionBehaviour>(horizontal, vertical);
        else if ((int)Input.GetAxisRaw("Heal") != 0)
            HealAbility();
        else if ((int)Input.GetAxisRaw("Skip") != 0)
            SkipTurn();


        if (tutorialState == true)
            GameManager.instance.SetTutorialState(true);
        else
            GameManager.instance.SetTutorialState(false);

        if (Input.GetAxisRaw("Cancel") !=0)
            Application.Quit();

    }

    void SetTutorialKeyState()
    {
        if (Input.GetAxisRaw("Help") != 0)
        {
            if (tutorialKeyInUse == false)
            {
                tutorialState = !tutorialState;

                tutorialKeyInUse = true;
            }
        }
        if (Input.GetAxisRaw("Help") == 0)
        {
            tutorialKeyInUse = false;
        }
    }


    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        if (Move(xDir,yDir, out hit))
        {
            SoundManager.instance.RandomSFX(moveSounds);
            playerEnergy.Energy -= moveCost;
        }

        GameManager.instance.playersTurn = false;
    }

    void HealAbility()
    {
        if (playerEnergy.Energy > healCost && playerCondition.Condition < playerCondition.MaxCondition)
        {
            playerEnergy.Energy -= healCost;
            playerCondition.Condition += healAmount;
            SoundManager.instance.RandomSFX(healSounds);
            Debug.Log("Flashing Heal Color");
            StartCoroutine(FlashColor(healColor));
            GameManager.instance.playersTurn = false;
        }

    }

    void SkipTurn()
    {
        GameManager.instance.playersTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            Restart();
            enabled = false;
        }

        if (collision.gameObject.GetComponent<Collectable>() !=null)
        {
            Collectable collect = collision.gameObject.GetComponent<Collectable>();
            int energyAdded = collect.UseCollectable();
            Debug.Log("Flashing Charge Color");
            StartCoroutine(FlashColor(chargeColor));
            SoundManager.instance.RandomSFX(chargeSounds);
            playerEnergy.Energy += energyAdded;
        }

    }

    protected override void OnCantMove<T>(T component)
    {
        ConditionBehaviour hitObject = component as ConditionBehaviour;
        hitObject.Condition -= damage;
        playerEnergy.Energy -= attackCost;
        playerAnimator.SetTrigger("playerChop");
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void OnEnergyChange (int change, bool increase)
    {
        if (increase)
        {

        }  
        else
            CheckIfGameOver();
    }

    public void OnConditionChange (int change, bool increase)
    {
        if (increase)
        {

        }
        else
        {
            playerAnimator.SetTrigger("playerHit");
            StartCoroutine(FlashColor(hitColor));
            CheckIfGameOver();
        }

    }

    private void CheckIfGameOver()
    {
        if (playerEnergy.Energy <= 0 || playerCondition.Condition <= 0)
        {
            SoundManager.instance.PlaySingle(GameManager.instance.gameOverSound);
            SoundManager.instance.musicSource.Stop();
            GameManager.instance.GameOver();
        }

    }

    IEnumerator FlashColor(Color32 color)
    {
        playerRenderer.color = color;
        yield return new WaitForSeconds(flashDuration);
        playerRenderer.color = Color.white;
    }

}
