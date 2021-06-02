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
  int unlocklevel;
  public int Unlocklevel { get {return unlocklevel; } set { this.unlocklevel = value;} }
  
  [SerializeField]
  int[] upgradelevel = new int[0];
  public int[] Upgradelevel { get {return upgradelevel; } set { this.upgradelevel = value;} }
  
  [SerializeField]
  string[] type = new string[0];
  public string[] Type { get {return type; } set { this.type = value;} }
  
  [SerializeField]
  int speed;
  public int Speed { get {return speed; } set { this.speed = value;} }
  
  [SerializeField]
  int range;
  public int Range { get {return range; } set { this.range = value;} }
  
  [SerializeField]
  float cd;
  public float CD { get {return cd; } set { this.cd = value;} }
  
  [SerializeField]
  float[] skillvalue = new float[0];
  public float[] Skillvalue { get {return skillvalue; } set { this.skillvalue = value;} }
  
}