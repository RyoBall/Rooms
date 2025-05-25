using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    //State
    public PlayerState currentState;
    public float attackedtime;
    public bool attacked;
    [Header("move")]
    public Rigidbody2D rb;
    public float speed;
    public float moveTime;
    private Animator anim;
    private string animBoolName;
    public Transform currentRoom;
    public Transform targetRoom;
    public float moveParticleCd;
    public float moveParticleCdm;
    public GameObject moveParticle;
    [Header("shoot")]
    public float cd;
    public float cdm;
    public GameObject bullet;
    [Header("level")]
    public float exp;
    public float expm;
    public int level;
    public float levelfactor;
    public int unlockpoint;
    public int specialChipGetCount;
    [Header("State")]
    public float currentSanity;
    public float maxSanity;
    [Header("factor")]
    public float health;
    public float healthm;
    public float attack;
    public float attackfactor;
    public float hidefactor;
    public float criticalfactor;
    public float criticalattackfactor;
    public int energy;
    [Header("UPGrade")]
    public List<UpgradeBase> Upgrades=new List<UpgradeBase>();
    // Start is called before the first frame update
    void Awake()
    {
        currentState = new PlayerNormalState();
        rb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        levelup();
        StateControl();
    }
    void StateControl() 
    {
        currentState.update();
    }
    void Move()
    {
        if(gameManager.instance.currentState==gameManager.GameState.InFight)
        rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), speed * Input.GetAxisRaw("Vertical"));
        if (rb.velocity.x != 0 || rb.velocity.y != 0) 
        {
            if (moveParticleCd > 0)
                moveParticleCd -= Time.deltaTime;
            if (moveParticleCd <= 0) 
            {
                Instantiate(moveParticle,transform.position-.5f*Vector3.up,Quaternion.identity);
                moveParticleCd = moveParticleCdm;
            }
        }
    }

    #region AnimationAndMove
    public void BeginMove(Vector3 target)
    {
        //禁用其他操作
        //anim.SetBool("beginMove", true);
        transform.DOMove(target, moveTime);
    }

    public void EndMove(Vector3 direction)
    {
        //anim.SetBool("beginMove", false);
        transform.position = targetRoom.transform.position;
        //anim.SetBool("endMove", true);
        transform.DOMove(-direction, moveTime);
            //.OnComplete(() => anim.SetBool("endMove", false));
        //恢复控制
    }
    #endregion
    void levelup()
    {
        if (exp >=expm) 
        {
            exp = 0;
            expm = 10 + level * levelfactor;
            level++;
            levelupreward();
        }
    }
    void levelupreward()
    {
        unlockpoint+=1;
        attack += 2;
        healthm+=10;
        health+=10;
        specialChipGetCount += 1;
        if (specialChipGetCount >= 5) 
        {
            specialChipGetCount = 0;
            gameManager.instance.GetChip(3, Random.Range(0, gameManager.instance.chipsDic[3].Count));
        }
    }
    public void ChangeState(PlayerState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
}
