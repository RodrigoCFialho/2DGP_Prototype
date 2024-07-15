using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    public void Flip()
    {
        transform.right = -transform.right;
    }
}
