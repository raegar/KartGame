using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public int CheckpointID;
    public delegate void OnHitByPlayerAction(int checkpoint);
    public OnHitByPlayerAction OnHitByPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<KartController>() != null)
        {
            if (OnHitByPlayer != null)
            {
                OnHitByPlayer(CheckpointID);
            }
        }
    }

}
