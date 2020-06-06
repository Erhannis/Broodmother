﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

/**
    Infinite 3D world.  Centered at 0,0,0.
    Currently cubic grid, because easiest.
*/
public class World
{
    //TODO Woof.  Make a good caching mechanism.
    //TODO Save world!
    public Dictionary<Pos3, Tile> tiles = new Dictionary<Pos3, Tile>();

    public Tile genTile(Pos3 pos) {
        //TODO Make better world, haha

        if (Random.Range(0,6) == 0) { //TODO Use a seed or something
        //if (pos.x == pos.z) {
            return new Rock(pos);
        } else {
            return new Air(pos);
        }
    }

    public Tile getTile(Pos3 pos) {
        Tile tile;
        if (!tiles.TryGetValue(pos, out tile)) {
            tile = genTile(pos);
            tiles[pos] = tile;
        }
        return tile;
    }

    public void render(Pos3 center, Pos3 downWestSouth, Pos3 upEastNorth) {
        //TODO Scale?
        Debug.Log("world render " + center + " " + downWestSouth + "->" + upEastNorth);
        for (long y = downWestSouth.y; y <= upEastNorth.y; y++) {
            long dy = y - center.y;
            for (long x = downWestSouth.x; x <= upEastNorth.x; x++) {
                long dx = x - center.x;
                for (long z = downWestSouth.z; z <= upEastNorth.z; z++) {
                    long dz = z - center.z;
                    GL.PushMatrix();
                    GL.modelview = Matrix4x4.Translate(new Vector3(dx,dy,dz)) * GL.modelview;
                    getTile(new Pos3(x,y,z)).render(center);
                    GL.PopMatrix();
                }
            }
        }
    }
}
