using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player { RED,BLUE,GREEN,YELLOW }

public class Board
{
    Dictionary<Player, int> playerPos;
    int[] ladders;

    public Board(Dictionary<int,int> joints)
    {
        playerPos = new Dictionary<Player, int>();
        ladders = new int[100];

        for(int i = 0; i < 4; i++)
        {
            playerPos[(Player)i] = 0;
        }

        for (int i = 0; i < 100; i++)
        {
            ladders[i] = -1;
        }

        foreach(KeyValuePair<int,int> joint in joints)
        {
            ladders[joint.Key] = joint.Value;
        }
    }

    public List<int> UpdateBoard(Player player,int roll)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < roll; i++)
        {
            playerPos[player] += 1;
            result.Add(playerPos[player]);
        }

        if(result[result.Count - 1] > 99)
        {
            playerPos[player] -= roll;
            return new List<int>();
        }

        if(ladders[result[result.Count - 1]] != -1)
        {
            playerPos[player] = ladders[result[result.Count - 1]];
            result.Add(playerPos[player]);
        }

        return result;
    }

    
}
