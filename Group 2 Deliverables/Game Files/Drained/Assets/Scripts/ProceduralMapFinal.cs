using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralMapFinal : MonoBehaviour
{
     //Variables to hold min and max width
    [Header ("Minimum and Maximum Map width")]
    [SerializeField] private int minwidth,maxwidth;
    //Variables to hold min and max height
    [Header ("Minimum and Maximum Map height")]
    [SerializeField] private int minheight,maxheight;
    //Variable to hold platform depth
    [Header ("Platform Depth")]
    [SerializeField] private int platformdepth;
    //Variables to hold tiles
    [Header ("Tiles Middle")]
    [SerializeField] private Tile [] tileMiddle;
    [Header ("Tiles Background")]
    [SerializeField] private Tile tileBackground;

    [Header ("Tiles Right")]
    [SerializeField] private Tile [] tileRight;
    [Header ("Tiles Left")]
    [SerializeField] private Tile [] tileLeft;

    //Variable to hold tilemap
    [Header ("Tilemap")]
    [SerializeField] private Tilemap tilemap;

    private void Start(){
        Generation();
    }

    //Method which generates map
    private void Generation(){
        for(int x=minwidth-platformdepth*12+1; x<maxwidth+platformdepth*12;x++){//This will spawn the ground
            for(int d=0; d<platformdepth*10;d++){
                tilemap.SetTile(new Vector3Int(x,minheight-d,0),tileBackground);
            }
        }

        for(int x=minwidth-platformdepth*12+1; x<maxwidth+platformdepth*12;x++){//This will spawn the roof
            for(int d=0; d<platformdepth*10;d++){
                tilemap.SetTile(new Vector3Int(x,maxheight+d,0),tileBackground);
            }
        }

        for(int y=minheight-1; y<maxheight+1;y++){//This will spawn the left wall
            for(int d=0; d<platformdepth*12;d++){
                tilemap.SetTile(new Vector3Int(minwidth-d,y,0),tileBackground);
            }
        }

        for(int y=minheight-1; y<maxheight+2;y++){//This will spawn the right wall
            for(int d=0; d<platformdepth*12;d++){
                tilemap.SetTile(new Vector3Int(maxwidth+d,y,0),tileBackground);
            }
        }

        int random = Random.Range(0,10);

        if(random>0 &&random<5){
            //This method will spawn a pyramid inside the generated square
            SetPlatform1(new Vector3Int(maxwidth/4,maxheight-maxheight/9,0),true);
        }else if(random>5 &&random<7){
            //This method will spawn 25 meter style level inside the generated square
            SetPlatform3(new Vector3Int(minwidth+1,maxheight-maxheight/9,0),true);
        }else{
            //This method will spawn random platforms inside the generated square
            SetPlatform2(new Vector3Int(minwidth+1,maxheight-maxheight/9,0),true);
        }
    
    }

    //Recursive method which generates a pyramid
    private void SetPlatform1(Vector3Int v,bool flag){
        //Calculating height offset
        int heightoffset=platformdepth+maxheight/Random.Range(11,12);
        //Boolean flag which will be used to stop recursive statement
        bool stopflag=false;
        //Calculating width offset, and setting specific patform width
        int widthoffset=Random.Range(maxwidth/10,maxwidth/9);
        int platformwidth=Random.Range(maxwidth/7,maxwidth/5);
        //If the new height is smaller than the minimum height, or new width is larger than max width then stopflag is set to true        
        if((v.y-heightoffset)<(minheight-1)||(v.x+widthoffset)>(maxwidth-1)){
            stopflag=true;
        }
        //Checking whether new height and width are smaller than the minimum height and minimum width
        //if so, if statement won't execute
        if(v.y>=(minheight-1)&&(v.x>=(minwidth+1)&&v.x<=(maxwidth-1))&&stopflag==false){
            //Acquiring random tile to print
            //Tile tile=getRandomTile();
            //printing platform with new random tile
            for(int k=0; k<platformwidth;k++){
                int newwidth=v.x+k;
                if(v.y>=(minheight-1)&&(newwidth>=(minwidth+1)&&newwidth<=(maxwidth-1))){
                    for(int d=0; d<platformdepth;d++){
                        if(k==0){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomLeftTile());
                        }
                        else if(k==platformwidth-1){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomRightTile());
                        }
                        else{
                            if(d%2==0){
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[0]);
                            }
                            else {
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[1]);
                            }
                        }
                    }
                }
            }

            //Recursively calling SetPlatform method to spawn 2 new platforms based on flag 
            if(flag==true){
                SetPlatform1(new Vector3Int(v.x+widthoffset+platformwidth,v.y-heightoffset,0),true);
                SetPlatform1(new Vector3Int(v.x-widthoffset,v.y-heightoffset,0),false);
            }
            else {
                SetPlatform1(new Vector3Int(v.x-widthoffset,v.y-heightoffset,0),false);
            }
        }
    }

    //Recursive method which generates random platforms
    private void SetPlatform2(Vector3Int v,bool flag){
        //Calculating height offset
        int heightoffset=platformdepth+maxheight/Random.Range(11,12);
        //Boolean flag which will be used to stop recursive statement
        bool stopflag=false;
        //Calculating width offset, and setting specific patform width
        int widthoffset=Random.Range(maxwidth/10,maxwidth/9);
        int platformwidth=Random.Range(maxwidth/8,maxwidth/3);
        //If the new height is smaller than the minimum height, or new width is larger than max width then stopflag is set to true        
        if((v.y-heightoffset)<(minheight-1)||(v.x+widthoffset)>(maxwidth-1)){
            stopflag=true;
        }
        //Checking whether new height and width are smaller than the minimum height and minimum width
        //if so, if statement won't execute
        if(stopflag==false&&v.y>=(minheight-1)&&(v.x>=(minwidth+1)&&v.x<=(maxwidth-1))){
            //Acquiring random tile to print
            //Tile tile=getRandomTile();
            //printing platform with new random tile
            for(int k=0; k<platformwidth;k++){
                int newwidth=v.x+k;
                if(v.y>=(minheight-1)&&(newwidth>=(minwidth+1)&&newwidth<=(maxwidth-1))){
                    for(int d=0; d<platformdepth;d++){
                        if(k==0){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomLeftTile());
                        }
                        else if(k==platformwidth-1){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomRightTile());
                        }
                        else{
                            if(d%2==0){
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[0]);
                            }
                            else {
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[1]);
                            }
                        }
                    }
                }
            }

            //Recursively calling SetPlatform method to spawn 2 new platforms based on flag 
            if(flag==true){
                SetPlatform2(new Vector3Int(v.x+widthoffset+platformwidth,v.y,0),false);
                SetPlatform2(new Vector3Int(v.x,v.y-heightoffset,0),true);
            }
            else {
                SetPlatform2(new Vector3Int(v.x+widthoffset+platformwidth,v.y,0),false);
            }
        }
    }

    //Recursive method which generates a 25 meter style level
    private void SetPlatform3(Vector3Int v,bool flag){
        //Calculating height offset
        int heightoffset=platformdepth+maxheight/Random.Range(11,12);
        //Boolean flag which will be used to stop recursive statement
        bool stopflag=false;
        //Calculating width offset, and setting specific patform width
        int widthoffset=Random.Range(maxwidth/5,maxwidth/4);
        int platformwidth=Random.Range(maxwidth/3,maxwidth/2);
        if(flag==false){
            platformwidth=maxwidth-v.x;
        }
        //If the new height is smaller than the minimum height, or new width is larger than max width then stopflag is set to true        
        if((v.y-heightoffset)<(minheight-1)||(v.x+widthoffset)>(maxwidth-1)){
            stopflag=true;
        }
        //Checking whether new height and width are smaller than the minimum height and minimum width
        //if so, if statement won't execute
        if(stopflag==false&&v.y>=(minheight-1)&&(v.x>=(minwidth+1)&&v.x<=(maxwidth-1))){
            //Acquiring random tile to print
            //Tile tile=getRandomTile();
            //printing platform with new random tile
            for(int k=0; k<platformwidth;k++){
                int newwidth=v.x+k;
                if(v.y>=(minheight-1)&&(newwidth>=(minwidth+1)&&newwidth<=(maxwidth-1))){
                    for(int d=0; d<platformdepth;d++){
                        if(k==0){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomLeftTile());
                        }
                        else if(k==platformwidth-1){
                            tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),getRandomRightTile());
                        }
                        else{
                            if(d%2==0){
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[0]);
                            }
                            else {
                                tilemap.SetTile(new Vector3Int(newwidth,v.y-d,0),tileMiddle[1]);
                            }
                        }
                    }
                }
            }

            //Recursively calling SetPlatform method to spawn a new platform based on flag 
            if(flag==true){
                SetPlatform3(new Vector3Int(v.x-widthoffset+platformwidth,v.y-heightoffset,0),false);
            }
            else {
                SetPlatform3(new Vector3Int(minwidth+1,v.y-heightoffset,0),true);
            }
        }
    }


    //Method which returns a randomly generated tile from the inputted left tiles
    private Tile getRandomLeftTile(){
        Tile tile;
        tile=tileLeft[Random.Range(0,tileLeft.Length)];
        return tile;
    }

    //Method which returns a randomly generated tile from the inputted right tiles
    private Tile getRandomRightTile(){
        Tile tile;
        tile=tileRight[Random.Range(0,tileRight.Length)];
        return tile;
    }
}
