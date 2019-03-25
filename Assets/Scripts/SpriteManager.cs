#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 20:38

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public sealed class SpriteManager
{
    public static readonly SpriteManager Instance = new SpriteManager();

    private Dictionary<string, Sprite> sprites;

    private SpriteManager()
    {
        sprites = new Dictionary<string, Sprite>();

        LoadAll();
    }

    private void LoadAll()
    {
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Sprites/Cards");
        Sprite[] sprites = new Sprite[atlas.spriteCount];
        atlas.GetSprites(sprites);
        int lenght = sprites.Length;

        for (int i = 0; i < lenght; i++)
        {
            Sprite sprite = sprites[i];
            string name = sprite.name.Replace("(Clone)", string.Empty);
            this.sprites.Add(name, sprite);
        }
    }

    /// <summary>
    /// Returns sprite with name.
    /// </summary>
    /// <param name="name">Sprite name</param>
    /// <returns></returns>
    public Sprite GetSprite(string name)
    {
        return sprites[name];
    }

    /// <summary>
    /// Returns sprite with card.
    /// </summary>
    /// <param name="card">Card</param>
    /// <returns></returns>
    public Sprite GetSprite(Card card)
    {
        return GetSprite(card.ToString());
    }
}
