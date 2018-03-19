  
using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;

internal class Program {

    static Random rand = new Random(42);
    
    public enum Cells {
        Empty,
        North,
        East
    }
    
    public static void Main(string[] args) {

        int n = 20, m = 30;
        double p = 0.9;
        Cells[,] cells = new Cells[n, m];

        for (int k = 0; k < 20; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < m; j++) {

                    if (rand.NextDouble() > p) {
                        cells[i, j] = Cells.Empty;
                    } else if (rand.NextDouble() > 0.5) {
                        cells[i, j] = Cells.East;
                    }
                    else {
                        cells[i, j] = Cells.North;
                    }
      
                }
            }

            Bitmap bm = DrawCells(cells);
            bm.Save("test" + k + ".png");


            //var p = 
                Process.Start("/usr/bin/convert", Environment.CurrentDirectory + "/*.png " + Environment.CurrentDirectory + "/movie.gif");

            
            
            
            for (int i = 0; i < 20; i++) {
               // File.Delete("test" + i + ".png");
            }
            
        }

        


    }


    public static Bitmap DrawCells(Cells[,] cells) {
        int scale = 20;

        int n = cells.GetLength(0) * scale, m = cells.GetLength(1) * scale;


        Bitmap bm = new Bitmap(n, m);
        
        Graphics gr = Graphics.FromImage(bm);

        for (int i = 0; i < cells.GetLength(0); i++) {
            for (int j = 0; j < cells.GetLength(1); j++) {

                Color c = cells[i,j] == Cells.Empty? Color.White: (cells[i,j]== Cells.East? Color.Red : Color.Blue);
                
                gr.FillRectangle(new SolidBrush(c), i * scale, j * scale, scale, scale);
                
            }
            
        }
        
        return bm;

    }
    
    
    
    
    

}
