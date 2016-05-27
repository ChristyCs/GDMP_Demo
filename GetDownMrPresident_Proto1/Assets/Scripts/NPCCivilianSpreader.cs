using UnityEngine;
using System.Collections;

public class NPCCivilianSpreader : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;
    bool inCrowd;

    Vector3 civPosition;
    int idleCounter = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        civPosition = agent.transform.position;

        StartCoroutine(Run());
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        if (Mathf.Abs(civPosition.magnitude - agent.transform.position.magnitude) < 2)
        {
            idleCounter++;
            if (idleCounter > 250)
            {
                MoveRandom();
            }
        }else
        {
            idleCounter = 0;
        }


    }

    
    public void MoveRandom()
    {
        if(transform.position.x < 0)
        {
            agent.SetDestination(new Vector3(Random.Range(-13f,-3f), 0, Random.Range(-13f, 13f)));
        }
        else
        {
           agent.SetDestination(new Vector3(Random.Range(3f, 13f), 0, Random.Range(-13f, 13f)));
        }
       
    }

    public void GoToCrowd()
    {
       
        GameObject p = GameObject.Find("TempStage");
        Vector3 pod = p.transform.position;
        float randx = Random.Range(-5f, 5f);
        float randz = Random.Range(-5f, 5f);
        agent.transform.LookAt(new Vector3(pod.x + randx, 0, pod.z + randz));
        agent.SetDestination(new Vector3(pod.x + randx, 0, pod.z + randz));

    }

    public void RunAway(Vector3 origin)
    {
        StopCoroutine(Run());
        agent.SetDestination((transform.position - origin) * 100);

    }

    IEnumerator Run()
    {
        while (true)
        {
            MoveRandom();
            
            while (agent.velocity.magnitude > 0)
                yield return null;
            yield return new WaitForSeconds(1);

        }
    }

}
