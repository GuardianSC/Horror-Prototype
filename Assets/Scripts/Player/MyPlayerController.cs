using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
                                          
    public class MyPlayerController : MonoBehaviour
    {
        new PlayerCamera camera;
        public Rigidbody rb;
        public CapsuleCollider cc;

        Vector3 movement;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private bool isGrounded; // Serialized just to easily see if it's working

        // Start is called before the first frame update
        void Start()
        {
            camera = Camera.main.GetComponent<PlayerCamera>();
            rb = GetComponent<Rigidbody>();
            cc = GetComponent<CapsuleCollider>();

        }
        
        // Update is called once per frame
        void Update()
        {
            float h = Input.GetAxisRaw("Horizontal") * moveSpeed;
            float v = Input.GetAxisRaw("Vertical") * moveSpeed;

            movement = new Vector3(h, 0, v);
            movement = transform.TransformDirection(movement);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera.yRotation, transform.localEulerAngles.z); // Rotate player in camera horizontal direction
        }

        void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Landable")
                isGrounded = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            isGrounded = false;
        }

        // Keeps physics constant no matter the framerate
        void FixedUpdate()
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);

            //RaycastHit hit;
            //float rayDistance = 1.5f;
            //Debug.DrawRay(transform.position, Vector3.down, Color.red);

            //if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
            //{
            //    if (hit.transform.tag == "Landable")
            //        isGrounded = true;
            //    else if (hit.transform.tag != "Landable" || hit.transform.tag == null)
            //        isGrounded = false;
            //}

            if (isGrounded && Input.GetButton("Jump"))
            {
                rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            }

        }
    }
}