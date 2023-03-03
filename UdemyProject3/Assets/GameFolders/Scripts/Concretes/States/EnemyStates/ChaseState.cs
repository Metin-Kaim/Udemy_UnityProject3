using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.States;
using UnityEngine;

namespace UdemyProject3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;

        IEntityController _entityController;
        Transform _target;
        public ChaseState(IEntityController entityController, Transform target)
        {
            _entityController = entityController;
            _target = target;
        }

        public void OnEnter()
        {

        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _entityController.Mover.MoveAction(_target.position, _speed);
        }
    }
}
