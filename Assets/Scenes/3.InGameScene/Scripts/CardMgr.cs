using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMgr : MonoBehaviour
{
    // �̱��� 
    public static CardMgr Inst { get; private set; }
    void Awake() => Inst = this;

    [SerializeField] ItemSO itemSO;

    //������ ���� ����Ʈ
    List<Item> itemBuffer;

    void SetupItemBuffer()
    {
        for (int i = 0; i < itemSO.items.Length; i++)
        {
            Item item = itemSO.items[i];
            for (int j = 0; j < item.percent; j++)
            {
                itemBuffer.Add(item);
            }
        }

        //������ ������ �����ϰ�
        for (int i = 0; i < itemBuffer.Count; i++)
        {
            int rand = Random.Range(i, itemBuffer.Count);
            Item temp = itemBuffer[i];
            itemBuffer[i] = itemBuffer[rand];
            itemBuffer[rand] = temp;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupItemBuffer();
    }

}
