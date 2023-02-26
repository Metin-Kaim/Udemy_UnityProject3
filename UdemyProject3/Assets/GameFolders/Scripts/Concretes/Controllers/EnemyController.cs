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
        [SerializeField] Transform _playerPrefab;
        CharacterAnimation _characterAnimation;
        NavMeshAgent _agent;

        IMover _mover;
        IHealth _health;

        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _mover = new MoveWithNavMesh(this);
            _characterAnimation = new CharacterAnimation(this);
            _agent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }

        private void LateUpdate()
        {
            _characterAnimation.MoveAnimation(_agent.velocity.magnitude);
        }
    }
}
