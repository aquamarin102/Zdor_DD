
using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(FindTarget))]

    public class Shooting : MonoBehaviour
    {
        private FindTarget findTarget;

        [SerializeField] private Transform spawnPoint;
        [SerializeField] private BomdTur BombPrefab;


        private float step = 3f;
        private float nextShot;

        private void Start()
        {
            findTarget = GetComponent<FindTarget>();
        }
        private void Update()
        {
            if (!findTarget.HasTarget) { return; }

            if(!(Time.time > nextShot))
            {
                return;
            }
            
                nextShot = Time.time + step;
           

            Shoot();
        }

        private void Shoot()
        {
            var bomb = Instantiate(BombPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

}
