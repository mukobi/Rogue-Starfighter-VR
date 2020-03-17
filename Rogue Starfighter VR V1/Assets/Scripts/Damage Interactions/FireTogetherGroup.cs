using UnityEngine;
using System.Collections;

public class FireTogetherGroup : Fireable
{
    public Fireable[] fireables;

    public override void Fire()
    {
        for (int i = 0; i < fireables.Length; i++)
        {
            fireables[i].Fire();
        }
    }
}
