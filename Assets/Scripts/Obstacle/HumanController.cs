using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField]
    GameObject fearArea;
    [SerializeField]
    GameObject slowdownArea;

    private void Start() {
        slowdownArea.SetActive(false);
        fearArea.SetActive(true);
    }

    public void LoseFearArea() {
        fearArea.SetActive(false);
        slowdownArea.SetActive(true);
    }

    public void LoseSlowdownArea() {
        slowdownArea.SetActive(false);
    }
}
