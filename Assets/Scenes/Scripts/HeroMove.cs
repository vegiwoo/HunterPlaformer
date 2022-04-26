using UnityEngine;

namespace HunterPlaformer {

    public class HeroMove : MonoBehaviour
    {
        private Rigidbody heroRigidbody;

        [Tooltip("Скорость персонажа"), Range(1f,3f)]
        public float moveSpeed;
        [Tooltip("Скорость прыжка персонажа"), Range(1.0f, 5.0f)]
        public float jumpSpeed;
        [Tooltip("Трение объекта"), Range(0.1f, 0.5f)]
        public float friction;
        public bool isGrounded;

        private void Awake() {
            heroRigidbody = GetComponent<Rigidbody>();
        }

        private void Start() {
            moveSpeed = 1.5f;
            jumpSpeed = 1.0f;
            friction = 0.1f;
        }

        private void FixedUpdate() {

            float movingX = Input.GetAxis("Horizontal") * moveSpeed;
            heroRigidbody.AddForce(movingX, 0, 0, ForceMode.VelocityChange);

            // Ручная настройка Drag по одной оси
            heroRigidbody.AddForce(-heroRigidbody.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
        }
    }
}