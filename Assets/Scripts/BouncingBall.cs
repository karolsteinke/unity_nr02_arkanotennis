using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    //[SerializeField] private float speed = 0.01f;
    private Vector3 movement = Vector3.ClampMagnitude(new Vector3(1,0,1),0.01f);

    void Start() {
        
    }

    void FixedUpdate() {
        transform.position += movement;

        if (transform.position.x > 0.56f)       movement.x = Mathf.Abs(movement.x) * (-1);
        else if (transform.position.x < -0.56f) movement.x = Mathf.Abs(movement.x);

        if (transform.position.z > 1.84f)       movement.z = Mathf.Abs(movement.z) * (-1);
        else if (transform.position.z < 0)      movement.z = Mathf.Abs(movement.z);
    }
}
