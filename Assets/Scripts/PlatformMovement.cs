using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNumberMove;
    [SerializeField] private GameObject _canvasGameOver;
    private void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray ray;
            if (Input.touchCount > 0)
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            else
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Platform clickableObject = hit.transform.GetComponent<Platform>();               
                clickableObject.Rotate();               
            }
        }
    }

    public void AddMoves()
    {
        _canvasGameOver.SetActive(false);
        Time.timeScale = 1;
    }
}