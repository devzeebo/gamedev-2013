using UnityEngine;
using System.Collections.Generic;

public class ClosestEnemy : TargetingScript
{
    public override GameObject GetNextEnemy(List<GameObject> enemies)
    {
		enemies.RemoveAll((obj) => obj == null);

		if (enemies.Count == 0)
		{
			return null;
		}

        enemies.Sort((one, two) =>
            (int)(Vector3.Distance(transform.position, two.transform.position) -
                Vector3.Distance(transform.position, one.transform.position))
        );

        return enemies[0];
    }
}