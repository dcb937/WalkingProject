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

  private void Start()
  {
    agent = navPlayer.GetComponent<NavMeshAgent>();
  }

  private void Update()
  {
    // Debug.Log("Vertical Speed" + navPlayer.GetFloat("Vertical Speed"));
    // Debug.Log("Horizontal Speed" + navPlayer.GetFloat("Horizontal Speed"));

    //射线起始位置
    ray = mapCamera.ScreenPointToRay(Input.mousePosition);
    // if (Input.GetMouseButtonDown(0))
    //   Debug.Log(ray.origin);
    // Debug.Log(agent.stoppingDistance);
    // Debug.Log("remainingDistance: " + agent.remainingDistance + "\nstoppingDistance: " + agent.stoppingDistance);
    if (scriptPM.isNav == true && agent.remainingDistance > agent.stoppingDistance)
    {
      navPlayer.SetFloat("Vertical Speed", 1.7f);
    }
    if (scriptPM.isNav == true && agent.remainingDistance <= agent.stoppingDistance)
    {
      navPlayer.SetFloat("Vertical Speed", 0f);
      agent.isStopped = true;   // 必须要有，不然导航一直不结束
      scriptPM.isNav = false;
    }

    if (Physics.Raycast(ray, out hit, 10000))
    {
      Debug.DrawLine(ray.origin, hit.transform.position, Color.red);
      if (Input.GetMouseButtonDown(0))
      {
        agent.SetDestination(hit.transform.position);
        scriptPM.isNav = true;
      }

    }
  }
}