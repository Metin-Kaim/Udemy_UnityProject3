using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class RangeAttackType : IAttackType
    {
        AttackSO _attackSO;
        Camera _camera;

        public RangeAttackType(Transform transformObject, AttackSO attackSO)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSO = attackSO;
        }


        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2);
            if (Physics.Raycast(ray, out RaycastHit hit, _attackSO.FloatValue, _attackSO.LayerMask))
            {
                //IHealth health = hit.collider.GetComponent<IHealth>();
                //
                //if(health != null)
                //{
                //    health.TakeDamage(_damage);
                //}

                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }
        }
    }
}
