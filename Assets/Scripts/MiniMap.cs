using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
  // Start is called before the first frame update
  private bool isScaled = false;
  private Rect originalViewportRect;
  private float originalSize;
  void Start()
  {
    originalViewportRect = GetComponent<Camera>().rect;
    originalSize = GetComponent<Camera>().orthographicSize;
    Debug.Log(originalViewportRect);
    Debug.Log(originalSize);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.M))
    {
      Debug.Log("M press down");
      if (isScaled == false)
      {
        GetComponent<Camera>().rect = new Rect(0f, 0f, 1f, 1f);
        GetComponent<Camera>().orthographicSize = 18f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isScaled = true;
      }
      else
      {
        GetComponent<Camera>().rect = originalViewportRect;
        GetComponent<Camera>().orthographicSize = originalSize;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isScaled = false;
      }
    }

    // if (isScaled == true && Input.GetMouseButton(0))
    // {
    //   // Debug.Log(Input.mousePosition);
    // }
  }
}
