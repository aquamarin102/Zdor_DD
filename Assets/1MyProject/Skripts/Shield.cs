using UnityEngine;
namespace Quest
{
    [RequireComponent(typeof(Rigidbody))]
    public class Shield : MonoBehaviour
    {
        [SerializeField] private float speed = 30f;
        [SerializeField] private float damage = 1f;
        [SerializeField] private float ExpPower = 1f;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Health health))
            {
                health.Hit(damage);
            }
            if (collision.gameObject.TryGetComponent(out Rigidbody rig))
            {
                rig.AddForce(transform.up * ExpPower, ForceMode.VelocityChange);
                rig.AddForce(transform.forward * ExpPower, ForceMode.VelocityChange);
            }
            Destroy(gameObject);
        }

    }
}
