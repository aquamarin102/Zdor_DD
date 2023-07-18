using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class BomdTur : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 3;
        [SerializeField] private float ExpPower = 1f;
        private Rigidbody rb;
        private AudioSource boom;
        
        private void Start()
        {
            boom = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            boom.Play();
            if(collision.gameObject.TryGetComponent(out PlayerController health))
            {
                health.Hit(damage);
            }
            if(collision.gameObject.TryGetComponent(out Health healthEnemy))
            {
                healthEnemy.Hit(damage);
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
