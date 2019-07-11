using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

class HighScore:  IComparable<HighScore>
{
	public int Score { get; set;}
	public string Name { get; set;}
	public int Id { get; set;}

	public HighScore(int id, string name, int score){
		this.Id = id;
		this.Name = name;
		this.Score = score;
	}

	#region IComparable implementation

	public int CompareTo (HighScore other)
	{
		if (other.Score < this.Score)
			return -1;
		if (other.Score > this.Score)
			return 1;
		return 0;
	}

	#endregion
}
