// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Autohand;

// //this is a temporary code to prevent player sliding on slope, working with Autohand to have a better implementation
// public class DisableSlidingOnSlope : MonoBehaviour
// {
//     [Header("Slope Handling")]
//     public float maxSlopeAngle;
//     private RaycastHit slopeHit;

//     Rigidbody body;
//     AutoHandPlayer player;
//     CapsuleCollider bodyCapsule;

//     private void Start()
//     {
//         body = GetComponent<Rigidbody>();
//         player = GetComponent<AutoHandPlayer>();
//         bodyCapsule = GetComponent<CapsuleCollider>();
//     }

//     private void Update()
//     {
//         Debug.Log(body.useGravity);
//         if (OnSlope() && player.IsGrounded())
//         {
//             body.AddForce(GetSlopeMoveDirection() * player.maxMoveSpeed * 20f, ForceMode.Force);
//             if (body.velocity.y > 0) {body.AddForce(Vector3.down * 80f, ForceMode.Force);}
//             body.useGravity = false;
//             return;
//         }
        
//     }

//     private bool OnSlope()
//     {
//         if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, 0.3f))
//         {
//             float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
//             return angle < maxSlopeAngle && angle != 0;
//         }

//         return false;
//     }

//     private Vector3 GetSlopeMoveDirection()
//     {
//         return Vector3.ProjectOnPlane(body.velocity, slopeHit.normal).normalized;
//     }

// }