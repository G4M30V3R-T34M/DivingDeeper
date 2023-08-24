using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField]
    GameObject fearArea;
    [SerializeField]
    GameObject slowdownArea;

    public void LoseFearArea() {
        fearArea.SetActive(false);
    }

    public void LoseSlowdownArea() {
        slowdownArea.SetActive(false);
    }
}
