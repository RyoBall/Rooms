using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    [Header("move")]
    public Rigidbody2D rb;
    public float speed;
    public float moveTime;
    public float movedistance;
    public Transform currentRoom;
    public Transform targetRoom;
    public float moveParticleCd;
    public float moveParticleCdm;
    public GameObject moveParticle;
    public bool Walking;
    [Header("level")]
    public float exp;
    public float expm;
    public int level;
    public float levelfactor;
    public int unlockpoint;
    public int specialChipGetCount;
    public int ChipGetCount;
    [Header("AttackedState")]
    public PlayerState currentState;
    public float attackedtime;
    public bool attacked;
    [Header("factor")]
    public float health;
    public float healthm;
    public float attack;
    public float attackfactor;
    public float hidefactor;
    public float criticalfactor;
    public float criticalattackfactor;
    public int energy;
    [Header("Anim")]
    private Animator anim;
    public SpriteRenderer sprite;
    [Header("Attacked")]
    [SerializeField] private GameObject AttackedParticle;
    [SerializeField] private AudioSource attackedPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentState = new PlayerNormalState();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        enemyGeneratorController.instance.ExitAction += GetChipReward;
        ChoosePanel.instance.ExitAction += GetChipReward;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        levelup();
        StateControl();
        anim.SetBool("Walking",Walking);
        if (health <= 0) 
        {
            DeathImage.instance.Enter();
            StartCoroutine(DeadRoutine());
        }
    }
    IEnumerator DeadRoutine() 
    {
        yield return new WaitForSeconds(1);
        Blacker.instance.Enter(1,3f);
        StartCoroutine(DeadedRoutine());
    }
    IEnumerator DeadedRoutine() 
    {
        yield return new WaitForSeconds(3.1f);
        foreach (GameObject obj in gameManager.NotDestroyObjs)
        {
            Destroy(obj);
        }
        SceneManager.LoadScene("Enter");  
    } 
    void StateControl()
    {
        currentState.update();
    }
    void Move()
    {
        if (gameManager.instance.currentState == gameManager.GameState.InFight) 
        {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
            if (rb.velocity.x < 0) 
            {
                sprite.flipX = true;
            }
            else  if(rb.velocity.x>0)
            {
                sprite.flipX = false;
            }
            if (rb.velocity != Vector2.zero)
                Walking = true;
            else
                Walking = false;
        }
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            if (moveParticleCd > 0)
                moveParticleCd -= Time.deltaTime;
            if (moveParticleCd <= 0)
            {
                Instantiate(moveParticle, transform.position - .5f * Vector3.up, Quaternion.identity);
                moveParticleCd = moveParticleCdm;
            }
        }
    }

    #region AnimationAndMove
    public void BeginMove(int direction)
    {
        if (direction == -1)
            sprite.flipX = true;
        else
            sprite.flipX = false;
        Walking = true;
        transform.DOMove(transform.position + Vector3.right * direction * movedistance, moveTime);
        sprite.DOColor(new Color(1, 1, 1, 0), moveTime);
    }

    public void EndMove(int direction)
    {
        transform.DOMove(transform.position + Vector3.right * direction * movedistance, moveTime);
        sprite.DOColor(new Color(1, 1, 1, 1), moveTime).OnComplete(() => { Walking = false; sprite.flipX = false; });
    }
    #endregion
    void levelup()
    {
        if (exp >= expm)
        {
            level++;
            exp = 0;
            expm += 8;
            levelupreward();
        }
    }
    void levelupreward()
    {
        unlockpoint += 1;
        attack += 2;
        healthm += 10;
        health += 10;
        specialChipGetCount += 1;
        ChipGetCount += 1;
    }
    void GetChipReward()
    {
        if (specialChipGetCount >= 5)
        {
            specialChipGetCount -= 5;
            for (int i = 0; i < 3; i++)
            {
                gameManager.instance.GetChipButton(4, i, i);
            }
            ChoosePanel.instance.Enter();
        }
        else if (ChipGetCount >= 1)
        {
            ChipGetCount -= 1;
            for (int i = 0; i < 3; i++)
            {
                int j = Random.Range(1, 4);
                gameManager.instance.GetChipButton(j, Random.Range(0,gameManager.instance.chipsDic[j].Count), i);
            }
            ChoosePanel.instance.Enter();
        }
    }
    public void ChangeState(PlayerState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }
    #region Attacked
    public void Attacked(float damage)
    {
        if (!attacked)
        {
            if (Random.value > hidefactor)
            {
                attackedPlayer.Play();
                health -= damage;
                ChangeState(new PlayerAttackedState(false));
            }
            else 
            {
                ChangeState(new PlayerAttackedState(true));
            }
        }
    }
    public void AttackedAnim(bool hided)
    {
        if (hided) 
        {
            ;
        }
        else 
        {
            Instantiate(AttackedParticle, transform.position, Quaternion.identity);
        }
        StartCoroutine(AttackedRoutine());
    }
    IEnumerator AttackedRoutine()
    {
        yield return new WaitForSeconds(0);
        if (attacked)
        {
            if (sprite.color.a == 1)
            {
                sprite.color = new Color(1, 1, 1, .3f);
            }
            else
            {
                sprite.color = new Color(1, 1, 1, 1);
            }
            StartCoroutine(AttackedRoutine());
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
    #endregion
}
