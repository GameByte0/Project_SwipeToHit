using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BossFightGame.Events;
using BossFightGame.GameManager;

public class EnemyControlller : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField]private Animator animator;
    [SerializeField]private CharacterAnimSO enemyAnimSO;
    [SerializeField]private int enemyIndex;

    private bool isRandomActionDone;
    public bool IsRandomActionDone { set => isRandomActionDone = value; }

    private float timer=0;

    private int randomDamage;




    // Start is called before the first frame update
    void Start()
    {
        enemyIndex = PlayerPrefs.GetInt("EnemyIndex");
        animator = GetComponent<Animator>();
        enemyAnimSO = GameManager.Instance.CharacterDataBase[enemyIndex].AnimationSO;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRandomActionDone==true)
        {
            //Debug.Log("RANOM ACTION IS TRUE");
            EnemyActionTimer();
        }
    }
    public void EnemyActionTimer()
    {
        if (timer>=Random.Range(3f,6f))
        {
            timer = 0;
            isRandomActionDone = false;
            EnemyRandomAction();
        }
        else
        {
            timer += Time.deltaTime;
            //Debug.Log(timer+"   is enemy timer");
        }
    }

    private void EnemyRandomAction()
    {
        EnemyRandomMove();
        randomDamage = Random.Range(15, 30);
        GameEvents.RaiseOnHitPlayer(randomDamage); //random damage to player;
        StartCoroutine(ChangeTurn());

    }
    private void EnemyRandomMove()
    {
        int random = Random.Range(0, 4);
        ActionTypes a;
        switch (random)
        {
            case 0:
                a = ActionTypes.UP;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                break;
            case 1:
                a = ActionTypes.RIGHT;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                break;
            case 2:
                a = ActionTypes.DOWN;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                break;
            case 3:
                a = ActionTypes.LEFT;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                break;
            default:
                animator.Play(enemyAnimSO.PlayAnimation(0));
                break;
        }
    }
    private IEnumerator ChangeTurn()
    {
        yield return new WaitForSeconds(2f);
        GameEvents.RaiseOnChangeTurn();
    }
}
