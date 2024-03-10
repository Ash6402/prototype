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
    private readonly int _walk = Animator.StringToHash("isWalking");
    private readonly int _run = Animator.StringToHash("isRunning");

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
        // var walk = _moveAction.ReadValue<Vector2>().y;
        // var run = _runAction.ReadValue<float>();
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
}
