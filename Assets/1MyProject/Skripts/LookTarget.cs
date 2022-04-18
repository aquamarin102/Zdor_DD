using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(FindTarget))]

    public class LookTarget : MonoBehaviour
    {
        private FindTarget findTarget;


        [SerializeField] private float rotationSpeed = 5f;

        private void Start()
        {
            findTarget = GetComponent<FindTarget>();
        }

        private void FixedUpdate()
        {
            if (!findTarget.HasTarget)
            {
                return;
            }
            var direction = findTarget.Target.position - transform.position;
            var step = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.fixedDeltaTime, 0f);

            transform.rotation = Quaternion.LookRotation(step);
        }
    }
}