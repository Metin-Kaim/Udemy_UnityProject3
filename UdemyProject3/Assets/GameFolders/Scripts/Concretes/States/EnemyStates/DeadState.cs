using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.States;
using UnityEngine;

namespace UdemyProject3.States.EnemyStates
{
    public class DeadState : IState
    {
        IEnemyController _enemyController;
        float _maxTime = 5f;
        float _cuurentTime = 0f;

        public DeadState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnEnter()
        {
            _enemyController.Dead.DeadAction();
            _enemyController.Animation.DeadAnimation("dying");
            _enemyController.transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {

        }

        public void TickFixed()
        {

        }

        public void TickLate()
        {

        }
    }
}
