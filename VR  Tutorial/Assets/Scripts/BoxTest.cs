using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTest : MonoBehaviour
{
    void Update()
    {
		//Vector3 collisionCheck = new Vector3(0.5f, 0.5f, 0.5f);
        //Debug.Log("CollisionBool: " + Physics.CheckBox(transform.position, collisionCheck,
		//											   Quaternion.identity, Physics.AllLayers, QueryTriggerInteraction.Ignore));
		//Debug.Log("Pos: " + transform.position);
		/*foreach (Collider col in Physics.OverlapBox(transform.position, collisionCheck, Quaternion.identity, 0, QueryTriggerInteraction.Ignore));
		{
			Debug.Log(col.name);
		}*/
    }
	
	void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
		
		Collider col = GetComponent<Collider>();
		Vector3 extents = col.bounds.extents;
        Gizmos.DrawWireCube(col.bounds.center, new Vector3(extents.x * 2, extents.y * 2, extents.z * 2));
    }
}
