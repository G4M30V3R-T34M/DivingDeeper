using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlaceholder : MonoBehaviour
{
    [SerializeField]
    BoxPuzzleController puzzleController;
    [SerializeField]
    int position;

    Box placedBox = null;

    private void OnTriggerEnter2D(Collider2D collision) {
        Box box = collision.gameObject.GetComponent<Box>();
        if(box != null && placedBox == null) {
            placedBox = collision.gameObject.GetComponent<Box>();
            puzzleController.SetValue(box.GetID(), position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Box box = collision.gameObject.GetComponent<Box>();
        if (box != null && placedBox != null) {
            puzzleController.UnsetValue(position);
            placedBox = null; ;
        }
    }

    public void BlockPlacedBox() {
        placedBox.enabled = false;
    }

    public void SucceedAnimation() {
        placedBox.SucceedAnimation();
    }

}
