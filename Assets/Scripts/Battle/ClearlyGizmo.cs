using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearlyGizmo : MonoBehaviour
{
	//ÉMÉYÉÇå©Ç‚Ç∑Ç≠Ç»ÇÈ
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
