using UnityEngine;

namespace Playfab_Tutorial.Handlers
{
    public class AnimationHandler
    {
        readonly Animator _animator;
        static readonly int MoveSpeed = Animator.StringToHash("moveSpeed");

        public AnimationHandler(Animator animator)
        {
            _animator = animator;
        }

        public void MovementAnimation(float speed)
        {
            _animator.SetFloat(MoveSpeed, speed);
        }
    }
}