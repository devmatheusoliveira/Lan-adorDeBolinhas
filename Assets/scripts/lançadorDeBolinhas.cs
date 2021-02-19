using UnityEngine;
using System.Collections;
public class lançadorDeBolinhas : MonoBehaviour
{
    public Transform eggPrefab;
    public Transform lançador;

    private float nextEggTime = 0.0f;
    private float spawnRate = 1.5f;



    void Update()
    {
        if (nextEggTime < Time.time)
        {
            SpawnEgg();
            nextEggTime = Time.time + spawnRate;

            spawnRate = Mathf.Clamp(spawnRate, 0.3f, 99f);
            
        }
    }

    void SpawnEgg()
    {
        KinectManager manager = KinectManager.Instance;

        if (eggPrefab && manager && manager.IsInitialized() && manager.IsUserDetected())
        {
            uint userId = manager.GetPlayer1ID();
            Vector3 posUser = manager.GetUserPosition(userId);

            Vector3 spawnPos = lançador.position;
            eggPrefab.transform.position = new Vector3(0, 100 * Time.deltaTime, 0);
            Transform eggTransform = Instantiate(eggPrefab, spawnPos, Quaternion.identity) as Transform;
            eggTransform.parent = transform;
        }
    }
}
