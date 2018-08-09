using UnityEngine;
using UnityEngine.UI;

public class Segment : MonoBehaviour
{
    [SerializeField]
    UnitController unitController;
    [SerializeField]
    private Slider healthFirstLayer;
    [SerializeField]
    private Slider shieldFirstLayer;
    [SerializeField]
    public GameObject segmentPrefab;

    public float segmentAmount = 50;
    private int numSegments;

    void Start()
    {
        float sumStat = healthFirstLayer.value + shieldFirstLayer.value;
        numSegments = (int)(sumStat / segmentAmount);

        for (int i = 0; i < numSegments; i++)
        {
            GameObject newSegment = Instantiate(segmentPrefab) as GameObject;
            newSegment.transform.SetParent(transform, false);            
        }       
    }
}
