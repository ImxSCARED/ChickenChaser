using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Assertions;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_chickenPrefab;

    [SerializeField]
    private GameObject m_spawnPointParent;
    private List<Transform> m_spawnPoints;

    [SerializeField]
    private int m_chickensToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        // Get m_spawnPointParent's children
        Transform[] spawnPointArray = m_spawnPointParent.GetComponentsInChildren<Transform>();

        m_spawnPoints = new List<Transform>();

        // For some reason, GetComponentsInChildren also returns the parent, at index 1, so we skip that
        for (int i = 1; i < spawnPointArray.Length; i++)
        {
            m_spawnPoints.Add(spawnPointArray[i]);
        }

        Debug.Assert(m_chickensToSpawn <= m_spawnPoints.Count);

        for (int i = 0; i < m_chickensToSpawn; i++)
        {
            int spawnPointIndex = Random.Range(0, m_spawnPoints.Count);

            GameObject chickenInstance = Instantiate(m_chickenPrefab);

            chickenInstance.transform.position = m_spawnPoints[spawnPointIndex].transform.position;
            chickenInstance.transform.rotation = m_spawnPoints[spawnPointIndex].transform.rotation;

            m_spawnPoints.RemoveAt(spawnPointIndex);
        }
    }
}
