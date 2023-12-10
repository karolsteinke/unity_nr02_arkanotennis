using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    private Animator _anim;
    //private Rigidbody _body;

    void Start() {
        //_body = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        //set 'movement' - a velocity vector based on user input
        Vector3 movement = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        movement = Vector3.ClampMagnitude(movement, speed);
        transform.position += movement;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -0.55f, 0.55f),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -0.30f, 0.15f)
        );

        //update animator's parameter to match character's state
        float movMagnitude = movement.sqrMagnitude;
        _anim.SetFloat("speed", Mathf.Abs(movMagnitude));

        //face sprite to velocity
        if (!Mathf.Approximately(movMagnitude, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(movement.x),1,1);
        }
    }
}
