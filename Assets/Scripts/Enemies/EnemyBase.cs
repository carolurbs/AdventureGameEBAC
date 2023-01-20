using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
public class EnemyBase : MonoBehaviour
{
        public float startLife=10f;
        public float _currentLife;
        private void Awake()
        {
         Init();
        }
        protected void ResetLife()
        {
            _currentLife = startLife;

        }
        protected virtual void Init()
        {
            ResetLife();
        }
        protected virtual void Kill()

        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            Destroy(gameObject);

        }

        public void OnDamage(float f)
        {
            _currentLife = -f;
            if(_currentLife<=0)
            {
                Kill();
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
                Debug.Log(_currentLife);
            }
        }
    }

}

