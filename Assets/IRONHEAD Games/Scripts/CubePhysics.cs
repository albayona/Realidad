using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePhysics : MonoBehaviour
{
    public float magnitude;
    public float timePeriod;
    public float timeSinceStart;
    public float movementSpeed;
    public Vector3 pivot;
    public int wave = 0;
    private void Start()
    {
        pivot = transform.localPosition;
        timeSinceStart = (3 * timePeriod) / 4;
        wave = Random.Range(0, 2);
     magnitude = 0.5f;
     timePeriod = 1.1f;
     movementSpeed = 4f;

}
    void Update()
    {

        Vector3 nextPos = transform.localPosition;

        bool isBig = tag == "Big";
        if (isBig)
        {

            float factor =  0.1f  * ((float)Random.Range(0, 1));
            float factor2 =  0.1f  * ((float)Random.Range(0, 1));
           float factor3 =  0.1f  * ((float)Random.Range(0, 1));
            magnitude = magnitude * (1 + factor2);

           movementSpeed = movementSpeed * (1 + factor);

            timePeriod = timePeriod * (1 - factor3);
          
        }

        if (wave == 0 || isBig)
        {
            nextPos.x = pivot.x + magnitude * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
            nextPos.y = pivot.y + 0.3f *magnitude * Mathf.Cos(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
            timeSinceStart += Time.deltaTime;
        }





        nextPos += Vector3.forward * Time.deltaTime * movementSpeed;

        transform.localPosition = nextPos;
    }


}
