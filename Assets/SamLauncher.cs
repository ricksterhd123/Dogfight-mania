using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamLauncher : MonoBehaviour
{

    public GameObject missilePrefab;    // Used to instantiate and control with missile class.
    public GameObject missileTarget;    // For now, just set a constant target.

    private LinkedList<Missile> missiles = new LinkedList<Missile>();
    private Missile[] temp = new Missile[0];

    void Fire()
    { 
        missiles.AddFirst(new Missile(Instantiate(missilePrefab, gameObject.transform), missileTarget));
        temp = new Missile[missiles.Count];
        missiles.CopyTo(temp, 0);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].Update();
        }

        if (Input.GetKeyDown("k"))
        {
            Fire();
        }
    }
}
