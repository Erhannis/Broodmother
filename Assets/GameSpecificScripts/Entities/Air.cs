using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities {
public class Air : Tile
{
    public Air(Pos3 pos) : base(pos) {
    }

    override public void render(Pos3 center) {
        base.render(center);
        //TODO Decide whether to use visible air OR warpColor, for depth
        GL.Begin(GL.QUADS);
        GL.Color(ColorScheme.AIR);
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