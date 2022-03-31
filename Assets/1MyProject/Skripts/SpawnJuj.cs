using System.Collections;
using UnityEngine;

namespace Quest
{
    public class SpawnJuj : MonoBehaviour
    {
        [SerializeField] private float _spawnTime;
        [SerializeField] private GameObject _prefab;

        private Vector3 _spawnPosition;

        void Start()
        {

            StartCoroutine(Spawner());

        }

        private IEnumerator Spawner()
        {
            _spawnPosition = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
            _prefab.transform.position = _spawnPosition;
            Instantiate(_prefab);
            yield return new WaitForSeconds(_spawnTime);
            StartCoroutine(Spawner());
        }
    }
}