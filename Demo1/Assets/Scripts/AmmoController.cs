using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public int maxAmmo;
    public int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = 10;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
