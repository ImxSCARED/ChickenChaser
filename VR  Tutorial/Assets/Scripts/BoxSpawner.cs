using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
	[SerializeField]
    private GameObject[] m_boxPrefabs;
	
	[SerializeField]
    private List<BoxCollider> m_boxSpawnAreas;
	
	[SerializeField]
    private int m_boxesToSpawn;
	
    void Start()
    {
		List<BoxCollider> spawnAreas = new List<BoxCollider>(m_boxSpawnAreas);
		
		for (int i = 0; i < m_boxesToSpawn; i++)
        {
            if (spawnAreas.Count == 0)
            {
                spawnAreas = new List<BoxCollider>(m_boxSpawnAreas);
            }
			
			// Choose our spawn area randomly
            int areaIndex = Random.Range(0, spawnAreas.Count);
			BoxCollider bsArea = spawnAreas[areaIndex];
			spawnAreas.RemoveAt(areaIndex);
			
			float spawnX = Random.Range(bsArea.transform.position.x - bsArea.bounds.extents.x,
										bsArea.transform.position.x + bsArea.bounds.extents.x);
			float spawnZ = Random.Range(bsArea.transform.position.z - bsArea.bounds.extents.z,
										bsArea.transform.position.z + bsArea.bounds.extents.z);

			Vector3 spawnVec = new Vector3(spawnX, bsArea.transform.position.y, spawnZ);
			
			// Choose our box type randomly
			int boxIndex = Random.Range(0, m_boxPrefabs.Length);
			
			Collider boxCol = m_boxPrefabs[boxIndex].GetComponent<Collider>();
			Vector3 collisionCheck = new Vector3(boxCol.bounds.extents.x, boxCol.bounds.extents.y, boxCol.bounds.extents.z);
			
			float boxRotX = Random.Range(0, 360);
			float boxRotY = Random.Range(0, 360);
			
			// For some reason, this collision check refuses to work, but it's worth a shot
			if (!Physics.CheckBox(spawnVec, collisionCheck, Quaternion.Euler(boxRotX, boxRotY, 0),
								  Physics.AllLayers, QueryTriggerInteraction.Ignore))
			{
				GameObject boxInstance = Instantiate(m_boxPrefabs[boxIndex]);
				boxInstance.transform.localScale = m_boxPrefabs[boxIndex].transform.localScale;

				boxInstance.transform.position = spawnVec;
				
				boxInstance.transform.rotation = Quaternion.Euler(boxRotX, boxRotY, 0);
			}
        }
    }
}
