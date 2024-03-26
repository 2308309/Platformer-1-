using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void HandleInput()
    {
        if (Target == null)
            return;

        Vector2 targetDirection = Target.position - transform.position;
        targetDirection = targetDirection.normalized;

        _inputDirection = targetDirection;

        

    }
}
