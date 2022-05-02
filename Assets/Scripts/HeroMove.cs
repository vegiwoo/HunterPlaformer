using UnityEngine;

namespace HunterPlaformer {

    public enum DirectionOfView { Forward, Backward };

    public class HeroMove : MonoBehaviour
    {
        private Rigidbody heroRigidbody;
        private Transform heroColliderTransform;

        [Tooltip("Скорость персонажа"), Range(1f, 5f)]
        public float moveSpeed;
        private float maxMoveSpeed;

        [Tooltip("Силы прыжка персонажа"), Range(5.0f, 15.0f)]
        public float jumpPower;
        [Tooltip("Трение объекта"), Range(0.1f, 1.0f)]
        public float friction;
        private bool isGrounded;

        private float squatRatio = 15f;

        private DirectionOfView directionOfView = DirectionOfView.Backward;

        private void Awake() {
            heroRigidbody = GetComponent<Rigidbody>();
            heroColliderTransform = GetComponentInChildren<CapsuleCollider>().gameObject.transform;
        }

        private void Start() {
            moveSpeed = 2.5f;
            maxMoveSpeed = 8.0f;
            jumpPower = 12.0f;
            friction = 0.6f;
        }

        private void Update()
        {
            Jumping();
            Squat();
        }

        private void FixedUpdate() {
            Moving();
        }

        private void OnCollisionStay(Collision collision) {
            float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
            if (angle < 45) 
               isGrounded = true;
        }

        private void OnCollisionExit(Collision collision) {
            isGrounded = false;
        }

        private void Moving()
        {
            float movingX = Input.GetAxis("Horizontal");
            float speedMultiplier = 1f;

            if (!isGrounded)
            {
               speedMultiplier = 0.3f;

                if ((heroRigidbody.velocity.x > maxMoveSpeed && movingX > 0) ||
                    heroRigidbody.velocity.x < -maxMoveSpeed && movingX < 0) {
                    speedMultiplier = 0f;
                }
            }

            heroRigidbody.AddForce(movingX * moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
            
            // Ручная настройка Drag по одной оси
            heroRigidbody.AddForce(isGrounded ? -heroRigidbody.velocity.x * friction : -heroRigidbody.velocity.x * friction / 3, 0, 0, ForceMode.VelocityChange);
        }

        private void Jumping()
        {
            if (Input.GetKeyDown(KeyCode.Space) & isGrounded)
            {
                heroRigidbody.AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
            }
        }

        private void Squat()
        {
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !isGrounded)
            {
                heroColliderTransform.localScale = Vector3.Lerp(heroColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * squatRatio);
            }
            else
            {
                heroColliderTransform.localScale = Vector3.Lerp(heroColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * squatRatio);
            }
        }
    }
}