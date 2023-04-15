using UnityEngine;
using UnityEngine.InputSystem;

namespace Playfab_Tutorial.Inputs
{
    public class InputReader
    {
        readonly GameInputActions _gameInput;

        public Vector2 Direction { get; private set; }
        public bool IsAttack { get; private set; }

        public InputReader()
        {
            _gameInput = new GameInputActions();

            _gameInput.Player.Move.performed += OnMoveProcess;
            _gameInput.Player.Move.canceled += OnMoveProcess;

            _gameInput.Player.Attack.performed += OnAttackProcess;
            _gameInput.Player.Attack.canceled += OnAttackProcess;
            
            _gameInput.Enable();
        }

        void OnAttackProcess(InputAction.CallbackContext context)
        {
            IsAttack = context.ReadValueAsButton();
        }

        void OnMoveProcess(InputAction.CallbackContext context)
        {
            Direction = context.ReadValue<Vector2>();
        }
    }
}