using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class MaterialPropertySingleton
{
    private static MaterialPropertyBlock _materialProperty;
    private static MaterialPropertyBlock MaterialPropertyBlock => _materialProperty ??= new MaterialPropertyBlock();

    public static void SetProperty(this Renderer renderer, string propertyHash, Color value, int materialIndex = 0)
    {
        renderer.GetPropertyBlock(MaterialPropertyBlock);

        MaterialPropertyBlock.SetColor(propertyHash, value);

        renderer.SetPropertyBlock(MaterialPropertyBlock, materialIndex);
    }
}

