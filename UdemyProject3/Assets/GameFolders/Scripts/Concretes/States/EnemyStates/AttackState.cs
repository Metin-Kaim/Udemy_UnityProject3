using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.States;
using UnityEngine;

namespace UdemyProject3.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;

        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnEnter()
        {

        }

        public void OnExit()
        {
            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
        }

        public void TickFixed()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
            _enemyController.FindNearestTarget();
        }

        public void TickLate()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}
