using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool PlayerTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTurn = true;
    }

    public void OnTrunButtonClick()
    {
        // true -> PlayerTurn���� �ٲٱ�
        if (true)
        {
            Debug.Log("�� �ѱ�� ����");
            PlayerTurn = !PlayerTurn;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
