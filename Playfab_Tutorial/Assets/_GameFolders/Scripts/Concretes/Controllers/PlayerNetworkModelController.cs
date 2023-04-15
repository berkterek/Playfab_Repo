using Playfab_Tutorial.Handlers;
using Playfab_Tutorial.Inputs;
using PlayFab_Tutorial.Movements;
using UnityEngine;

namespace PlayFab_Tutorial.Controllers
{
    public class PlayerNetworkModelController : MonoBehaviour
    {
        [SerializeField] float _speed = 5f;
        [SerializeField] Animator _animator;
        [SerializeField] Transform _body;

        MoveWithTranslate _mover;
        InputReader _input;
        AnimationHandler _animationHandler;

        void Awake()
        {
            _mover = new MoveWithTranslate(new MovementDataEntity()
                { Speed = _speed, MoveTransform = this.transform, ScaleTransform = _body });
            _input = new InputReader();
            _animationHandler = new AnimationHandler(_animator);
        }

        void Update()
        {
            _mover.Tick(_input.Direction);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            _mover.LateTick();
            _animationHandler.MovementAnimation(_input.Direction.magnitude);
        }
    }
}