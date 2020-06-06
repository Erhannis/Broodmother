using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities {
public class Rock : Tile
{
    public Rock(Pos3 pos) : base(pos) {
    }

    override public void render(Pos3 center) {
        base.render(center);
        GL.Begin(GL.QUADS);
        GL.Color(warpColor(center, ColorScheme.ROCK));
        // float ox = (float)(pos.x - center.x);
        // float oy = (float)(pos.y - center.y);
        // float oz = (float)(pos.z - center.z);
        float ox = 0;
        float oy = 0;
        float oz = 0;
        GL.Vertex3(ox-0.5f, oy-0.5f, oz);
        GL.Vertex3(ox+0.5f, oy-0.5f, oz);
        GL.Vertex3(ox+0.5f, oy+0.5f, oz);
        GL.Vertex3(ox-0.5f, oy+0.5f, oz);
        GL.End();
    }
}
}