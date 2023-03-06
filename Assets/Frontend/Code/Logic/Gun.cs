using System.Collections;
using UnityEngine;

namespace Frontend
{
    class Gun : MonoBehaviour
    {
        [SerializeField]
        float interval = 0.5f;

        [SerializeField]
        LineRenderer line;

        UnitView _target;
        bool _isShooting;

        public void Init(UnitView target)
        {
            _target = target;
        }

        IEnumerator Start()
        {
            var intervalDelay = new WaitForSeconds(interval);
            var visualDelay = new WaitForSeconds(0.15f);

            while(enabled)
            {
                yield return intervalDelay;

                if(_isShooting)
                {
                    _isShooting = false;
                }
                else
                {
                    _isShooting = true;

                    if (_target)
                    {
                        yield return visualDelay;
                        _target.Damage();
                    }
                }
            }
        }

        void Update()
        {
            if(_isShooting && _target)
            {
                line.positionCount = 2;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, _target.Render.transform.position);
            }
            else
            {
                line.positionCount = 0;
            }
        }
    }
}