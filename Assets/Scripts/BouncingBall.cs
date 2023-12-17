using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private Rigidbody _rb;

    void Start() {
        _rb = GetComponent<Rigidbody>();

        _rb.velocity = new Vector3(1,0,1);
    }

    void FixedUpdate() {

    }

    void OnCollisionEnter(Collision coll) {
        _rb.velocity = Vector3.Reflect(_rb.velocity, coll.contacts[0].normal);
    }
}
