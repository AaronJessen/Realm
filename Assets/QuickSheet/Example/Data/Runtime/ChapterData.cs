using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class ChapterData
{
  [SerializeField]
  int chpaterindex;
  public int Chpaterindex { get {return chpaterindex; } set { this.chpaterindex = value;} }
  
  [SerializeField]
  int episodeindex;
  public int Episodeindex { get {return episodeindex; } set { this.episodeindex = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string description;
  public string Description { get {return description; } set { this.description = value;} }
  
  [SerializeField]
  int[] reward = new int[0];
  public int[] Reward { get {return reward; } set { this.reward = value;} }
  
  [SerializeField]
  int[] rewardvalue = new int[0];
  public int[] Rewardvalue { get {return rewardvalue; } set { this.rewardvalue = value;} }
  
}