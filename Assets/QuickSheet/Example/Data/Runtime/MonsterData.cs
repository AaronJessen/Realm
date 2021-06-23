using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class MonsterData
{
  [SerializeField]
  int index;
  public int Index { get {return index; } set { this.index = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  int[] speed = new int[0];
  public int[] Speed { get {return speed; } set { this.speed = value;} }
  
  [SerializeField]
  int[] hp = new int[0];
  public int[] HP { get {return hp; } set { this.hp = value;} }
  
  [SerializeField]
  int[] attack = new int[0];
  public int[] Attack { get {return attack; } set { this.attack = value;} }
  
  [SerializeField]
  int[] skill = new int[0];
  public int[] Skill { get {return skill; } set { this.skill = value;} }
  
  [SerializeField]
  int[] size = new int[0];
  public int[] Size { get {return size; } set { this.size = value;} }
  
}