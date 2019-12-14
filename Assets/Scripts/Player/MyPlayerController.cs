using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorPrototype
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Rigidbody))] // For initial testing, switch and figure stuff out with mesh collider and sci fi soldier later
                                          //[RequireComponent(typeof(MeshCollider))]
    public class MyPlayerController : MonoBehaviour
    {
        new PlayerCamera camera;
        public Rigidbody rb;
        public CapsuleCollider cc;

        Vector3 movement;
        public float moveSpeed;

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

        // Keeps physics constant no matter the framerate
        void FixedUpdate()
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
            //rb.velocity += movement * moveSpeed * Time.deltaTime;
        }
    }
}