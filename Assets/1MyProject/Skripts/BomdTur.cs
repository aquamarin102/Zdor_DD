using UnityEngine;

namespace Quest
{
    public class BomdTur : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 3;
        [SerializeField] private LayerMask player;
        private void Awake()
        {
            Destroy(gameObject, 3f);
        }
        private void FixedUpdate()
        {
            transform.position += transform.forward * speed * Time.fixedDeltaTime;
        }

       
    }
}
