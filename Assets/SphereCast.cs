using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public GameObject currentHitObjects;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        origin = transform.position;
        direction = transform.forward;
        /*
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;       
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;

        }*/
        currentHitDistance = maxDistance;
        currentHitObjects.Clear();

        RaycastHit[] hits = new RaycastHit[10];
        int numberOfHits = Physics.SphereCastNonAlloc(origin, sphereRadius, direction, hits, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal);
       
        for (int i = 0; i < numberOfHits; i++)
        {
            currentHitObjects.Add(hits[i].transform.gameObject);
            currentHitDistance = hits[i].distance;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
