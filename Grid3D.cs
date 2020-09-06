using System;

namespace GridGame {

    public class Grid3D {

        private Random rand;

        public int sizeX { get; private set; }
        public int sizeY { get; private set; }
        public int sizeZ { get; private set; }

        // Constructor
        public Grid3D(int sizeX, int sizeY, int sizeZ) {
            rand = new Random();

            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;
        }
        
        // Methods
        public bool IsPointInRange(Point3D point) {
            int x = point.x;
            int y = point.y;
            int z = point.z;

            if (x < 0 || y < 0 || z < 0) { // Check below 0 boundary
                return false;
            } else if (y >= sizeX || y >= sizeY || z >= sizeZ) { // Check above or equal to size boundaries
                return false;
            }

            return true;
        }

        public int GetRandomX() {
            return rand.Next(sizeX);
        }

        public int GetRandomY() {
            return rand.Next(sizeY);
        }

        public int GetRandomZ() {
            return rand.Next(sizeZ);
        }

        public Point3D GetRandomPoint() {
            int x = this.GetRandomX();
            int y = this.GetRandomY();
            int z = this.GetRandomZ();

            return new Point3D(x, y, z);
        }

    }

}
