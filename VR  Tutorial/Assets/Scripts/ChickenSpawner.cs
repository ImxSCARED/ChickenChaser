using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Assertions;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_chickenPrefab;

    [SerializeField]
    private List<Transform> m_spawnCollections;
    private Dictionary<int, List<Transform>> m_spawnPointDict;

    [SerializeField]
    private int m_chickensToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnPointDict = new Dictionary<int, List<Transform>>();

        // Fill out our spawn point dictionary
        foreach (Transform collection in m_spawnCollections)
        {
            Transform[] spawnPointArray = collection.GetComponentsInChildren<Transform>();

            List<Transform> spawnPoints = new List<Transform>();

            // For some reason, GetComponentsInChildren also returns the parent, at index 1, so we skip that
            for (int i = 1; i < spawnPointArray.Length; i++)
            {
                spawnPoints.Add(spawnPointArray[i]);
            }

            m_spawnPointDict.Add(collection.GetInstanceID(), spawnPoints);
        }


        List<Transform> spawnCols = new List<Transform>(m_spawnCollections);

        // We run through each chicken to spawn, choosing a unique room for each
        for (int i = 0; i < m_chickensToSpawn; i++)
        {
            // If we run out of rooms before we run out of chickens, we just reset the rooms and keep going
            if (spawnCols.Count == 0)
            {
                spawnCols = new List<Transform>(m_spawnCollections);
            }

            int collectionIndex = Random.Range(0, spawnCols.Count);
            int collectionID = spawnCols[collectionIndex].GetInstanceID();
            spawnCols.RemoveAt(collectionIndex);

			if (m_spawnPointDict[collectionID].Count == 0)
			{
				m_spawnCollections.RemoveAt(collectionIndex);
				i--;
				continue;
			}

            int spawnPointIndex = Random.Range(0, m_spawnPointDict[collectionID].Count);

            GameObject chickenInstance = Instantiate(m_chickenPrefab);

            chickenInstance.transform.position = m_spawnPointDict[collectionID][spawnPointIndex].transform.position;
            chickenInstance.transform.rotation = m_spawnPointDict[collectionID][spawnPointIndex].transform.rotation;

            m_spawnPointDict[collectionID].RemoveAt(spawnPointIndex);
        }
    }
}
