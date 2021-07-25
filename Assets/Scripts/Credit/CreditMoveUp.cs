using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMoveUp : MonoBehaviour
{
    void Start()
    {
        LeanTween.moveLocalY(gameObject, 3273, 60).setEaseLinear();
    }

}
