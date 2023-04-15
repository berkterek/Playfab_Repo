using System;
using Playfab_Tutorial.Handlers;
using Playfab_Tutorial.Inputs;
using PlayFab_Tutorial.Movements;
using Unity.Netcode;
using UnityEngine;

namespace PlayFab_Tutorial.Controllers
{
    public class PlayerNetworkModelController : NetworkBehaviour
    {
        [SerializeField] NetworkVariable<int> _score;
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

        public override void OnNetworkSpawn()
        {
            base.OnNetworkSpawn();
            
            enabled = IsOwner;
        }

        void Update()
        {
            if (!Application.isFocused) return;
            
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

        public void ScoreIncrease(int score)
        {
            _score.Value += score;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out CoinController coin))
            {
                coin.Collected(this);
            }
        }
    }
}