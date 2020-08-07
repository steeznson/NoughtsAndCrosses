using System;
using System.Collections.Generic;
using System.Linq;

namespace Game{
    class Grid{
        private List<string> row0;
        private List<string> row1;
        private List<string> row2;

        public bool notFull() {
            bool emptyCells0 = this.row0.Any(i => i == null);
            bool emptyCells1 = this.row1.Any(i => i == null);
            bool emptyCells2 = this.row2.Any(i => i == null);
            return (emptyCells0 || emptyCells1 || emptyCells2);
        }

        public bool win() {
            bool leftDiagonal = this.leftDiagonal();
            bool rightDiagonal = this.rightDiagonal();
            bool horizontal = this.horizontal();
            bool vertical = this.vertical();
            return (leftDiagonal || rightDiagonal || horizontal || vertical);
        }

        public bool leftDiagonal(){
            if (!(string.IsNullOrEmpty(this.row0[0]) ||
                string.IsNullOrEmpty(this.row1[1]) ||
                string.IsNullOrEmpty(this.row2[2]))) {
                return (this.row0[0].Equals(this.row1[1]) && this.row1[1].Equals(this.row2[2]));
            } else {
                return false;
            }
        }

        public bool rightDiagonal(){
            if (!(string.IsNullOrEmpty(this.row0[2]) ||
                string.IsNullOrEmpty(this.row1[1]) ||
                string.IsNullOrEmpty(this.row2[0]))) {
                return (this.row0[2].Equals(this.row1[1]) && this.row1[1].Equals(this.row2[0]));
            } else {
                return false;
            }
        }

        // todo
        public bool horizontal(){
            return false;
        }

        // todo
        public bool vertical(){
            return false;
        }

        public List<string> getRow0() {
            return this.row0;
        }
        public void setRow0(List<string> newRow) {
            this.row0 = newRow;
        }
        public List<string> getRow1() {
            return this.row1;
        }
        public void setRow1(List<string> newRow) {
            this.row1 = newRow;
        }
        public List<string> getRow2() {
            return this.row2;
        }
        public void setRow2(List<string> newRow) {
            this.row2 = newRow;
        }
    }
}
