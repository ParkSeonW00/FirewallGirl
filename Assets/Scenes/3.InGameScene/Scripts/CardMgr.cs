using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum CardExType { TestCardData1, TestCardData2, TestCardData3, TestCardData4 }
public class CardMgr : MonoBehaviour
{
    List<Card> CardInventory = new List<Card>();
    public PlayerCardObject[] CardObject;
    // ���� ����� CardObject�� �ε���
    private int currentIndex = 0;

    public void CardCreate(CardExType inputType)
    {
        int cardIndex = (int)inputType;

        GameObject cardGo = new GameObject(inputType.ToString());
        cardGo.transform.parent = this.gameObject.transform;


        Card card = cardGo.AddComponent<Card>();
        BoxCollider2D collider = cardGo.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        card.cardName = CardObject[cardIndex].cardName;
        card.positiveNum = CardObject[cardIndex].positiveNum;
        card.negativeNum = CardObject[cardIndex].negativeNum;
        card.type = CardObject[cardIndex].type;


        CardInventory.Add(card);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���콺 ��Ŭ���� 
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            // �浹��
            if (hit.collider != null)
            {
                // �浹�� ��ü�� Card ������Ʈ ��������
                CardMgr hitCard = hit.collider.GetComponent<CardMgr>();

                for(int i = 0; i <= currentIndex; i++)
                {
                    if (hitCard != null)
                    {
                        Debug.Log($"{hitCard.CardObject[i].cardName}");
                        Debug.Log($"{hitCard.CardObject[i].positiveNum}");
                        Debug.Log($"{hitCard.CardObject[i].negativeNum}");
                        Debug.Log($"{hitCard.CardObject[i].type}");
                        currentIndex = (currentIndex + 1) % hitCard.CardObject.Length;
                    }
                    else
                    {
                        Debug.Log("�ش� ��ü�� ����� ī�� �����͸� ã�� �� �����ϴ�.");
                    }
                    
                }
               
            }
        }

    }

}
