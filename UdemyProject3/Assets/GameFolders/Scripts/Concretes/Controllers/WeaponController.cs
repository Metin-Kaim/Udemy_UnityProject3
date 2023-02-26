using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Combats;
using UdemyProject3.ScriptableObjects;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;
        

        float _currentTime;
        IAttackType _attackType;

        private void Awake()
        {
            _attackType = _attackSO.GetAttackType(_transformObject);
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            _canFire = _currentTime > _attackSO.AttackMaxDelay;
        }

        public void Attack()
        {
            if (!_canFire) return;
            
            _attackType.AttackAction();

            _currentTime = 0f;
        }
    }
}
