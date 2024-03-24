using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationStateController : MonoBehaviour
{
    CharacterControls controls;
    public Animator animator;
    private InputAction _moveAction;
    private InputAction _runAction;
    // private readonly int _walk = Animator.StringToHash("isWalking");
    // private readonly int _run = Animator.StringToHash("isRunning");

    private readonly int _x = Animator.StringToHash("Velocity X");
    private readonly int _z = Animator.StringToHash("Velocity Z");
    private float _xVelocity;
    private float _zVelocity;
    private void OnEnable()
    {
        controls = new CharacterControls();
        _moveAction = controls.Player.Move;
        _runAction = controls.Player.Run;
        _moveAction.Enable();
        _runAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _runAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var moveDirection = _moveAction.ReadValue<Vector2>();
        var run = _runAction.ReadValue<float>().Equals(1);
        
        _controlAnimation(moveDirection, run);
        
        // if(walk.Equals(1) && run.Equals(1)){
        //     animator.SetBool(_run, true);
        // }else if(walk.Equals(1) && !run.Equals(1))
        // {
        //     animator.SetBool(_walk, true);
        //     animator.SetBool(_run, false);
        // }
        // else
        // {
        //     animator.SetBool(_run, false);
        //     animator.SetBool(_walk, false);
        // }
    }

    private void _controlAnimation(Vector2 moveDirection, bool isRunning)
    {
        var x = moveDirection.x;
        var z = moveDirection.y;
        
        // on double direction input (e.g. w + a, w + d ...) x doesn't reach 1 or -1 so I am forcing it or the animations are slow.
        x = x > 0 ? 1 : x;
        x = x < 0 ? -1 : x;
        z = z > 0 ? 1 : z;
        z = z < 0 ? -1 : z;
        
        var currentX = animator.GetFloat(_x);
        var currentZ = animator.GetFloat(_z);
        var upperBound = isRunning ? 2 : 0.5f;
        animator.SetFloat(_x, Mathf.SmoothDamp(currentX, (upperBound * x), ref _xVelocity, 1.5f * Time.deltaTime));
        animator.SetFloat(_z, Mathf.SmoothDamp(currentZ, (upperBound * z), ref _zVelocity, 1.5f * Time.deltaTime));
    }
}
