using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField]
    private GameObject GroundFog;
    [SerializeField]
    private Transform GenerateTransform;
    [SerializeField]
    private int intervalPosition = 1;
    [SerializeField]
    private float generateFogListCount = 5;
    [SerializeField]
    private List<GameObject> GroundFogs = new List<GameObject>();

    private int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(step = 0; step < generateFogListCount; step++)
        {
            var fog = Instantiate(GroundFog, GenerateTransform);
            fog.transform.position = new Vector3(0, 0, step * intervalPosition);
            GroundFogs.Add(fog);
            fog.GetComponent<GroundFog>().hitNotifier.OnHitPlayer += UpdateFogPositions;
        }
    }


    void UpdateFogPositions()
    {
        var pos = new Vector3(0, 0, step * intervalPosition);
        GroundFogs[(int)(step % generateFogListCount)].transform.position = pos;
        step++;
    }

}
