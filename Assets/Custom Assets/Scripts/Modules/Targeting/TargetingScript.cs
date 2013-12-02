using UnityEngine;
using System.Collections.Generic;

public abstract class TargetingScript : MonoBehaviour {

    public abstract GameObject GetNextEnemy(List<GameObject> enemies);
}
