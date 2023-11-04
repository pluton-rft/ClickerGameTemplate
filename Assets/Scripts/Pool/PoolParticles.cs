using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Clicker.Architecture {
    public class PoolParticles : MonoBehaviour {

        [SerializeField] private int _poolCount = 8;
        [SerializeField] private bool _autoExpand = false;
        [SerializeField] private DamageParticle _particlePrefab;
        [SerializeField] private Button _button;

        private PoolMono<DamageParticle> pool;

        private void Awake() {
            Game.OnGameInitializeEvent += OnGameStart;
        }

        private void OnGameStart() {
            _button.onClick.AddListener(OnButtonClick);
            this.pool = new PoolMono<DamageParticle>(_particlePrefab, _poolCount, this.transform);
            this.pool.autoExpand = _autoExpand;
            Game.OnGameInitializeEvent -= OnGameStart;
        }

        private void OnDisable() {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick() {
            CreateParticle();
        }

        private void CreateParticle() {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var particle = this.pool.GetFreeElement();
            particle.transform.position = new Vector3(position.x, position.y, transform.position.z - 1f);
        }
    }
}