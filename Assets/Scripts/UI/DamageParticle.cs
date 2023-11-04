using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Clicker.Architecture {
    public class DamageParticle : MonoBehaviour {
        [SerializeField] private float _lifetime = 1f;
        [SerializeField] private float _scaleMoveble = 0.01f;
        private bool isMove = false;

        private void OnEnable() {
            this.StartCoroutine("LifeRoutine");
            UpdateText();
        }

        private void OnDisable() {
            this.StopCoroutine("LifeRoutine");
        }

        private void FixedUpdate() {
            if (isMove) {
                transform.Translate(0f,-_scaleMoveble,0f);
            }
        }

        private IEnumerator LifeRoutine() {
            isMove = true;
            yield return new WaitForSecondsRealtime(_lifetime);
            this.Deactivate();
        }

        private void UpdateText() {
            gameObject.GetComponentInParent<TMP_Text>().text = Hero.attack.ToString();
        }
        
        private void Deactivate() {
            this.gameObject.SetActive(false);
            isMove = false;
        }
    }
}