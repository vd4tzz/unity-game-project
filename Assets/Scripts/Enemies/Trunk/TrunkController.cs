using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trunk
{
    public class TrunkController : BaseController
    {   
        #region Set direction for Trunk
        [Header("Direction")]
        [SerializeField] private Facing leftOrRight = Facing.Right;
        #endregion

        #region Detect variables
        [Header("Detect Setting")]
        [SerializeField] private float distanceDetect;
        [SerializeField] private LayerMask playerLayer;
        public bool isDetect = false;
        public bool IsDetect => isDetect;
        #endregion

        #region Attack variables
        [Header("Attack Setting")]
        [SerializeField] private TrunkBullet bullet;
        [SerializeField] private int bulletDamage;
        [SerializeField] private int bulletSpeed;
        [SerializeField] private float timeBetween2Bullet;
        private float timer = 0;
        #endregion

        #region Coin dropped afted death variable
        [Header("Coin Setting")]
        [SerializeField] private Coin coinObj;
        #endregion

        protected override void Awake()
        {
            base.Awake();
        }


        protected override void Start()
        {
            base.Start();
            machine = new TrunkStateMachine(this);
            rb.isKinematic = true;
        }

        protected override void Update()
        {
            base.Update();

        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
        }

        public void DetectPlayer()
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, new Vector2((int)leftOrRight, 0), distanceDetect, playerLayer);
            
            isDetect = ray;
        }

        public void Attack()
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                return;
            }

            timer = timeBetween2Bullet;

            
            TrunkBullet bulletObj = Instantiate(bullet, 
                                    transform.position + new Vector3((int)leftOrRight * 1.3f, 0), // bullet tao ra cach Trunk 1 khoang
                                    Quaternion.identity);
            
            bulletObj.Damage = bulletDamage;
            bulletObj.Speed = bulletSpeed;
            bulletObj?.Attack((int)leftOrRight);
        }

        public void InstantiateCoin()
        {
            Instantiate(coinObj, transform.position, Quaternion.identity);
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, Vector2.right * (int)leftOrRight * distanceDetect);
        }
    }
}

enum Facing 
{
    Right = 1,
    Left = -1,
}
