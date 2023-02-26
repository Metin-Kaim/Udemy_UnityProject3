using System.Collections;
using System.Collections.Generic;
using UdemyProject3.ScriptableObjects;
using UnityEngine;

namespace UdemyProject3.Helper
{
    public class MeleeAttackRangeDisplay : MonoBehaviour
    {
        [SerializeField] AttackSO _attackSO;

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();   
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, _attackSO.FloatValue);
        }
    }
}
