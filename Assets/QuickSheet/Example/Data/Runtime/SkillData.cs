using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class SkillData
{
  [SerializeField]
  int index;
  public int Index { get {return index; } set { this.index = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string[] skilltype = new string[0];
  public string[] Skilltype { get {return skilltype; } set { this.skilltype = value;} }
  
  [SerializeField]
  int speed;
  public int Speed { get {return speed; } set { this.speed = value;} }
  
  [SerializeField]
  int range;
  public int Range { get {return range; } set { this.range = value;} }
  
  [SerializeField]
  int mp;
  public int MP { get {return mp; } set { this.mp = value;} }
  
  [SerializeField]
  int cd;
  public int CD { get {return cd; } set { this.cd = value;} }
  
  [SerializeField]
  int[] upgradegem = new int[0];
  public int[] Upgradegem { get {return upgradegem; } set { this.upgradegem = value;} }
  
  [SerializeField]
  int[] skillvalue1 = new int[0];
  public int[] Skillvalue1 { get {return skillvalue1; } set { this.skillvalue1 = value;} }
  
  [SerializeField]
  int[] skillvalue2 = new int[0];
  public int[] Skillvalue2 { get {return skillvalue2; } set { this.skillvalue2 = value;} }
  
}