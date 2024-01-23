/*
 * Name: Bilal Ozdemir
 * 
 * Created November 30, 2023
 * 
 * Final Revision December 6, 2023
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOzdemirQGame
{
    public partial class Play : Form
    {
        // Fields to store the game's state and components.

        private BoxMovingController boxMovingController;
        private Dictionary<Point, PictureBox> pictureBoxGrid;
        private PictureBox selectedImage;
        private int pboxSize = 60;
        private Image noneImage;
        private Image greenBoxImage;
        private Image redBoxImage;
        private Image greenDoorImage;
        private Image redDoorImage;
        private Image wallImage;
        public int boxCount = 0;
        public int moveCount = 0;
        public bool isGameSetup = false;
        public bool isGameInitialized = false;



        //Constants representing different game elements.

        const int CONTENT_NONE = 0;
        const int CONTENT_WALL = 1;
        const int CONTENT_REDDOOR = 2;
        const int CONTENT_GREENDOOR = 3;
        const int CONTENT_REDBOX = 4;
        const int CONTENT_GREENBOX = 5;

        /// <summary>
        /// Initializes the Play form and its components.
        /// </summary>
        public Play()
        {
            InitializeComponent();
            pictureBoxGrid = new Dictionary<Point, PictureBox>();

            SetupImageResources();
            CollisionDetector collider = new CollisionDetector(pictureBoxGrid, wallImage, greenDoorImage, redDoorImage);
            boxMovingController = new BoxMovingController(pictureBoxGrid, pboxSize, collider, greenBoxImage, redBoxImage, txtNumberOfMoves, txtRemainingBoxes, this);
            boxMovingController.OnMoveCountChanged += UpdateMoveCount;


        }
        /// <summary>
        /// Set ups images for game elements from resources.
        /// </summary>
        private void SetupImageResources()
        {
            wallImage = Properties.Resources.wall;
            greenBoxImage = Properties.Resources.greenbox;
            redBoxImage = Properties.Resources.redbox;
            greenDoorImage = Properties.Resources.greendoor;
            redDoorImage = Properties.Resources.reddoor;
        }

        /// <summary>
        /// Handles click events on game's PictureBox elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null)
            {
                if (IsBox(clickedPictureBox.Image))
                {
                    ResetBoxBorders();
                    selectedImage = clickedPictureBox;
                    boxMovingController.SelectBoxForMovement(clickedPictureBox);
                    HighlightSelectedBox();
                }
                else
                {
                    MessageBox.Show("Please select a box to move.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Loads the game file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "QGame Files (*.qgame)|*.qgame|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GenerateGridFromSavedFile(openFileDialog.FileName);
                        boxCount = CalculateTotalBoxes();
                        txtRemainingBoxes.Text = boxCount.ToString();
                        isGameInitialized = true; 

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while loading the File: " + ex.Message, "Error");
                    }
                }
            }
        }
        /// <summary>
        /// Checks if the game is initialized
        /// </summary>
        /// <returns></returns>
        public bool IsGameInitialized()
        {
            return isGameInitialized;
        }


        /// <summary>
        /// Calculates the total boxes in the maze
        /// </summary>
        /// <returns></returns>
        private int CalculateTotalBoxes()
        {
            int boxCount = 0;

           
            foreach (var pictureBox in pictureBoxGrid.Values)
            {
               
                if (pictureBox.Image == greenBoxImage || pictureBox.Image == redBoxImage)
                {
                    boxCount++;
                }
            }

            return boxCount;
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void ResetGame()
        {
            pnlDisplayMaze.Controls.Clear();

            pictureBoxGrid.Clear();

            boxMovingController.ResetGame();

            txtNumberOfMoves.Text = "0";
            txtRemainingBoxes.Text = "0";
        }
        public void UpdateMoveCount(int moveCount)
        {
            txtNumberOfMoves.Text = moveCount.ToString();
        }

        /// <summary>
        /// Determines what image will be displayed for each cell
        /// </summary>
        /// <param name="cellContent"></param>
        /// <returns></returns>
        private Image DetermineImageForCell(int cellContent)
        {
            switch (cellContent)
            {
                case CONTENT_NONE: return noneImage;
                case CONTENT_WALL: return wallImage;
                case CONTENT_REDDOOR: return redDoorImage;
                case CONTENT_GREENDOOR: return greenDoorImage;
                case CONTENT_REDBOX: return redBoxImage;
                case CONTENT_GREENBOX: return greenBoxImage;
                default: return noneImage;
            }
        }


        private void ResetBoxBorders()
        {
            foreach (var pb in pictureBoxGrid.Values)
            {
                pb.BorderStyle = BorderStyle.FixedSingle; // Set default border style
            }
        }

        /// <summary>
        /// Highlights the selected box
        /// </summary>
        private void HighlightSelectedBox()
        {
            if (selectedImage != null)
            {
                selectedImage.BorderStyle = BorderStyle.Fixed3D; 
            }
        }
        /// <summary>
        /// checks if the image is a box
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private bool IsBox(Image image)
        {
            return image == greenBoxImage || image == redBoxImage;
        }

        private void RemoveAllPictureBoxes()
        {

            foreach (PictureBox pictureBox in pictureBoxGrid.Values)
            {
                pictureBox.Dispose();
            }
            pnlDisplayMaze.Controls.Clear();
        }

        /// <summary>
        /// Generates the grid from the loaded file
        /// </summary>
        /// <param name="filePath"></param>
        private void GenerateGridFromSavedFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
            {
                MessageBox.Show("Invalid file format.", "Error");
                return;
            }

            if (int.TryParse(lines[0], out int rows) && int.TryParse(lines[1], out int columns))
            {
                RemoveAllPictureBoxes();
                ConstructGameGrid(rows, columns);

                for (int i = 2; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(' ');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col) && int.TryParse(parts[2], out int cellContent))
                    {
                        Point gridPosition = new Point(row, col);
                        if (pictureBoxGrid.TryGetValue(gridPosition, out PictureBox pictureBox))
                        {
                            pictureBox.Image = DetermineImageForCell(cellContent);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row and column counts in the file.", "Error");
            }

        }

        private void ConstructGameGrid(int rows, int columns)
        {
            RemoveAllPictureBoxes();
            pictureBoxGrid.Clear();
            int pictureBoxWidth = pnlDisplayMaze.Width / columns;
            int pictureBoxHeight = pnlDisplayMaze.Height / rows;


          
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    
                    PictureBox pictureBox = new PictureBox
                    {
                        Width = pboxSize, 
                        Height = pboxSize, 
                        Left = col * pboxSize,
                        Top = row * pboxSize, 
                        BackColor = Color.LightGray, 
                        BorderStyle = BorderStyle.FixedSingle, 
                        Image = null, 
                        SizeMode = PictureBoxSizeMode.StretchImage 
                    };
                    pictureBox.Click += PictureBox_Click; 

                    pnlDisplayMaze.Controls.Add(pictureBox);
                    pictureBoxGrid[new Point(row, col)] = pictureBox;
                }
            }
            isGameSetup = true; 
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            boxMovingController.MoveElement("up");

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            boxMovingController.MoveElement("left");

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            boxMovingController.MoveElement("down");

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            boxMovingController.MoveElement("right");

        }
    }
}
