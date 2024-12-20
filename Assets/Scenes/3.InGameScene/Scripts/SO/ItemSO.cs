using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{
    public string name; //�̸� 
    public int attack;  //���ݷ�
    public int health;  //ü��
    public Sprite sprite;//��������Ʈ
    public float percent;//ī���� Ȯ��
}

[CreateAssetMenu(fileName ="ItemSO", menuName= "Scriptable Object/ItemSO")]  
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
