using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TelentController : MonoBehaviour {

    List<Telent> telentNodes = new List<Telent>();

    void Start() {
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart() {
        // wait for the others start functions 
        // loading screen may be show if this is really loaded form Database

        yield return new WaitForEndOfFrame(); 
        for (int i = 0; i < transform.childCount; ++i) { // all children must have telent
            telentNodes.Add(transform.GetChild(i).GetComponent<Telent>());
        }

        /*
         *  may be loop to assign TelentID that are completed
        Debug.Log("Database loadeding");
        (from tn in telentNodes where tn.TelentID == 1 select tn).ToList()[0].Reward(); 
        (from tn in telentNodes where tn.TelentID == 2 select tn).ToList()[0].Reward();
        (from tn in telentNodes where tn.TelentID == 3 select tn).ToList()[0].Reward();
        (from tn in telentNodes where tn.TelentID == 4 select tn).ToList()[0].Reward();
        */
    }
}
