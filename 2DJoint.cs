using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2DJoint : MonoBehaviour
{
    public Transform hand1, hand2;
    public Transform target;
    float rotz , handLength;
    float distance;
    public bool negativeDirection;
    int a;

    private void Start()
    {
        handLength = Vector3.Distance(hand1.position, hand2.position);
        target.parent = null;
    }
    void Update()
    {
        if (negativeDirection)
        {
            a = -1;
        }
        else
        {
            a = 1;
        }
        distance = Vector3.Distance(transform.position, target.position);
        distance = Mathf.Clamp(distance,0, handLength*2);

        Vector3 dif = target.position - transform.position;
        dif.Normalize();
        rotz = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0, rotz);

        hand1.rotation = Quaternion.Euler(0, 0, rotz + Mathf.Acos((distance / 2) / handLength) * Mathf.Rad2Deg *a);
        hand2.rotation = Quaternion.Euler(0, 0, rotz + -Mathf.Acos((distance / 2) / handLength) * Mathf.Rad2Deg*a);
    }

}
