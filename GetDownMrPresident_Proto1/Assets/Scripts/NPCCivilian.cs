﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NPCCivilian : NPC {

	NavMeshAgent agent;
	Animator animator;
	bool inCrowd;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		setInCrowd();
		StartCoroutine(Run());
	}

	void Update() {
		animator.SetFloat("Speed", agent.velocity.magnitude);
	}

	public void setInCrowd() {
		float rand = Random.Range(1f, 10f);
		if (rand < 5)
		{
			inCrowd = true;
		}
		else
		{
			inCrowd = false;
		}

	}
	public void MoveRandom() {
		setInCrowd();
		agent.SetDestination(new Vector3(Random.Range(-13f, 13f), 0, Random.Range(-13f, 13f)));
	}

	public void GoToCrowd() {
		setInCrowd();
		GameObject p = GameObject.Find("Podium");
		Vector3 pod = p.transform.position;
		float randx = Random.Range(-2f, 5f);
		float randz = Random.Range(-5f, 5f);
		agent.transform.LookAt(new Vector3(pod.x + randx, 0, pod.z + randz));
		agent.SetDestination(new Vector3(pod.x + randx, 0, pod.z + randz));

	}

	public void RunAway(Vector3 origin) {
		StopCoroutine(Run());
		agent.SetDestination((transform.position - origin) * 100);

	}

	IEnumerator Run() {
		while (true) {
			if (inCrowd)
			{
				MoveRandom();
			}
			else
			{
				GoToCrowd();
			}
			if (inCrowd)
			{
				while (agent.velocity.magnitude > 0)
					yield return null;
				yield return new WaitForSeconds(Random.Range(10f, 60f));
			}
			else
			{
				while (agent.velocity.magnitude > 0)
					yield return null;
				yield return new WaitForSeconds(Random.Range(5f, 10f));
			}

		}
	}

}
