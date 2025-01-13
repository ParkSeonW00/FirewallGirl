using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CardMgr : MonoBehaviour
{
    public PlayerCardObject[] CardObject;

    public static CardMgr instance;

    public CharacterData charData;

    public List<CardData> cardDatas = new List<CardData>();
    //private int totalCost = 10;

    public CardData CardCreate(PlayerCardObject cardObject)
    {
        CardData cardData = new CardData(cardObject.cardIndex, cardObject.cardImage, cardObject.cardName, cardObject.positiveNum, cardObject.negativeNum, cardObject.costNum, cardObject.description);
        return cardData;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (PlayerCardObject card in CardObject)
        {
             cardDatas.Add(CardCreate(card));
        }
    }

    
    public void ReduceCostOnClick(Card hitCard)
    {
        //�� �ڽ�Ʈ 
        int totalCost = int.Parse(charData.stats.Cost.text);
        // �ڽ�Ʈ ����
        if (hitCard.costNum != null)
        {
            // ���� ī���� �ڽ�Ʈ ���� ������ ������ ��ȯ
            int currentCost = int.Parse(hitCard.costNum.text);
            if (totalCost > currentCost)
            {
                // �ڽ�Ʈ ����
                totalCost = Mathf.Max(0,totalCost - currentCost);

                // UI ������Ʈ
                charData.stats.Cost.text = totalCost.ToString();

                Debug.Log($"���� �ڽ�Ʈ�� {currentCost}���� �����߽��ϴ�.");

            }
            else
            {
                Debug.Log("�ڽ�Ʈ�� �����մϴ�.");
            }

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
                    Card clickCard = hit.collider.GetComponent<Card>();

                    if (clickCard != null)
                    {
                        //Debug.Log($"{clickCard.cardName.text}");
                        //Debug.Log($"{clickCard.positiveNum.text}");
                        //Debug.Log($"{clickCard.negativeNum.text}");
                        //Debug.Log($"{clickCard.costNum.text}");
                        //if (hitCard.description != null)
                        //    Debug.Log($"{clickCard.description.text}");


                        ReduceCostOnClick(clickCard);

                    }

                    else
                    {
                        Debug.Log("�ش� ��ü�� ����� ī�� �����͸� ã�� �� �����ϴ�.");
                    }


                }
            }

        }
    }

