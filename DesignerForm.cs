/*
 * Assignment 2
 * 
 * Name: Bilal Ozdemir
 * 
 * Date: November 1, 2023
 * 
 * Latest Revision Date: November 7, 2023
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOzdemirQGame
{
    public partial class DesignerForm : Form
    {
        // Determines the image that's going to be used when clicking on a cell on the grid.
        private Image selectedImage;
        // 2d array for the grid. 
        private PictureBox[,] pictureBoxGrid;
        //Converts the images to an int value. 
        private Dictionary<Image, int> imageToContentValue = new Dictionary<Image, int>();

        // Some constant values
        const int GRID_CELL_SIZE = 50;
        const int CONTENT_NONE = 0;
        const int CONTENT_WALL = 1;
        const int CONTENT_REDDOOR = 2;
        const int CONTENT_GREENDOOR = 3;
        const int CONTENT_REDBOX = 4;
        const int CONTENT_GREENBOX = 5;




        public DesignerForm()
        {
            InitializeComponent();

            Image noneImageInstance = BOzdemirQGame.Properties.Resources.none;
            Image wallImageInstance = BOzdemirQGame.Properties.Resources.wall;
            Image redDoorImageInstance = BOzdemirQGame.Properties.Resources.reddoor;
            Image greenDoorImageInstance = BOzdemirQGame.Properties.Resources.greendoor;
            Image redBoxImageInstance = BOzdemirQGame.Properties.Resources.redbox;
            Image greenBoxImageInstance = BOzdemirQGame.Properties.Resources.greenbox;

           
            pboxNone.Image = noneImageInstance;
            pboxWall.Image = wallImageInstance;
            pboxRedDoor.Image = redDoorImageInstance;
            pboxGreenDoor.Image = greenDoorImageInstance;
            pboxRedBox.Image = redBoxImageInstance;
            pboxGreenBox.Image = greenBoxImageInstance;

           
            btnNone.Tag = noneImageInstance;
            btnWall.Tag = wallImageInstance;
            btnRedDoor.Tag = redDoorImageInstance;
            btnGreenDoor.Tag = greenDoorImageInstance;
            btnRedBox.Tag = redBoxImageInstance;
            btnGreenBox.Tag = greenBoxImageInstance;

          
            imageToContentValue[noneImageInstance] = CONTENT_NONE;
            imageToContentValue[wallImageInstance] = CONTENT_WALL;
            imageToContentValue[redDoorImageInstance] = CONTENT_REDDOOR;
            imageToContentValue[greenDoorImageInstance] = CONTENT_GREENDOOR;
            imageToContentValue[redBoxImageInstance] = CONTENT_REDBOX;
            imageToContentValue[greenBoxImageInstance] = CONTENT_GREENBOX;


            btnNone.Click += imageButton_Click;
            btnWall.Click += imageButton_Click;
            btnRedDoor.Click += imageButton_Click;
            btnGreenDoor.Click += imageButton_Click;
            btnRedBox.Click += imageButton_Click;
            btnGreenBox.Click += imageButton_Click;


        }
       
        /// <summary>
        /// Sets the selectedImage to the image that's been clicked.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            selectedImage = (Image)button.Tag;
        }

        /// <summary>
        /// It displays the selectedImage on the grid. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;

            if (selectedImage != null)
            {
                picBox.Image = selectedImage;
                
                if (imageToContentValue.TryGetValue(selectedImage, out int value))
                {
                    picBox.Tag = value;
                }
                else
                {
                    
                    picBox.Tag = 0;
                }
            }
        }
        /// <summary>
        /// Generates the grid when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text, out int row) || row <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for the number of rows.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (!int.TryParse(txtColumns.Text, out int column) || column <= 0)
            {
                MessageBox.Show("Please enter a valid positive integer for the number of columns.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (pnlGrid.Controls.Count > 0)
            {
                var confirmNewGrid = MessageBox.Show("Creating a new grid will cause the current grid to be lost. Do you want to continue?","Confirm New Grid",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmNewGrid != DialogResult.Yes)
                {
                   
                    return;
                }
            }
            int rows = int.Parse(txtRows.Text);
            int columns = int.Parse(txtColumns.Text);

            pnlGrid.Controls.Clear();
            pnlGrid.Width = columns * GRID_CELL_SIZE; 
            pnlGrid.Height = rows * GRID_CELL_SIZE;

            pictureBoxGrid = new PictureBox[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = GRID_CELL_SIZE,
                        Height = GRID_CELL_SIZE,
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(j * GRID_CELL_SIZE, i * GRID_CELL_SIZE),
                        Image = BOzdemirQGame.Properties.Resources.none
                    };

                    pictureBox.Click += PictureBox_Click;
                    pnlGrid.Controls.Add(pictureBox);
                    pictureBoxGrid[i, j] = pictureBox;
                }
            }
            
        }

        /// <summary>
        /// This method saves the current loaded maze.
        /// </summary>
        private void SaveCurrentMaze()
        {

           
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "savegame1.qgame";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter file = new StreamWriter(sfd.FileName))
                        {
                            file.WriteLine(pictureBoxGrid.GetLength(0)); 
                            file.WriteLine(pictureBoxGrid.GetLength(1)); 

                            int doorNumber = 0;
                            int wallNumber = 0;
                            int boxNumber = 0;

                            for (int r = 0; r < pictureBoxGrid.GetLength(0); r++)
                            {
                                for (int c = 0; c < pictureBoxGrid.GetLength(1); c++)
                                {
                                    int cellValue = pictureBoxGrid[r, c].Tag != null ? (int)pictureBoxGrid[r, c].Tag : 0;

                                    // Count the items based on the cellValue
                                    if (cellValue == 1)
                                    {
                                        wallNumber++;
                                    }
                                    else if (cellValue == 2 || cellValue == 3)
                                    {
                                        doorNumber++;
                                    }
                                    else if (cellValue == 4 || cellValue == 5)
                                    {
                                        boxNumber++;
                                    }

                                    file.WriteLine($"{r} {c} {cellValue}");
                                }
                            }

                            string confirmationMessage = $"The file was saved successfully!\nWalls: {wallNumber}, Boxes: {boxNumber}, Doors: {doorNumber}";
                            MessageBox.Show(confirmationMessage, "File Save Confirmation");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the file: " + ex.Message, "Error");
                    }
                }
            }

        }

        /// <summary>
        /// The save option the menustrip, where I simply use the SaveCurrentMaze function. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentMaze();
        }

        /// <summary>
        /// Closes the DesignerForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
