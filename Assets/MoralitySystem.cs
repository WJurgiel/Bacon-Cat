using UnityEngine;

public class MoralitySystem : MonoBehaviour
{
    private int moralityPoints = 0;

    public void addMoralPoint()
    {
        moralityPoints++;
    }

    public int GetMoralityPoints()
    {
        return moralityPoints;
    }
}
