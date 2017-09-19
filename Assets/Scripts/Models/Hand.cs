#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       19/09/2017 17:22

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Text;

public class Hand : CardCollection
{
    public Hand() : base()
    {

    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        int length = cards.Count;

        if (length == 0) stringBuilder.Append("Empty");

        for (byte i = 0; i < length; i++)
        {
            Card card = cards[i];
            string name = card.ToString();

            stringBuilder.Append(name);

            if (i < length - 1) stringBuilder.Append(" | ");
        }

        return stringBuilder.ToString();
    }
}
