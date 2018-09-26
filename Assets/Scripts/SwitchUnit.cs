using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUnit : MonoBehaviour {

    [SerializeField]
    MachineUnit[] machines;

    public void ShuffleColorSet()
    {
        foreach (MachineUnit machine in machines)
        {
            float r = 0;
            float g = 0; 
            float b = 0;

            int pos = Random.Range(0, 3);

            if (pos == 0)
            {
                r = 1;
                g = 0;
                b = 0;
            }
            else if (pos == 1)
            {
                r = 0;
                g = 1;
                b = 0;
            }
            else if (pos == 2)
            {
                r = 0;
                g = 0;
                b = 1;
            }
            machine.SetMachineRGB(r, g, b);
        }
    }
}
