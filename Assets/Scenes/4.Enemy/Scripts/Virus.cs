using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Virus : MonoBehaviour
{
    public Image virusImage;
    public int indexNum;
    public SpriteRenderer imageRender;
    public TextMeshPro virusName;

    public TextMeshPro atkDmg;
    public TextMeshPro hpCnt;


    public void Start()
    {
        if (VirusMgr.instance == null)
        {
            Debug.LogError("CardMgr.instance�� �ʱ�ȭ���� �ʾҽ��ϴ�.");
            return;
        }

        //dataset.data.FindIndex(card => card.CardNum.Equals(cardNum));

        // ���̷��� SO���� �ڿ� �ʵ忡 ������ ���� ����� ������ ���� ��� �߰��� �κ�.
        //VirusData cardData = CardMgr.instance.cardDatas.Find(card => card.CardNum == cardNum);


        //cardImage.sprite = cardData.CardImage;
        //cardName.text = cardData.CardName;
        //positiveNum.text = cardData.PositiveNum.ToString();
        //negativeNum.text = cardData.NegativeNum.ToString();
        //costNum.text = cardData.CostNum.ToString();

        // ������ ����ĭ�� ����־ ������.
        //description.text = cardData.Description;
    }
}
