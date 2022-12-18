using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  Animator animator;
  public float forwardSpeed = 1.9f;
  public float backwardSpeed = 1.9f;
  public float leftSpeed = 1.9f;
  public float rightSpeed = 1.9f;
  float targetVerticalSpeed;
  float currentVerticalSpeed;
  float targetHorizontalSpeed;
  float currentHorizontalSpeed;
  Vector3 movement;
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    move();
  }

  void move()
  {
    // 采用插值来使得人物速度变化更加均匀
    currentVerticalSpeed = Mathf.Lerp(currentVerticalSpeed, targetVerticalSpeed, 0.1f);
    // 由于这里人物动作是root motion动画，自带位移，故不再使用transform
    // movement = new Vector3(0, 0, currentSpeed * Time.deltaTime);
    // transform.position += movement;
    // 通过设置2D blend tree的参数值来实现unity人物动画的混合
    animator.SetFloat("Vertical Speed", currentVerticalSpeed);

    currentHorizontalSpeed = Mathf.Lerp(currentHorizontalSpeed, targetHorizontalSpeed, 0.1f);
    animator.SetFloat("Horizontal Speed", currentHorizontalSpeed);
  }

  public void PlayerMove(InputAction.CallbackContext callbackContext)
  {
    // unity 新输入系统
    Vector2 movement = callbackContext.ReadValue<Vector2>();
    targetVerticalSpeed = movement.y > 0 ? forwardSpeed * movement.y : backwardSpeed * movement.y;
    targetHorizontalSpeed = movement.x > 0 ? rightSpeed * movement.x : leftSpeed * movement.x;
  }
}
