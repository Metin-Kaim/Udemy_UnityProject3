using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        CharacterAnimation _characterAnimation;
        NavMeshAgent _agent;
        InventoryController _inventoryController;

        Transform _playerTransform;
        bool _canAttack;

        IMover _mover;
        IHealth _health;

        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _mover = new MoveWithNavMesh(this);
            _characterAnimation = new CharacterAnimation(this);
            _agent = GetComponent<NavMeshAgent>();
            _inventoryController = GetComponent<InventoryController>();
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;
        }

        private void Update()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_playerTransform.position, 10f);

            _canAttack = Vector3.Distance(_playerTransform.position, transform.position) <= _agent.stoppingDistance && _agent.velocity == Vector3.zero;
        }

        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }

        private void LateUpdate()
        {
            _characterAnimation.MoveAnimation(_agent.velocity.magnitude);
            _characterAnimation.AttackAnimation(_canAttack);
        }
    }
}
