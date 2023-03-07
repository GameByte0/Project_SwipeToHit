using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "_AnimSO", menuName = "SciptableObjects/AnimationsSO")]
public class PlayerAnimSO : ScriptableObject
{
    [SerializeField] private AnimationClip leftSwipeAnim;
    [SerializeField] private AnimationClip rightSwipeAnim;
    [SerializeField] private AnimationClip upSwipeAnim;
    [SerializeField] private AnimationClip downSwipeAnim;
    [SerializeField] private AnimationClip specialAnim;
    [SerializeField] private AnimationClip defenceAnim;
    [SerializeField] private AnimationClip itemUseAnim;

    public string PlayAnimation(int a)
    {
        switch (a)
        {
            case 1 :
                return upSwipeAnim.name;
                
            case 2:
                return rightSwipeAnim.name;
                
            case 3:
                return downSwipeAnim.name;
                
            case 4:
                return leftSwipeAnim.name;

            default:
                
                return null;
        }

    }


}
