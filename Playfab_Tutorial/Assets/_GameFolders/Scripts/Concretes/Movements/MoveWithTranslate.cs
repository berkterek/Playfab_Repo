using UnityEngine;

namespace PlayFab_Tutorial.Movements
{
    public class MoveWithTranslate
    {
        readonly Transform _moveTransform;
        readonly Transform _scaleTransform;
        readonly float _speed;
        Vector2 _direction;

        public MoveWithTranslate(MovementDataEntity dataModel)
        {
            _moveTransform = dataModel.MoveTransform;
            _scaleTransform = dataModel.ScaleTransform;
            _speed = dataModel.Speed;
        }

        public void Tick(Vector2 direction)
        {
            _direction = direction;
        }

        public void FixedTick()
        {
            _moveTransform.Translate(Time.deltaTime * _speed * _direction);
        }

        public void LateTick()
        {
            float x = _direction.x;
            _scaleTransform.localScale = new Vector3(x < 0 ? 1f : -1, 1f, 1f);
        }
    }

    public struct MovementDataEntity
    {
        public Transform MoveTransform { get; set; }
        public Transform ScaleTransform { get; set; }
        public float Speed { get; set; }
    }
}