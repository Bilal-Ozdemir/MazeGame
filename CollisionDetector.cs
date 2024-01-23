using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BOzdemirQGame
{
    public class CollisionDetector
    {
        private Dictionary<Point, PictureBox> gridPictureBoxes;
        private Image doorImageGreen;
        private Image doorImageRed;
        private Image imageWall;

        public CollisionDetector(Dictionary<Point, PictureBox> grid, Image wall, Image greenDoor, Image redDoor)
        {
            gridPictureBoxes = grid;
            imageWall = wall;
            doorImageGreen = greenDoor;
            doorImageRed = redDoor;
        }

        public bool CanMoveTo(Point newPosition)
        {
            // Check if the new position is within the bounds of the grid
            if (!gridPictureBoxes.ContainsKey(newPosition))
                return false;

            PictureBox targetBox = gridPictureBoxes[newPosition];
            return CanGoThrough(targetBox);
        }

        private bool CanGoThrough(PictureBox pictureBox)
        {
            return pictureBox.Image != imageWall;
        }

        /// <summary>
        /// Checms if picturebox represents the green door
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        public bool IsGreenDoor(PictureBox pictureBox)
        {
            // Use the global variable for the green door image
            return pictureBox.Image == doorImageGreen;
        }

        /// <summary>
        /// checks the picturebox represent the Red Door
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        public bool IsRedDoor(PictureBox pictureBox)
        {
            // Use the global variable for the red door image
            return pictureBox.Image == doorImageRed;
        }
    }
}


