using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Inputs;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Informations")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;

        [Header("UIs")]
        [SerializeField] GameObject _gameOverPanel;


        IInputReader _input;
        CharacterAnimation _animation;
        IRotator _xRotator;
        IRotator _yRotator;
        InventoryController _inventory;
        IHealth _health;

        Vector3 _direction;

        public Transform TurnTransform => _turnTransform;
        //public IMover Mover { get; private set; }
        IMover _mover;

        private void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _inventory = GetComponent<InventoryController>();
            _health = GetComponent<IHealth>();


            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }

        private void OnEnable()
        {
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("death");
                _gameOverPanel.SetActive(true);
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
            };
        }
        
        private void Update()
        {
            if (_health.IsDead) return;

            _direction = _input.Direction;

            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }

            if (_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }
        private void FixedUpdate()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_direction, _moveSpeed);

        }

        private void LateUpdate()
        {
            if (_health.IsDead) return;

            _animation.MoveAnimation(_direction.magnitude);
            _animation.AttackAnimation(_input.IsAttackButtonPress);

        }

    }

}
