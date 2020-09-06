using System;

namespace GridGame {

    public enum GuessResult {
        OutOfRange = 0,
        Hit = 1,
        Miss = 2,
    }

    public class GameController {

        private Random rand;
        private Grid3D grid;
        private Point3D target;

        public int guesses { get; private set; }

        // Constructor
        public GameController(int size) {
            rand = new Random();
            grid = new Grid3D(size, size, size);
            target = grid.GetRandomPoint();
            guesses = 0;
        }

        // Methods
        public GuessResult MakeGuess(Point3D point) {
            if (grid.IsPointInRange(point)) {
                guesses++;

                if (point.Equals(target)) {
                    return GuessResult.Hit; // Hit
                } else {
                    return GuessResult.Miss; // Miss
                }
            }

            return GuessResult.OutOfRange; // Out of range
        }

        public Point3D GetGuessOffsetAsPoint(Point3D point) {
            int offsetX = target.x-point.x;
            int offsetY = target.y-point.y;
            int offsetZ = target.z-point.z;

            return new Point3D(offsetX, offsetY, offsetZ);
        }

        public void MoveTarget() {
            int axis = rand.Next(3);
            int inc = rand.Next(2)*2-1;

            switch(axis) {
                case 0:
                    int resX = target.x+inc;

                    if (resX >= 0 && resX < grid.sizeX) {
                        target.IncX(inc);
                    } else {
                        target.IncX(-inc);
                    }

                    break;
                case 1:
                    int resY = target.y+inc;

                    if (resY >= 0 && resY < grid.sizeY) {
                        target.IncY(inc);
                    } else {
                        target.IncY(-inc);
                    }

                    break;
                case 2:
                    int resZ = target.z+inc;

                    if (resZ >= 0 && resZ < grid.sizeZ) {
                        target.IncZ(inc);
                    } else {
                        target.IncZ(-inc);
                    }

                    break;
            }
        }

    }

}
