using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Controllers;
using Unity.VisualScripting;
using UnityEngine;

namespace UdemyProject3.Animations
{
    public class CharacterAnimation
    {
        Animator _animator;

        public CharacterAnimation(IEntityController entity)
        {
            _animator = entity.transform.GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(float moveSpeed)
        {
            if (_animator.GetFloat("moveSpeed") == moveSpeed) return;

            _animator.SetFloat("moveSpeed", moveSpeed,.1f,Time.deltaTime);
        }

        public void AttackAnimation(bool canAttack)
        {
            _animator.SetBool("isAttack", canAttack);
        }

        public void DeadAnimation(string parameterName)
        {
            _animator.SetTrigger(parameterName);
        }
    }
}
