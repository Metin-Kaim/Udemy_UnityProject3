using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Combats;
using UnityEngine;

namespace UdemyProject3.ScriptableObjects
{
    enum AttackTypeEnum : byte
    {
        Range, Melee
    }

    [CreateAssetMenu(fileName = "Attack Info", menuName = "Combat/Attack Information/Create New", order = 51)]
    public class AttackSO : ScriptableObject
    {
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] int _damage = 10;
        [SerializeField] float _floatValue = 1f;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = .25f;
        [SerializeField] AnimatorOverrideController _animatorOverrideController;

        public int Damage => _damage;
        public float FloatValue => _floatValue;
        public LayerMask LayerMask => _layerMask;
        public float AttackMaxDelay => _attackMaxDelay;
        public AnimatorOverrideController AnimatorOverride => _animatorOverrideController;

        public IAttackType GetAttackType(Transform transform)
        {
            if (_attackType == AttackTypeEnum.Range)
                return new RangeAttackType(transform, this);
            else
                return new MeleeAttackType(transform, this);
        }

    }
}
