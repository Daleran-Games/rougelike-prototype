using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public delegate void PlayerEventHandler();

public class Player : MovingObject {

    public int damage = 1;
    public float attackTime = 0.5f;
    public float repairTime = 2f;

    public float attackCost = 2f;
    public float moveCost = 1f;
    public int healAmount = 4;
    public float healCost = 10f;
    public Color32 hitColor;
    public Color32 healColor;
    public Color32 chargeColor;
    public float flashDuration = 0.2f;
    public AudioClip[] moveSounds;
    public AudioClip[] healSounds;
    public AudioClip[] chargeSounds;

    float actionTimer = 0f;
    public float ActionTimer
    {
        get { return actionTimer; }
        private set
        {
            if (value < 0)
                actionTimer = 0;
            else
                actionTimer = value;
        }
    }

    public event PlayerEventHandler PlayerExitEvent;
    public event PlayerEventHandler PlayerDeathEvent;

    Animator playerAnimator;
    EnergyBehaviour playerEnergy;
    ConditionBehaviour playerCondition;
    SpriteRenderer playerRenderer;
    SaveData save;

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
        save = GameManager.Instance.Save;
        playerEnergy.Energy = save.SavedPlayerEnergy;
        playerCondition.Condition = save.SavedPlayerCondition;

        base.Start();
	}

    private void OnEnable()
    {
        playerEnergy.EnergyStatChange += OnEnergyChange;
        playerCondition.ConditionStatChange += OnConditionChange;
    }

    private void OnDisable()
    {
        save.SavedPlayerEnergy = playerEnergy.Energy;
        save.SavedPlayerCondition = playerCondition.Condition;
        playerEnergy.EnergyStatChange -= OnEnergyChange;
        playerCondition.ConditionStatChange -= OnConditionChange;
    }

    // Update is called once per frame
    void Update ()
    {
        if (ActionTimer > 0)
            ActionTimer -= Time.deltaTime;

    }

    public override void Move(float horizontal, float vertical)
    {
        if(!SoundManager.Instance.efxSource.isPlaying)
            SoundManager.Instance.RandomSFX(moveSounds);

        playerEnergy.Energy -= moveCost * Time.deltaTime;

        base.Move(horizontal, vertical);
    } 

    public void StopPlayer ()
    {
        base.Move(0f, 0f);
    }

    public void UseLeftAbility ()
    {
        AttackAbility();
    }

    public void UseRightAbility ()
    {
        RepairAbility();
    }

    void AttackAbility ()
    {

        playerAnimator.SetTrigger("playerChop");
        playerEnergy.Energy -= attackCost;
        ActionTimer += attackTime;
    }

    void RepairAbility()
    {
        if (playerEnergy.Energy > healCost && playerCondition.Condition < playerCondition.MaxCondition)
        {
            ActionTimer += repairTime;
            playerEnergy.Energy -= healCost;
            playerCondition.Condition += healAmount;
            SoundManager.Instance.RandomSFX(healSounds);
            Debug.Log("Flashing Heal Color");
            StartCoroutine(FlashColor(healColor));
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            PlayerExitEvent();
            Debug.Log("Hit Exit");
        }

        if (collision.gameObject.GetComponent<Collectable>() !=null)
        {
            Collectable collect = collision.gameObject.GetComponent<Collectable>();
            int energyAdded = collect.UseCollectable();
            Debug.Log("Flashing Charge Color");
            StartCoroutine(FlashColor(chargeColor));
            SoundManager.Instance.RandomSFX(chargeSounds);
            playerEnergy.Energy += energyAdded;
        }

    }

    public void OnEnergyChange (float change, bool increase)
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
            SoundManager.Instance.musicSource.Stop();
            PlayerDeathEvent();
        }

    }

    IEnumerator FlashColor(Color32 color)
    {
        playerRenderer.color = color;
        yield return new WaitForSeconds(flashDuration);
        playerRenderer.color = Color.white;
    }

}
