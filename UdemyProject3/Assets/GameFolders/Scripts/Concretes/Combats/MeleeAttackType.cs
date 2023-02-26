using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.ScriptableObjects;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class MeleeAttackType : IAttackType
    {
        Transform _transformObject;
        AttackSO _attackSO;

        public MeleeAttackType(Transform transformObject, AttackSO attackSO)
        {
            _transformObject = transformObject;
            _attackSO = attackSO;
        }

        public void AttackAction()
        {
            Vector3 attackPoint=_transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackPoint, _attackSO.FloatValue, _attackSO.LayerMask);

            foreach (Collider collider in colliders)
            {
                if(collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }


        }
    }
}
