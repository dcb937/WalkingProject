using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove2 : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Animator navPlayer;//寻路的人
    private int targetNum;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = navPlayer.GetComponent<UnityEngine.AI.NavMeshAgent>();
        targetNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isStopped == false && agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetFloat("Vertical Speed", 0f);
            agent.isStopped = true;   // 必须要有，不然导航一直不结束
        }

        Vector3 target1 = new Vector3 (-3f, 0f, -12f);
        Vector3 target2 = new Vector3 (-9f, 0f, -42f);

        if(targetNum == 1 && agent.isStopped == true){
            agent.SetDestination(target1);
            animator.SetFloat("Vertical Speed", 1.5f);
            agent.isStopped = false;
            targetNum = 2;
        }
        if(targetNum == 2 && agent.isStopped == true){
            agent.SetDestination(target2);
            animator.SetFloat("Vertical Speed", 1.5f);
            agent.isStopped = false;
            targetNum = 1;
        }
    }
}
