using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.ScriptableObjects;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;
        [SerializeField] float _maxTime;

        float _currentTime = 0f;

        private void Start()
        {
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);

            _currentTime = 0;
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }
    }
}
