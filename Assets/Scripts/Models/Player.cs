#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 00:47

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using System.Text;

public sealed class Player
{
    public List<Card> Hand;

    public Player()
    {
        Hand = new List<Card>();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        int length = Hand.Count;

        if (length == 0) stringBuilder.Append("Empty");

        for (byte i = 0; i < length; i++)
        {
            Card card = Hand[i];
            string name = card.ToString();

            stringBuilder.Append(name);

            if (i < length - 1) stringBuilder.Append(" | ");
        }

        return stringBuilder.ToString();
    }
}
