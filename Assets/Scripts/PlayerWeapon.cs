using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

namespace GameCore
{
    namespace PlayerController
    {
        public class PlayerWeapon : MonoBehaviour
        {
            protected Animator anim;

            [SerializeField]
            private GameObject bulletPrefab;
            [SerializeField]
            private Transform bulletSpawn;
            [SerializeField]
            public float bulletSpeed = 30;
            [SerializeField]
            public float lifeTime = 3;
            void Update()
            {
                if(Btn_fire)
                {
                    Fire();
                }
            }

            private void Fire()
            {
                GameObject bullet = Instantiate(bulletPrefab);
                Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

                bullet.transform.position = bulletSpawn.position;

                var rot = bullet.transform.rotation.eulerAngles;

                bullet.transform.rotation = Quaternion.Euler(rot.x, transform.eulerAngles.y, rot.z);

                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

                StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
                Debug.Log("->");
            }
            private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
            {
                yield return new WaitForSeconds(delay);

                Destroy(bullet);
            }

            protected bool Btn_fire
            {
                get
                {
                    return ControlSystem.Btn_fire;
                }
            }
        }

    }
}
