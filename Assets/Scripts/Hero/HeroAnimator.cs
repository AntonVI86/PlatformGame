using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimator : MonoBehaviour
{
    protected Animator _animator;

    public int RunHash { get; private set; } = Animator.StringToHash("Run");
    public int AttackHash { get; private set; } = Animator.StringToHash("Attack");
    public int JumpHash { get; private set; } = Animator.StringToHash("Jump");
    public int FallHash { get; private set; } = Animator.StringToHash("Fallen");
}
