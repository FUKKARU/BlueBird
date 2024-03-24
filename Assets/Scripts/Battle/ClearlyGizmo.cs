using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearlyGizmo : MonoBehaviour
{
	//ギズモ見やすくなる
	[SerializeField]
	private float gizmoSize = 0.3f;
	[SerializeField]
	private Color gizmoColor = Color.yellow;

	void OnDrawGizmos()
	{
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere(transform.position, gizmoSize);
	}

}
