using System.Collections;
using Photon.Pun;
using UnityEngine;

namespace Quest
{
    public class SpawnJuj : MonoBehaviour
    {
        [SerializeField] private float _spawnTime;

        private Vector3 _spawnPosition;

        void Start()
        {

            StartCoroutine(Spawner());

        }

        private IEnumerator Spawner()
        {
            _spawnPosition = new Vector3(Random.Range(-9f, -5f), 0, Random.Range(30f, 35f));
            PhotonNetwork.Instantiate("Juj", _spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
            StartCoroutine(Spawner());
        }
    }
}