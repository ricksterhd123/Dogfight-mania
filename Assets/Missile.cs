/**
 * Base behaviour class for the missile object
 */
using UnityEngine;

public class Missile
{
    private GameObject missileObject;
    private float timeStart;

    public GameObject targetObject;
    public float MaxSpeed;
    public float MaxLifeTime;

    // todo: tidy this up D.R.Y
    public Missile(GameObject missileObject)
    {
        this.missileObject = missileObject;
        this.timeStart = Time.time;
        this.MaxSpeed = 24;    // units/sec
        this.MaxLifeTime = 30;  // 30 seconds by default.
    }

    public Missile(GameObject missileObject, GameObject targetObject)
    {
        this.missileObject = missileObject;
        this.targetObject = targetObject;
        this.timeStart = Time.time;
        this.MaxSpeed = 24;
        this.MaxLifeTime = 30;
    }

    //public Missile(Transform missileObject, Transform targetObject, float MaxSpeed)
    //{
    //    this.missileObject = missileObject;
    //    this.targetObject = targetObject;
    //    this.timeStart = Time.time;
    //    this.MaxSpeed = MaxSpeed;
    //    this.MaxLifeTime = 30;
    //}

    //public Missile(Transform missileObject, Transform targetObject, float MaxSpeed, float MaxLifeTime)
    //{
    //    this.missileObject = missileObject;
    //    this.targetObject = targetObject;
    //    this.timeStart = Time.time;
    //    this.MaxSpeed = MaxSpeed;
    //    this.MaxLifeTime = MaxLifeTime;
    //}

    public void Update()
    {

        // todo: use later
        //float elapsedTime = Time.time - this.timeStart;
        //float progress = 1 - ((this.MaxLifeTime - elapsedTime) / this.MaxLifeTime);


        // transform.forward is always facing toward the newForward vector
        // which is also the new velocity.
        // no target => forward vector never changes => no rotation
        // target => forward vector changes => rotation
        Vector3 newForward = missileObject.transform.forward * this.MaxSpeed;   // the new forward velocity vector
        if (this.targetObject)
        {
            // Move towards the target.
            newForward = (((this.targetObject.transform.position + new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5))) - this.missileObject.transform.position)) - (this.missileObject.transform.forward);
            newForward *= this.MaxSpeed;
        }
        
        // Update position and rotation
        missileObject.transform.position += newForward * Time.deltaTime;
        if (this.targetObject)
            missileObject.transform.LookAt(this.targetObject.transform);
    }
}
