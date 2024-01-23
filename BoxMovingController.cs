using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BOzdemirQGame
{
    internal class BoxMovingController
    {
        private Dictionary<Point, PictureBox> pictureBoxGrid;
        private PictureBox selectedImage;
        private int pboxSize = 60;
        private CollisionDetector collider;
        private Image greenBoxImage;
        private Image redBoxImage;
        private int moveCount = 0;
        private int boxCount = 1;
        private Play playFormInstance;

        private TextBox txtNumberOfMoves; // TextBox for number of moves
        private TextBox txtRemainingBoxes; // TextBox for remaining boxes count

        public event Action<int> OnMoveCountChanged;

        /// Initializing controller with parameters.
        public BoxMovingController(Dictionary<Point, PictureBox> grid, int size, CollisionDetector collision, Image greenBox, Image redBox, TextBox movesTextBox, TextBox boxesTextBox, Play playInstance)
        {
            pictureBoxGrid = grid;
            pboxSize = size;
            collider = collision;
            greenBoxImage = greenBox;
            redBoxImage = redBox;
            txtNumberOfMoves = movesTextBox; // Assign the TextBox for number of moves
            txtRemainingBoxes = boxesTextBox; // Assign the TextBox for remaining boxes count
            playFormInstance = playInstance;
        }

        /// <summary>
        /// Selects a box to move.
        /// </summary>
        /// <param name="element"></param>
        public void SelectBoxForMovement(PictureBox element) => selectedImage = element;

        /// <summary>
        /// Moves the selected box in the desired direction.
        /// </summary>
        /// <param name="direction"></param>
        public void MoveElement(string direction)
        {
            if (selectedImage == null) return;

            Point currentLocation = selectedImage.Location;
            int currentRow = currentLocation.Y / pboxSize;
            int currentCol = currentLocation.X / pboxSize;

            (int rowDelta, int colDelta) = direction.ToLower() switch
            {
                "up" => (-1, 0),
                "down" => (1, 0),
                "left" => (0, -1),
                "right" => (0, 1),
                _ => (0, 0)
            };

            bool moveMade = MoveBoxes(rowDelta, colDelta);
            if (moveMade)
            {
                IncreaseMoveCounter();
            }
            UpdateRemainingBoxesCount();
            ClearBoxAtExit(selectedImage);
        }

        /// <summary>
        /// Moves the boxes on the grid.
        /// </summary>
        /// <param name="rowDelta"></param>
        /// <param name="colDelta"></param>
        /// <returns></returns>
        private bool MoveBoxes(int rowDelta, int colDelta)
        {
            bool moveMade = false;
            while (true)
            {
                int currentRow = selectedImage.Location.Y / pboxSize;
                int currentCol = selectedImage.Location.X / pboxSize;
                Point nextLocation = new Point(currentRow + rowDelta, currentCol + colDelta);
                if (!collider.CanMoveTo(nextLocation) || !IsBoxMovable(pictureBoxGrid[nextLocation])) break;

                PictureBox nextBox = pictureBoxGrid[nextLocation];
                nextBox.Image = selectedImage.Image;
                selectedImage.Image = null;
                selectedImage = nextBox;

                moveMade = true;
            }
            return moveMade;
        }

        /// <summary>
        /// Updates the remaining boxes.
        /// </summary>
        /// <param name="boxesTextBox"></param>
        private void UpdateRemainingBoxesCount()
        {
            boxCount = pictureBoxGrid.Values.Count(pictureBox => pictureBox.Image == greenBoxImage || pictureBox.Image == redBoxImage);
            txtRemainingBoxes.Text = boxCount.ToString();
            if (boxCount == 0 && playFormInstance?.isGameInitialized == true)
            {
                MessageBox.Show("You Won!\n Game is over");
                ResetGameAfterWin();
            }
        }

        /// <summary>
        /// Updates the displayed move count.
        /// </summary>
        private void IncreaseMoveCounter()
        {
            moveCount++;
            OnMoveCountChanged?.Invoke(moveCount);
            txtNumberOfMoves.Text = moveCount.ToString();
        }

        /// <summary>
        /// Clears the box once it reaches its suitable door
        /// </summary>
        /// <param name="box"></param>
        private void ClearBoxAtExit(PictureBox box)
        {
            foreach (var kvp in pictureBoxGrid)
            {
                if (ArePointsAdjacent(kvp.Key, new Point(box.Location.Y / pboxSize, box.Location.X / pboxSize)))
                {
                    PictureBox adjacentBox = kvp.Value;
                    if ((box.Image == greenBoxImage && collider.IsGreenDoor(adjacentBox)) ||
                        (box.Image == redBoxImage && collider.IsRedDoor(adjacentBox)))
                    {
                        box.Image = null;
                        break;
                    }
                }
            }
            UpdateRemainingBoxesCount();
            txtRemainingBoxes.Text = boxCount.ToString();
            if (boxCount == 0 && playFormInstance.isGameInitialized)
            {
                MessageBox.Show("You Won!\n Game is over");
                ResetGameAfterWin();
            }
        }

        /// <summary>
        /// Resets the game to initial form
        /// </summary>
        public void ResetGame()
        {
            moveCount = 0;
            boxCount = 0;
            selectedImage = null;
        }

        /// <summary>
        /// Resets game after winning
        /// </summary>
        private void ResetGameAfterWin() => (playFormInstance as Play)?.ResetGame();

        /// <summary>
        /// Checks if two points on the grid are adjacent.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private bool ArePointsAdjacent(Point p1, Point p2) => (Math.Abs(p1.X - p2.X) == 1 && p1.Y == p2.Y) || (Math.Abs(p1.Y - p2.Y) == 1 && p1.X == p2.X);

        /// <summary>
        /// Checks if a box is movable 
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <returns></returns>
        private bool IsBoxMovable(PictureBox pictureBox) => pictureBox.Image == null;
    }
}


