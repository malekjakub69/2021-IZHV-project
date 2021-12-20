using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField]
        private float MoveSpeed = 5f;
        InputManager inputManager;
        float XValue = 0;


        public void Awake()
        {
            inputManager = new InputManager();
            inputManager.Enable();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void OnEnable()
        {
            inputManager.Player.Move.performed += (context) => ChangeDirectionValue(context.ReadValue<float>());
        }

        public void MovePlayer()
        {
            float XPosition = Mathf.Clamp(transform.position.x + XValue * MoveSpeed * Time.fixedDeltaTime, -80, 80);
            transform.position = new Vector3(XPosition, 0, 0);
        }

        void ChangeDirectionValue(float value)
        {
            XValue = value;
        }

        void OnDisable()
        {
            inputManager.Player.Move.performed -= (context) => ChangeDirectionValue(context.ReadValue<int>());
        }
    }
}
