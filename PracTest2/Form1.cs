using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //number of pixels from top to bottom of seating area of plane
        const int PLANE_WIDTH = 45;
        //number of pixels from start to end of seating area of plane
        const int PLANE_LENGTH = 375;
        //number of pixels to left edge of seating area of plane
        const int SEAT_STARTX = 62;
        //number of pixels to top edge of seating area of plane
        const int SEAT_STARTY = 222;
        //number of pixels from top to bottom of seat
        const int SEAT_WIDTH = 10;
        //number of pixels from start to end of seat
        const int SEAT_LENGTH = 10;
        //number of seats in each row of the plane.
        const int SEATS_IN_ROW = 4;
        //number of rows that are first class, from front of plane
        const int ROWS_FIRST_CLASS = 5;
        //The gap between the rows of seats
        const int ROW_GAP = 3;
        //The gap between the B and C seats
        const int AISLE_GAP = 5;

        //Minimum number of rows
        const int MIN_ROWS = 2;
        //Maximum number of rows
        const int MAX_ROWS = 25;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the picture box and textbox and sets focus to the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
            textBoxRows.Clear();
            textBoxRows.Focus();
        }

        private void buttonDrawSeats_Click(object sender, EventArgs e)
        {
            Graphics paper = pictureBoxDisplay.CreateGraphics();
            Pen pen1 = new Pen(Color.Blue, 1);
            int x = SEAT_STARTX;
            int y = SEAT_STARTY;
            int numRows = 0;
            int gapSize = 0;

            try
            {
                //Get the number of rows
                numRows = int.Parse(textBoxRows.Text);
                //Check if the number of rows is valid
                if (numRows >= MIN_ROWS && numRows <= MAX_ROWS)
                {
                    //Calculate the gap size
                    gapSize = PLANE_LENGTH / numRows - SEAT_LENGTH;
                    //Add the gap amount to the first seat position
                    x += gapSize;
                    //FOR each line of seats to draw
                    for (int line = 1; line <= SEATS_IN_ROW; line++)
                    {
                        //FOR each seat to draw
                        for (int seat = 1; seat <= numRows; seat++)
                        {
                            //Check if current seat is a first class seat
                            if (seat <= ROWS_FIRST_CLASS)
                            {
                                pen1.Color = Color.Red;
                            }
                            else
                            {
                                pen1.Color = Color.Blue;
                            }
                            //Draw seat at current x and y position
                            paper.DrawRectangle(pen1, x, y, SEAT_WIDTH, SEAT_LENGTH); // Dont use const for your x and y positions
                            //SHIFT to the right by the width of the seat + gap
                            x += SEAT_WIDTH + gapSize;
                            //Pause the application
                            //System.Threading.Thread.Sleep(200);
                        }
                        //SHIFT y down by the height of the seat
                        y += SEAT_LENGTH;
                        //Check if drawn all the B seats
                        if (line == 2)
                        {
                            //SHIFT y down by the aisle gap
                            y += AISLE_GAP;
                        }
                        //SHIFT x to the start of the line
                        x = SEAT_STARTX + gapSize;
                    }
                   
                    
                }
                else
                {
                    //Display an error message and clear and give the focus
                    MessageBox.Show("Please enter a value between 2 and 25 inclusive");
                    textBoxRows.Clear();
                    textBoxRows.Focus();
                }
            }
            catch (Exception ex)
            {
                //Display an error message and clear and give the focus
                MessageBox.Show(ex.Message);
                textBoxRows.Clear();
                textBoxRows.Focus();
            }
        }
    }
}
