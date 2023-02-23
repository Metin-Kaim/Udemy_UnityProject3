using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Inputs;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UnityEngine;
using UnityEngine.UIElements;

namespace UdemyProject3.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] WeaponController _currentWeapon;


        IInputReader _input;
        IMover _mover;
        CharacterAnimation _animation;
        IRotator _xRotator;
        IRotator _yRotator;

        Vector3 _direction;
        Vector2 _rotation;

        public Transform TurnTransform => _turnTransform;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        private void Update()
        {
            _direction = _input.Direction;

            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if(_input.IsAttackButtonPress)
            {
                _currentWeapon.Attack();   
            }
        }
        private void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);
           
        }

        private void LateUpdate()
        {
            _animation.MoveAnimation(_direction.magnitude);
        }

    }

}
