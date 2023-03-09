
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Helpers;
using UdemyProject3.Controllers;
using UnityEngine;
using UnityEngine.UIElements;

namespace UdemyProject3.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] int _maxCountOnGame = 50;
        [SerializeField] List<EnemyController> _enemies;

        public List<Transform> Targets { get; set; }
        public bool CanSpawn => _maxCountOnGame > _enemies.Count;
        public bool IsListEmpty => _enemies.Count <= 0;

        private void Awake()
        {
            SetSingletonThisGameObject(this);

            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount();
        }

        public void DestRoyAllEnemies()
        {
            foreach (var enemy in _enemies)
            {
                Destroy(enemy.gameObject);
            }

            _enemies.Clear();
        }
    }
}
