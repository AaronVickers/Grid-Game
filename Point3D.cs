using System;

namespace GridGame {

    public class Point3D {

        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        // Constructor
        public Point3D(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void IncX(int inc) {
            x += inc;
        }

        public void IncY(int inc) {
            y += inc;
        }

        public void IncZ(int inc) {
            z += inc;
        }

        // Overrides
        public override bool Equals(object obj) {
            if (obj != null && obj is Point3D other) {
                if (other.x == x && other.y == y && other.z == z) {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode() {
            return System.HashCode.Combine(x, y, z);
        }

    }

}
