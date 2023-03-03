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
    public class EnemyController : MonoBehaviour, IEntityController, IEnemyController
    {
        NavMeshAgent _agent;
        StateMachine _stateMachine;


        bool _canAttack;

        public bool CanAttack => Vector3.Distance(Target.position, transform.position) <= _agent.stoppingDistance && _agent.velocity == Vector3.zero;

        public IMover Mover { get; private set; }

        public InventoryController Inventory { get; set; }

        public CharacterAnimation Animation { get; set; }
        public Transform Target { get; set; }
        public float Magnitude => _agent.velocity.magnitude;

        IHealth _health;


        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine = new StateMachine();

            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
        }

        private void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;

            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
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
            _stateMachine.TickFixed();
        }

        private void LateUpdate()
        {
            _stateMachine.TickLate();
        }
    }
}
