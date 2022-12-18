using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
  public Transform player;
  private float mouseX, mouseY; //获取鼠标移动的值
  public float mouseSensitivity; //鼠标灵敏度
  public float xRotation;

  private void Start()
  {

  }

  private void Update()
  {
    mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
    mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;

    xRotation -= mouseY;
    xRotation = Mathf.Clamp(xRotation, -70f, 70f);

    player.Rotate(Vector3.up * mouseX);
    transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

  }
}
