using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    private Animator _anim;

    void Start() {
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
        
        //set new clamped position based on movement vector
        transform.position += movement;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -0.55f, 0.55f),
            transform.position.y,
            Mathf.Clamp(transform.position.z, -0.30f, 0.15f)
        );

        //update animator's parameter to match character's state
        _anim.SetFloat("speed", Mathf.Abs(movement.sqrMagnitude));

        //face sprite to velocity vector
        float movX = movement.x;
        if (!Mathf.Approximately(movX, 0)) {
            transform.localScale = new Vector3(Mathf.Sign(movX),1,1);
        }
    }
}
