using System;
using UnityEngine;

public interface IItem
{
    public Type Type { get; }
    public Sprite Icon { get; }
    public void MoveLocal(Vector3 position, float timeMove);
    public void Move(Vector3 position, float timeMove);
}