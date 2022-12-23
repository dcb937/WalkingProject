using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoMove : MonoBehaviour
{

  private Ray ray;
  private RaycastHit hit;//射线碰到的碰撞信息
  public Animator navPlayer;//寻路的人
  private NavMeshAgent agent;
  public LayerMask myLayer;
  public Camera mapCamera;
  public PlayerMovement scriptPM;
  public LineRenderer lr;//LineRenderer组件
  public Camera camera_main;

  private void Start()
  {
    agent = navPlayer.GetComponent<NavMeshAgent>();
  }

  private void Awake()
  {
    InitLine();
  }

  private void Update()
  {
    UpdateLineRenderer();

    // if (Input.GetKeyDown(KeyCode.C))
    // {
    //   camera_main.enabled = false;
    //   mapCamera.enabled = true;
    // }

    // Debug.Log("Vertical Speed" + navPlayer.GetFloat("Vertical Speed"));
    // Debug.Log("Horizontal Speed" + navPlayer.GetFloat("Horizontal Speed"));

    // if (Input.GetMouseButtonDown(0))
    //   Debug.Log(ray.origin);
    // Debug.Log(agent.stoppingDistance);
    // Debug.Log("remainingDistance: " + agent.remainingDistance + "\nstoppingDistance: " + agent.stoppingDistance);
    if (scriptPM.isNav == true && agent.remainingDistance > agent.stoppingDistance)
    {
      // navPlayer.SetFloat("Vertical Speed", 1.7f);
    }
    if (scriptPM.isNav == true && agent.remainingDistance <= agent.stoppingDistance)
    {
      // navPlayer.SetFloat("Vertical Speed", 0f);
      agent.isStopped = true;   // 必须要有，不然导航一直不结束
      scriptPM.isNav = false;
    }

    //射线起始位置
    ray = mapCamera.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit, 1000, myLayer))
    {
      Debug.DrawLine(ray.origin, hit.transform.position, Color.red);
      if (Input.GetMouseButtonDown(0))
      {
        Debug.Log(hit.point);
        // Vector3 vec = new Vector3(-1.13f, 0, -11.14f);
        // agent.SetDestination(vec);
        // Debug.Log(hit.transform.position);
        // agent.SetDestination(hit.transform.position);
        agent.SetDestination(hit.point);
        scriptPM.isNav = true;
        agent.isStopped = false;    // 得有，不然在第二次点击鼠标时会卡住不动
      }

    }
  }

  private void InitLine()
  {
    lr.startColor = Color.red;
    lr.endColor = Color.red;
    lr.startWidth = 0.1f;
    lr.endWidth = 0.1f;
    lr.numCapVertices = 90;
    lr.numCornerVertices = 90;
    lr.material = new Material(Shader.Find("Sprites/Default"));
  }
  private void UpdateLineRenderer()
  {
    lr.positionCount = agent.path.corners.Length;
    lr.SetPositions(agent.path.corners);
  }
}