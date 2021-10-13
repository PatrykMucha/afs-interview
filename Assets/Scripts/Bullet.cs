namespace AFSInterview
{
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;

        private GameObject targetObject;
        private GameObject shooter;
        private Vector3 lastTargetPosition;

        public void Initialize(GameObject target)
        {
            targetObject = target;
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;
            if(targetObject != null)
            {
                direction = (targetObject.transform.position - transform.position).normalized;

                if ((transform.position - targetObject.transform.position).magnitude <= 0.2f)
                {
                    Destroy(gameObject);
                    Destroy(targetObject);
                }

                lastTargetPosition = targetObject.transform.position;
            }
            else
            {
                direction = (lastTargetPosition - transform.position).normalized;

                if ((lastTargetPosition - transform.position).magnitude < 0.1f)
                {
                    Destroy(gameObject);
                }
            }

            transform.position += direction * speed * Time.deltaTime;
        }
    }
}