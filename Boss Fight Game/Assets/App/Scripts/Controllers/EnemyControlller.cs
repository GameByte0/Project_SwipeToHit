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




    // Start is called before the first frame update
    void Start()
    {
        enemyIndex = PlayerPrefs.GetInt("EnemyIndex");
        animator = GetComponent<Animator>();
        enemyAnimSO = GameManager.Instance.CharacterDataBase[enemyIndex].AnimationSO;

        //quick AI for Tests
        //InvokeRepeating("EnemyRandomAction", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void EnemyRandomAction()
    {
        int random = Random.Range(0, 4);
        ActionTypes a;
        Debug.Log("   reache here");
        switch (random)
        {
            case 0 :
                a = ActionTypes.UP;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                GameEvents.RaiseOnChangeTurn();
                break;
            case 1:
                a = ActionTypes.RIGHT;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                GameEvents.RaiseOnChangeTurn();
                break;
            case 2:
                a = ActionTypes.DOWN;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                GameEvents.RaiseOnChangeTurn();
                break;
            case 3:
                a = ActionTypes.LEFT;
                animator.Play(enemyAnimSO.PlayAnimation(a));
                GameEvents.RaiseOnChangeTurn();
                break;
            default:
                animator.Play(enemyAnimSO.PlayAnimation(0));
                GameEvents.RaiseOnChangeTurn();
                break;
        }


    }
}
