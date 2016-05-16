using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerTakedown : MonoBehaviour {

	public float minDistance = 1.5f;
	public int playerNum = 1;

	void Update() {
		if (Input.GetButtonDown("Takedown" + playerNum)) {
			Takedown();
		}
	}

	public void Takedown() {
		PlayerTakedown[] assassins = FindObjectsOfType<PlayerTakedown>();
		foreach (PlayerTakedown ass in assassins) {
			if (ass.playerNum == this.playerNum)
				return;
			if (Vector3.Distance(ass.transform.position, transform.position) < minDistance) {
				//Destroy(ass);
				//ass.GetComponent<Collider>().isTrigger = false;
				print("BHTORHRBNRN");

				ass.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				ass.gameObject.GetComponent<Rigidbody>().useGravity = true;
				ass.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				ass.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, 80));
				Destroy(ass.gameObject.GetComponent<PlayerTakedown>());
				Destroy(ass.gameObject.GetComponent<PlayerMovement>());
				Destroy (ass.gameObject.GetComponent<NPCPresidentAI> ());
				Destroy (ass.gameObject.GetComponent<NavMeshAgent> ());
				gameObject.tag = "Untagged";
				GetComponent<Rigidbody>().AddForce(Vector3.Normalize(ass.transform.position - transform.position) * 35, ForceMode.VelocityChange);

//				NPCCivilian[] civils = FindObjectsOfType<NPCCivilian>();
//				foreach (NPCCivilian npc in civils) {
//					npc.RunAway(ass.transform.position);
//				}
				break;
			}
		}
	}
	
}
