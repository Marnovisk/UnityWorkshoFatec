using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProjectile : Projectile
{

    public Vector3 targetPos;
    public Vector3 targetDir;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Init(Transform ptarget)
    {
        base.Init();
        targetPos = ptarget.position;
        targetDir = (targetPos - transform.position).normalized;
        transform.Rotate(targetDir, Space.World);
        isReady = true;
    }

    public override void Update()
    {
        if(isReady == false) return;
        base.Update();
        transform.position += Vector3.forward * Time.deltaTime * brain.projectileSpeed;
    }
}
