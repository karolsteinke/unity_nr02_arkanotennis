using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Rigidbody _rb;

    void Start() {
        _rb = GetComponent<Rigidbody>();

        _rb.velocity = new Vector3(.5f, 0, .5f);
    }

    void FixedUpdate() {
        
    }

    void OnTriggerEnter(Collider collider) {
        //find collision point on collider and reflect velocity off the plane defined by a normal
        Vector3 collisionPoint = collider.ClosestPoint(transform.position);
        Vector3 collisionNormal = (transform.position - collisionPoint).normalized;
        _rb.velocity = Vector3.Reflect(_rb.velocity, collisionNormal);
    }
}
