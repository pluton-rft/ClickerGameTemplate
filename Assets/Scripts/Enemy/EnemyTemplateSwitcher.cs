using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Architecture {
    public class EnemyTemplateSwitcher : MonoBehaviour {

        [SerializeField] private EnemyListPresent enemyListPresent;
        private List<EnemyTemplate> _allTemplates; 
        private List<EnemyTemplate> _newBufferTemplates;
        private List<EnemyTemplate> _bufferTemplates;
        private EnemyTemplate _currentTemplate;
        private int _currentLevel;
        private int _maxLevel;

        private void Awake() {
            Game.OnGameInitializeEvent += Initialize;
            EnemyInteractor.EnemyKilled += OnEnemyKilledEvent;
            Level.OnLevelChangeLevelEvent += OnLevelChanges;
        }

        private void Initialize() {
            LoadEnemyTemplates();
            CheckMaxLevelInRangeList();
            FindPreviousAvailableTemplate();
            TryOverwriteLastBuffer();
            OnEnemyKilledEvent();
            Game.OnGameInitializeEvent -= Initialize;
        }

        private void OnDisable() {
            EnemyInteractor.EnemyKilled -= OnEnemyKilledEvent;
            Level.OnLevelChangeLevelEvent -= OnLevelChanges;
        }

        private void OnLevelChanges() {
            UpdateCurrentLevel();
            AddTemplatesToBuffer();
            TryOverwriteLastBuffer();
        }

        private void OnEnemyKilledEvent() {
            SetRandomTemplateFromBuffer();
            ExportCurrentTemplate();
        }

        private void FindPreviousAvailableTemplate() { 
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
        
        private void FindNextAvailableTemplate() { 
            bool isFound = false;
            UpdateCurrentLevel();
            do {
                AddTemplatesToBuffer();
                isFound = !BufferEmptyCheck();
                _currentLevel++;
                Debug.Log($"isFound: ({isFound}, level: ({_currentLevel}))");   
            } while (isFound == false && _currentLevel <= _maxLevel);
        }

        private void AddTemplatesToBuffer() {
            _newBufferTemplates = new List<EnemyTemplate>();
            foreach (var preset in _allTemplates) {
                if (preset.level == _currentLevel) _newBufferTemplates.Add(preset);
                if (preset.level == _maxLevel && _currentLevel > _maxLevel) _newBufferTemplates.Add(preset);
            }
        }

        private void UpdateCurrentLevel() {
            _currentLevel = Level.level;
        }

        private void TryOverwriteLastBuffer() {
            if (BufferEmptyCheck() == false) _bufferTemplates = new List<EnemyTemplate>(_newBufferTemplates);
        }

        private bool BufferEmptyCheck() {
            bool bufferEmpty = !(_newBufferTemplates.Count >= 1);
            return bufferEmpty;
        }

        private void SetRandomTemplateFromBuffer() {
            int numEnemy = Random.Range(0, _bufferTemplates.Count);
            _currentTemplate = _bufferTemplates[numEnemy];
        }

        private void ExportCurrentTemplate() {
            Enemy.SetTemplate(this, _currentTemplate);
        }

        private void CheckMaxLevelInRangeList() {
            foreach (var preset in _allTemplates) {
                if (preset.level > _maxLevel) {
                    _maxLevel = preset.level;
                }
            }
        }

        private void LoadEnemyTemplates() {
            _allTemplates = new List<EnemyTemplate>(enemyListPresent.GetTemplates());
        }
    }
}