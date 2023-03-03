using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UdemyProject3.States;
using UdemyProject3.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace UdemyProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        CharacterAnimation _characterAnimation;
        NavMeshAgent _agent;
        InventoryController _inventoryController;
        StateMachine _stateMachine;


        Transform _playerTransform;
        bool _canAttack;

        public bool CanAttack => Vector3.Distance(_playerTransform.position, transform.position) <= _agent.stoppingDistance && _agent.velocity == Vector3.zero;

        public IMover Mover { get; private set; }
        IHealth _health;


        private void Awake()
        {
            _health = GetComponent<IHealth>();
            Mover = new MoveWithNavMesh(this);
            _characterAnimation = new CharacterAnimation(this);
            _agent = GetComponent<NavMeshAgent>();
            _inventoryController = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;

            ChaseState chaseState = new ChaseState(this,_playerTransform);
            AttackState attackState = new AttackState();
            DeadState deadState = new DeadState();

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
            
        }

        private void Update()
        {
            if (_health.IsDead) return;

            _stateMachine.Tick();
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
