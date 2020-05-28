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

        public Form1()
        {
            InitializeComponent();
        }
    }
}
