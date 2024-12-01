using UnityEngine;

public class MoralitySystem : MonoBehaviour
{
    private int moralityPoints = 0;

    public void addMoralPoint()
    {
        moralityPoints++;
        Debug.Log("Moral :" + moralityPoints);
    }

    public int GetMoralityPoints()
    {
        return moralityPoints;
    }
}
