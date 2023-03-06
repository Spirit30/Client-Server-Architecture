using System;
using System.Collections.Generic;
using UnityEngine;

namespace Frontend
{
    class UnitView : MonoBehaviour
    {
        int _life;
        List<HexTileView> _path;
        int _targetTileIndex;

        [SerializeField]
        MeshRenderer render;
        public MeshRenderer Render => render;

        [SerializeField]
        Gun gun;
        public Gun Gun => gun;

        Action<int> _onUpdateLife;

        public void Init(int life, List<HexTileView> path, Action<int> onUpdateLife)
        {
            _life = life;
            _path = path;
            _onUpdateLife = onUpdateLife;
            transform.position = path[_targetTileIndex].transform.position;
            OnUpdateLife();
        }

        public void Damage()
        {
            --_life;
            OnUpdateLife();

            if (_life <= 0)
            {
                Destroy(gameObject);
            }
        }

        void Update()
        {
            if (_targetTileIndex >= _path.Count)
            {
                return;
            }

            var targetTilePosition = _path[_targetTileIndex].transform.position;

            if (Vector3.Distance(transform.position, targetTilePosition) > 0.1f)
            {
                var direction = (targetTilePosition - transform.position).normalized;
                transform.position += direction * Time.deltaTime;
            }
            else
            {
                ++_targetTileIndex;
            }
        }

        void OnUpdateLife()
        {
            _onUpdateLife(_life);
        }
    }
}