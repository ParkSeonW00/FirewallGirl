using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardMgr : MonoBehaviour
{
    //List<Card> CardInventory = new List<Card>();
    public PlayerCardObject[] CardObject;
    public static CardMgr instance;

    public List<CardData> cardDatas = new List<CardData>();

    // ���� ����� CardObject�� �ε���
    private int currentIndex = 0;

    public CardData CardCreate(PlayerCardObject cardObject)
    {
        CardData cardData = new CardData(cardObject.cardIndex, cardObject.cardImage, cardObject.cardName, cardObject.positiveNum, cardObject.negativeNum , cardObject.description);
        return cardData;
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(PlayerCardObject card in CardObject)
        {
            cardDatas.Add(CardCreate(card));
        }
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
                Card hitCard = hit.collider.GetComponent<Card>();

                if (hitCard != null)
                {
                    Debug.Log($"{hitCard.cardName.text}");
                    Debug.Log($"{hitCard.positiveNum.text}");
                    Debug.Log($"{hitCard.negativeNum.text}");    
                    if(hitCard.description != null)
                        Debug.Log($"{hitCard.description.text}");



                }
                
                else
                {
                    Debug.Log("�ش� ��ü�� ����� ī�� �����͸� ã�� �� �����ϴ�.");
                }


            }
        }

    }

}
