using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Architecture {
    public class EnemyTemplateSwitcher : MonoBehaviour {

        [SerializeField] public EnemyListPresent enemyListPresent;
        public List<EnemyTemplate> _allTemplates; 
        public List<EnemyTemplate> _newBufferTemplates;
        public List<EnemyTemplate> _bufferTemplates;
        public EnemyTemplate _currentTemplate;
        public int _currentLevel;
        public int _maxLevel;

        private void Awake() {
            Game.OnGameInitializeEvent += Initialize;
            EnemyInteractor.EnemyKilled += OnEnemyKilledEvent;
            Level.OnLevelChangeLevelEvent += OnLevelChanges;
        }

        private void OnDisable() {
            EnemyInteractor.EnemyKilled -= OnEnemyKilledEvent;
            Level.OnLevelChangeLevelEvent -= OnLevelChanges;
        }

        public void Initialize() {
            LoadEnemyTemplates();
            CheckMaxLevelInRangeList();
            FindPreviousAvailableTemplate();
            TryOverwriteLastBuffer();
            OnEnemyKilledEvent();
            Game.OnGameInitializeEvent -= Initialize;
        }

        private void OnLevelChanges() {
            UpdateCurrentLevel();
            AddTemplatesToBuffer();
            TryOverwriteLastBuffer();
        }

        public void OnEnemyKilledEvent() {
            SetRandomTemplateFromBuffer();
            ExportCurrentTemplate();
        }

        public void FindPreviousAvailableTemplate() { 
            bool isFound = false;
            UpdateCurrentLevel();
            do {
                AddTemplatesToBuffer();
                isFound = !BufferEmptyCheck();
                _currentLevel--;
                Debug.Log($"isFound: ({isFound}, level: ({_currentLevel}))");   
            } while (isFound == false && _currentLevel >= 0);

            if (isFound == false) {
                FindNextAvailableTemplate();
            }
        }
        
        public void FindNextAvailableTemplate() { 
            bool isFound = false;
            UpdateCurrentLevel();
            do {
                AddTemplatesToBuffer();
                isFound = !BufferEmptyCheck();
                _currentLevel++;
                Debug.Log($"isFound: ({isFound}, level: ({_currentLevel}))");   
            } while (isFound == false && _currentLevel <= _maxLevel);
        }

        public void AddTemplatesToBuffer() {
            if (_newBufferTemplates != null) _newBufferTemplates.Clear();
            foreach (var preset in _allTemplates) {
                if (preset.level == _currentLevel) _newBufferTemplates.Add(preset);
                if (preset.level == _maxLevel && _currentLevel > _maxLevel) _newBufferTemplates.Add(preset);
            }
        }

        public void UpdateCurrentLevel() {
            _currentLevel = Level.level;
        }

        public void TryOverwriteLastBuffer() {
            if (BufferEmptyCheck() == false) _bufferTemplates = new List<EnemyTemplate>(_newBufferTemplates);
        }

        public bool BufferEmptyCheck() {
            bool bufferEmpty = !(_newBufferTemplates.Count >= 1);
            return bufferEmpty;
        }

        public void SetRandomTemplateFromBuffer() {
            int numEnemy = Random.Range(0, _bufferTemplates.Count);
            _currentTemplate = _bufferTemplates[numEnemy];
        }

        public void ExportCurrentTemplate() {
            Enemy.SetTemplate(this, _currentTemplate);
        }

        public void CheckMaxLevelInRangeList() {
            foreach (var preset in _allTemplates) {
                if (preset.level > _maxLevel) {
                    _maxLevel = preset.level;
                }
            }
        }

        public void LoadEnemyTemplates() {
            _allTemplates = new List<EnemyTemplate>(enemyListPresent.GetTemplates());
        }
    }
}