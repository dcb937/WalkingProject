using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
  // Start is called before the first frame update
  private bool isScaled = false;
  private Vector3 originalPosition;
  private float width;
  private float height;
  private float scaledSize;

  void Start()
  {
    originalPosition = transform.localPosition;
    width = GetComponent<RectTransform>().rect.width;
    height = GetComponent<RectTransform>().rect.height;
    scaledSize = UnityEngine.Screen.width / width > UnityEngine.Screen.height / height ?
        UnityEngine.Screen.height / height :
        UnityEngine.Screen.width / width;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.M))
    {
      Debug.Log("M press down");
      if (isScaled == false)
      {
        transform.localPosition = Vector3.zero;
        transform.localScale = new Vector3(scaledSize, scaledSize);

        isScaled = true;
      }
      else
      {
        transform.localPosition = originalPosition;
        transform.localScale = new Vector3(1, 1);
        isScaled = false;
      }
    }

    if (isScaled == true && Input.GetMouseButton(0))
    {
      // Debug.Log(Input.mousePosition);

    }
  }
}
