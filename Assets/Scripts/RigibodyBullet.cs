namespace AFSInterview
{
    using UnityEngine;

    public class RigibodyBullet : MonoBehaviour
    {
        private Rigidbody _rigibody;

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<Enemy>();
            if(enemy) {
                Destroy(enemy.gameObject);
            }

            Destroy(gameObject);
        }

        public void Initialize(Vector3 initialVelocity)
        {
            if (_rigibody == null) _rigibody = GetComponent<Rigidbody>();
            _rigibody.velocity = initialVelocity;
        }
    }
}