<div class="alert alert-primary" role="alert">
    In this section, learn how to edit the hideout file and use the calculator found on this web tool. 
</div>

## History

In Path of Exile patch <a href="https://pathofexile.gamepedia.com/Harvest">3.11, Harvest League</a>, ground tiles were added to the hideout. These tiles are great but can be a bit cumbersome to place from the in-game editor. 

The calculator here is to help you place these tiles in the large <a href="https://pathofexile.gamepedia.com/Celestial_Nebula_Hideout">Celestial Nebula Hideout</a> to fully cover the ground of your hideout.

This tool is able to function because they POE hideout file is written in plain-text, and is actually quite easy to understand and start making minor edits. Thanks to the GGG team for that design!

## Exporting the Hideout File

<img src="images/hideout/Hideout.png" width='600px'> </img>

After you customize your hideout, there is an **[Export]** feature right near the other hideout editor UI buttons.

<img src="images/hideout/Export.png" width='600px'> </img>

Export the hideout file to your desktop, and you can name it `MyOriginalHideout.hideout`.

Open that file with the text editor of your choice. You can use Notepad on Windows or TextEdit on Mac, but any plain-text editor would do.

Here is what my hideout file looks like.

```
Language = "English"
Hideout Name = "Celestial Nebula Hideout"
Hideout Hash = 35022

Stash = { Hash=3230065491, X=345, Y=291, Rot=0, Flip=0, Var=0 }
Guild Stash = { Hash=139228481, X=374, Y=278, Rot=0, Flip=0, Var=0 }
Waypoint = { Hash=1224707366, X=335, Y=307, Rot=0, Flip=0, Var=0 }
Crafting Bench = { Hash=2059629901, X=334, Y=329, Rot=0, Flip=0, Var=0 }
Map Device = { Hash=2306038834, X=363, Y=291, Rot=0, Flip=0, Var=0 }
Navali = { Hash=693228958, X=313, Y=358, Rot=44494, Flip=0, Var=0 }
Einhar = { Hash=2684274993, X=361, Y=288, Rot=12415, Flip=0, Var=0 }
Alva = { Hash=2115859440, X=392, Y=326, Rot=6133, Flip=0, Var=0 }
Helena = { Hash=845403974, X=385, Y=312, Rot=64486, Flip=0, Var=0 }
Niko = { Hash=2906227343, X=385, Y=309, Rot=14013, Flip=0, Var=0 }
Jun = { Hash=3992724805, X=326, Y=380, Rot=8609, Flip=0, Var=0 }
Zana = { Hash=3506797600, X=360, Y=365, Rot=54836, Flip=0, Var=0 }
Sister Cassia = { Hash=10623884, X=401, Y=313, Rot=22203, Flip=0, Var=0 }
Tane Octavius = { Hash=4285419720, X=385, Y=312, Rot=57483, Flip=0, Var=0 }
Kirac = { Hash=2913423765, X=361, Y=353, Rot=21782, Flip=0, Var=0 }
Slave Pens Bed = { Hash=1971960958, X=358, Y=324, Rot=0, Flip=0, Var=0 }
Red Carpet = { Hash=1255200948, X=359, Y=314, Rot=0, Flip=0, Var=0 }
```

You can see GGG *currently* sorts that data by placing the main hideout name first, then the important hideout parts (like stashes,) then masters, then the rest of the decor.

From this plain text, you can delete a line that contains a bit of decor, such as `Red Carpet = { Hash=1255200948, X=359, Y=314, Rot=0, Flip=0, Var=0 }`, save the file as `MyModifiedHideout.hideout`, and **[Import]** that changed hideout file.

<img src="images/hideout/Import.png" width='600px'> </img>

As you hopefully expected, the Red Carpet is gone when re-importing the file.

We can use this logic to also add in any decor we want, without having to manually do it via the in-game editor.

## Parts of the Decor Item

`Slave Pens Bed = { Hash=1971960958, X=358, Y=324, Rot=0, Flip=0, Var=0 }`

Focusing on Slave Pens Bed, we can see the data is broken up into 7 parts. The name Slave Pens, the hash 1971960958, the x and y position data of 358 and 324, the rotation 0, the flip 0, and the variant 0.

Most of those items are self explanatory. 

- **Name:** the name doesn't really matter, it's only so we the players can easily read what the decor is, and asset name doesn't appear consistent on all exports. But they are always readable :)
- **Hash:** acts as the id for the item. You can view it as the *real* name. Not easy for us to read, but it's always the same. 
- **X and Y:** position data, with the caveat that the Celestial Nebula Hideout hideout doesn't start at the 0,0 coordinate. The initial point is closer to 153,153, and the final position is closer to 559,559
- **Rotation:** rotation is simple enough, with the caveat that a 90-degree rotation is reprented with the value of 16385.
- **Flip:** if it is mirrored. 1 for yes, 0 for no.
- **Var:** the variant number. Lot's of these assets have many variants, just keep in mind that the variant number starts at 0 in the data. So the fifth variant would be Var=4.

So knowing this, we can start placing items exactly where we want. **For example,** most large tiles have the width of 69 *(nice,)* so if we were to add the following line `Arctic Ground = { Hash=2825914735, X=159, Y=208, Rot=0, Flip=0, Var=6 }` to the file, the next right most non-overlapping adjacent spot would be `Arctic Ground = { Hash=2825914735, X=228, Y=208, Rot=0, Flip=0, Var=6 }`.

**Okay, but while that can be more convenient then placing tiles via the in-game editor, editing that text is still tedious.**

Yup. That's where this calulator comes into play.

## Using the Calculator

The calculator is pretty simple.

Currently, you can select a Ground Tile, Water Tile, and Grass Patches.

After doing so, click the **[Generate]** button on the calculator. This will create all the data need to completely cover the ground with those tiles.

<img src="images/hideout/Generate.png" width='600px'> </img>

Copy this data, and paste it into your modified hideout file, and **[Import]** the file into POE with the new change.

Your hideout is now covered with your chosen ground.

<img src="images/hideout/Grounded.png" width='600px'> </img>

If you regret your ground choice and want to switch later, just delete previous ground you added to the hideout file, and paste in the new ground you want.