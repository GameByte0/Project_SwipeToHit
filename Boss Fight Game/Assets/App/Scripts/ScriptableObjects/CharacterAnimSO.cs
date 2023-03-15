using UnityEngine;


[CreateAssetMenu(fileName = "_AnimSO", menuName = "SciptableObjects/AnimationsSO")]
public class CharacterAnimSO : ScriptableObject
{
    [Header("Animations:")]
    [SerializeField] private AnimationClip leftSwipeAnim;
    [SerializeField] private AnimationClip rightSwipeAnim;
    [SerializeField] private AnimationClip upSwipeAnim;
    [SerializeField] private AnimationClip downSwipeAnim;
    [SerializeField] private AnimationClip specialAnim;
    [SerializeField] private AnimationClip defenceAnim;
    [SerializeField] private AnimationClip itemUseAnim;

    public string PlayAnimation(ActionTypes a)
    {
        switch (a)
        {
            case ActionTypes.UP:
                return upSwipeAnim.name;

            case ActionTypes.RIGHT:
                return rightSwipeAnim.name;

            case ActionTypes.DOWN:
                return downSwipeAnim.name;

            case ActionTypes.LEFT:
                return leftSwipeAnim.name;

            default:

                return null;
        }

    }


}
