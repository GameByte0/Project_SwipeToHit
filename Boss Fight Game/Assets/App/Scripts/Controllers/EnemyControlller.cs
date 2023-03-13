using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlller : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterAnimSO enemyAnimSO;




    // Start is called before the first frame update
    void Start()
    {
        //quick AI for Tests
        InvokeRepeating("EnemyRandomAction", 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void EnemyRandomAction()
    {
        int random = Random.Range(0, 4);
        ActionTypes a;
        
        switch (random)
        {
            case 0 :
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
}
