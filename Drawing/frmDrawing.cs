// frmDrawing.cs, Drawing.sln
// CS 1181
// Katherine Wilsdon
// 4 December 2018
// Dr. Cody Permann

/* Description - Paints a picture of a house on the form */

/* WOW: 
 * 1. Created a randomized length of grass
 * 2. Filled in the house
 * 3. Filled in the roof
 * 4. Created a red door
 * 5. Created 2 windows
 * 6. Created a garage
 * 7. Created a fence
 * 8. Created a driveway and walkway
 * 9. Created a blue sky */

/* Cited:
 * Seed generation for random number generator: https://stackoverflow.com/questions/1785744/how-do-i-seed-a-random-class-to-avoid-getting-duplicate-random-values 
 * Book, Chapters 5, 6, 7, 8, and 9: Gaddis, T. (2017). Starting out with Visual C# (4th ed.). Boston, PA: Pearson.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing {
    public partial class frmDrawing : Form {
        public frmDrawing() {
            InitializeComponent();           
        }

        // Field variables
        int randomNum = 0;
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.SkyBlue);
        SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
        SolidBrush tanPen = new SolidBrush(Color.Tan);
        SolidBrush grayBrush = new SolidBrush(Color.Gray);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush mediumGrayBrush = new SolidBrush(Color.SlateGray);
        Pen offWhitePen = new Pen(Color.AntiqueWhite, 3);
        Pen lightGrayPen = new Pen(Color.LightGray, 2);
        Pen greenPen = new Pen(Color.Green);
        Pen grayPen = new Pen(Color.Gray, 2);               
        Random random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// Draws a blue sky in the background
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSky(Graphics graphics) {
            Point[] sky = { new Point(0, 0), new Point(700, 0), new Point(700, 500), new Point(0, 500) };
            graphics.FillPolygon(blueBrush, sky);
        }               

        /// <summary>
        /// Draws an orange sun in the sky
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSun(Graphics graphics) {
            graphics.FillEllipse(orangeBrush, 550, 50, 75, 75);
        }

        /// <summary>
        /// Draws grass at a random height
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawGrass(Graphics graphics) {
            //Create a point array and location array
            Point[] grass = new Point[2];
            int[] locationOfGrass = new int[700];
            for (int i = 0; i < 700; i++) {
                // Generates a random number between 0 and 9 and adds the height location
                randomNum = random.Next(10)+420;
                locationOfGrass[i] = i;
                // Draws a blade of grass
                grass[0] = new Point(i, 560);
                grass[1] = new Point(i, randomNum);
                graphics.DrawLines(greenPen, grass);
            }            
        }

        /// <summary>
        /// Draws a tan house
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawHouse(Graphics graphics) {
            Point[] house = { new Point(175, 250), new Point(525, 250), new Point(525, 450), new Point(175, 450) };
            graphics.FillPolygon(tanPen, house);
        }

        /// <summary>
        /// Draws a brown roof
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawRoof(Graphics graphics) {
            Point[] roof = { new Point(175, 250), new Point(350, 150), new Point(525, 250) };
            graphics.FillPolygon(brownBrush, roof);
        }

        /// <summary>
        /// Draws a red door and a gray doorknob
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawDoor(Graphics graphics) {
            // Draws a red door
            Point[] door = { new Point(325, 370), new Point(375, 370), new Point(375, 450), new Point(325, 450) };
            graphics.FillPolygon(redBrush, door);
            
            // Draws a doorknob
            graphics.FillEllipse(grayBrush, 330, 415, 7, 7);
        }

        /// <summary>
        /// Draws windows on the house
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawWindows(Graphics graphics) {
            // Draws the right window and trim
            Point[] rightWindow = { new Point(260, 330), new Point(310, 330), new Point(310, 425), new Point(260, 425) };
            graphics.FillPolygon(whiteBrush, rightWindow);
            graphics.DrawPolygon(offWhitePen, rightWindow);
            // Draws the style of the right window
            Point[] rightWindowStyle = { new Point(285, 330), new Point(285, 425) };
            Point[] rightWindowStyle2 = { new Point(260, 377), new Point(310, 377) };
            graphics.DrawLines(offWhitePen, rightWindowStyle);
            graphics.DrawLines(offWhitePen, rightWindowStyle2);

            // Draws the left window and trim
            Point[] leftWindow = { new Point(190, 330), new Point(240, 330), new Point(240, 425), new Point(190, 425) };
            graphics.FillPolygon(whiteBrush, leftWindow);
            graphics.DrawPolygon(offWhitePen, leftWindow);
            // Draws the style of the left window
            Point[] leftWindowStyle = { new Point(215, 330), new Point(215, 425) };
            Point[] leftWindowStyle2 = { new Point(190, 377), new Point(240, 377) };
            graphics.DrawLines(offWhitePen, leftWindowStyle);
            graphics.DrawLines(offWhitePen, leftWindowStyle2);
        }

        /// <summary>
        /// Draws the garage on the house
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawGarage(Graphics graphics) {
            // Draws the garage and trim
            Point[] garage = { new Point(400, 450), new Point(400, 320), new Point(515, 320), new Point(515, 450) };
            graphics.FillPolygon(whiteBrush, garage);
            graphics.DrawLines(offWhitePen, garage);
            // Draw the panels and handles on the garage
            DrawBoxesOnGarage(graphics);
            DrawHandlesOnGarage(graphics);                       
        }

        /// <summary>
        /// Draws the panels on the garage
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawBoxesOnGarage(Graphics graphics) {
            // Left Bottom panel, Right Bottom panel
            Point[] boxOnGarage1 = { new Point(407, 440), new Point(407, 420), new Point(450, 420), new Point(450, 440) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage1);
            Point[] boxOnGarage2 = { new Point(465, 440), new Point(465, 420), new Point(508, 420), new Point(508, 440) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage2);

            // Left Middle Bottom panel, Right Middle Bottom panel
            Point[] boxOnGarage3 = { new Point(407, 410), new Point(407, 390), new Point(450, 390), new Point(450, 410) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage3);
            Point[] boxOnGarage4 = { new Point(465, 410), new Point(465, 390), new Point(508, 390), new Point(508, 410) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage4);

            // Left Middle Top panel, Right Middle Top panel
            Point[] boxOnGarage5 = { new Point(407, 380), new Point(407, 360), new Point(450, 360), new Point(450, 380) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage5);
            Point[] boxOnGarage6 = { new Point(465, 380), new Point(465, 360), new Point(508, 360), new Point(508, 380) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage6);

            // Left Top panel, Right Top panel
            Point[] boxOnGarage7 = { new Point(407, 350), new Point(407, 330), new Point(450, 330), new Point(450, 350) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage7);
            Point[] boxOnGarage8 = { new Point(465, 350), new Point(465, 330), new Point(508, 330), new Point(508, 350) };
            graphics.DrawPolygon(offWhitePen, boxOnGarage8);          
        }

        /// <summary>
        /// Draw the handles on the garage door
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawHandlesOnGarage(Graphics graphics) {
            Point[] handle1 = { new Point(455, 405), new Point(455, 395) };
            Point[] handle2 = { new Point(460, 405), new Point(460, 395) };
            graphics.DrawLines(grayPen, handle1);
            graphics.DrawLines(grayPen, handle2);
        }

        /// <summary>
        /// Draw the fence to the right of the house
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawRightFence(Graphics graphics) {
            // Draw rectanglar fence
            Point[] fence1 = { new Point(525, 450), new Point(525, 390), new Point(620, 390), new Point(620, 450) };
            graphics.FillPolygon(whiteBrush, fence1);

            // Draw Middle post
            // Draw top of the middle post and trim
            Point[] topFence1 = { new Point(570, 390), new Point(575, 380), new Point(580, 390) };
            graphics.FillPolygon(whiteBrush, topFence1);
            Point[] topPost1 = { new Point(570, 390), new Point(575, 380), new Point(580, 390) };
            graphics.DrawLines(lightGrayPen, topPost1);
            // Draw vertical lines of the post
            Point[] post1Line1 = {  new Point(570, 450), new Point(570, 390)};
            graphics.DrawLines(lightGrayPen, post1Line1);
            Point[] post1Line2 = { new Point(580, 390), new Point(580, 450) };
            graphics.DrawLines(lightGrayPen, post1Line2);

            // Draw Right post
            // Draw top of the right post and trim
            Point[] topFence2 = { new Point(610, 390), new Point(615, 380), new Point(620, 390) };
            graphics.FillPolygon(whiteBrush, topFence2);
            Point[] topPost2 = { new Point(610, 390), new Point(615, 380), new Point(620, 390) };
            graphics.DrawLines(lightGrayPen, topPost2);
            // Draw vertical lines of the post
            Point[] post2Line1 = { new Point(610, 450), new Point(610, 390) };
            graphics.DrawLines(lightGrayPen, post2Line1);
            Point[] post2Line2 = { new Point(620, 390), new Point(620, 450) };
            graphics.DrawLines(lightGrayPen, post2Line2);

            // Draw Left post
            // Draw top of the left post and trim
            Point[] topFence3 = { new Point(525, 390), new Point(530, 380), new Point(535, 390) };
            graphics.FillPolygon(whiteBrush, topFence3);
            Point[] topPost3 = { new Point(525, 390), new Point(530, 380), new Point(535, 390) };
            graphics.DrawLines(lightGrayPen, topPost3);
            // Draw vertical lines of the post
            Point[] post3Line1 = { new Point(525, 450), new Point(525, 390) };
            graphics.DrawLines(lightGrayPen, post3Line1);
            Point[] post3Line2 = { new Point(535, 390), new Point(535, 450) };
            graphics.DrawLines(lightGrayPen, post3Line2);

            // Draw top lines between posts
            Point[] topFenceLine1 = { new Point(535, 390), new Point(570, 390) };
            graphics.DrawLines(lightGrayPen, topFenceLine1);
            Point[] topFenceLine2 = { new Point(580, 390), new Point(610, 390) };
            graphics.DrawLines(lightGrayPen, topFenceLine2);

        }
        /// <summary>
        /// Draw the fence to the right of the house
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawLeftFence(Graphics graphics) {
            // Draw rectanglar fence
            Point[] fence2 = { new Point(80, 450), new Point(80, 390), new Point(175, 390), new Point(175, 450) };
            graphics.FillPolygon(whiteBrush, fence2);

            // Draw Middle post
            // Draw top of the middle post and trim
            Point[] topFence1 = { new Point(120, 390), new Point(125, 380), new Point(130, 390) };
            graphics.FillPolygon(whiteBrush, topFence1);
            Point[] topPost1 = { new Point(120, 390), new Point(125, 380), new Point(130, 390) };
            graphics.DrawLines(lightGrayPen, topPost1);
            // Draw vertical lines of the post
            Point[] post1Line1 = { new Point(120, 450), new Point(120, 390) };
            graphics.DrawLines(lightGrayPen, post1Line1);
            Point[] post1Line2 = { new Point(130, 390), new Point(130, 450) };
            graphics.DrawLines(lightGrayPen, post1Line2);

            // Draw Right post
            // Draw top of the right post and trim
            Point[] topFence2 = { new Point(165, 390), new Point(170, 380), new Point(175, 390) };
            graphics.FillPolygon(whiteBrush, topFence2);
            Point[] topPost2 = { new Point(165, 390), new Point(170, 380), new Point(175, 390) };
            graphics.DrawLines(lightGrayPen, topPost2);
            // Draw vertical lines of the post
            Point[] post2Line1 = { new Point(165, 450), new Point(165, 390) };
            graphics.DrawLines(lightGrayPen, post2Line1);
            Point[] post2Line2 = { new Point(175, 390), new Point(175, 450) };
            graphics.DrawLines(lightGrayPen, post2Line2);

            // Draw Left post
            // Draw top of the left post and trim
            Point[] topFence3 = { new Point(80, 390), new Point(85, 380), new Point(90, 390) };
            graphics.FillPolygon(whiteBrush, topFence3);
            Point[] topPost3 = { new Point(80, 390), new Point(85, 380), new Point(90, 390) };
            graphics.DrawLines(lightGrayPen, topPost3);
            // Draw vertical lines of the post
            Point[] post3Line1 = { new Point(80, 450), new Point(80, 390) };
            graphics.DrawLines(lightGrayPen, post3Line1);
            Point[] post3Line2 = { new Point(90, 390), new Point(90, 450) };
            graphics.DrawLines(lightGrayPen, post3Line2);

            // Draw top lines between posts
            Point[] topFenceLine1 = { new Point(90, 390), new Point(120, 390) };
            graphics.DrawLines(lightGrayPen, topFenceLine1);
            Point[] topFenceLine2 = { new Point(130, 390), new Point(165, 390) };
            graphics.DrawLines(lightGrayPen, topFenceLine2); 
        }

        /// <summary>
        /// Draw Driveway to the garage
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawDriveway(Graphics graphics) {
            // Draw rectangular driveway
            Point[] driveway = { new Point(400, 450), new Point(400, 561), new Point(515, 561), new Point(515, 450) };
            graphics.FillPolygon(mediumGrayBrush, driveway);
            //Draw left triangle of driveway
            Point[] drivewayTriangle1 = { new Point(400, 450), new Point(400, 561), new Point(380, 561) };
            graphics.FillPolygon(mediumGrayBrush, drivewayTriangle1);
            //Draw right triangle of drivewayt
            Point[] drivewayTriangle2 = { new Point(515, 450), new Point(515, 561), new Point(525, 561) };
            graphics.FillPolygon(mediumGrayBrush, drivewayTriangle2);
        }

        /// <summary>
        /// Draw walkway that goes from the driveway to door
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawWalkway(Graphics graphics) {
            //Connects to the driveway
            Point[] walkway1 = { new Point(325, 470), new Point(325, 510), new Point(400, 510), new Point(400, 470) };
            graphics.FillPolygon(mediumGrayBrush, walkway1);
            //Connects to the door
            Point[] walkway2 = { new Point(325, 450), new Point(375, 450), new Point(375, 470), new Point(325, 470) };
            graphics.FillPolygon(mediumGrayBrush, walkway2);            
        }

        /// <summary>
        /// Main code for Paint handling
        /// </summary>
        /// <param name="graphics"></param>
        private void PaintMain(Graphics graphics) {
            DrawSky(graphics);
            DrawSun(graphics);
            DrawGrass(graphics);
            DrawHouse(graphics);
            DrawRoof(graphics);
            DrawDoor(graphics);
            DrawWindows(graphics);
            DrawGarage(graphics);
            DrawRightFence(graphics);
            DrawLeftFence(graphics);
            DrawDriveway(graphics);
            DrawWalkway(graphics);
            
        }
        /// <summary>
        /// Paints the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDrawing_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            PaintMain(graphics);
        }
    }
}
