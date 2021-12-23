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
                return (this.row0[0].Equals(this.row1[1]) &&
                        this.row1[1].Equals(this.row2[2]));
            } else {
                return false;
            }
        }

        public bool rightDiagonal(){
            if (!(string.IsNullOrEmpty(this.row0[2]) ||
                string.IsNullOrEmpty(this.row1[1]) ||
                string.IsNullOrEmpty(this.row2[0]))) {
                return (this.row0[2].Equals(this.row1[1]) &&
                        this.row1[1].Equals(this.row2[0]));
            } else {
                return false;
            }
        }

        private bool rowIsComplete(List<string> row){
            if (!(string.IsNullOrEmpty(row[0]) ||
                string.IsNullOrEmpty(row[1]) ||
                string.IsNullOrEmpty(row[2]))) {
                    return (row[0].Equals(row[1]) &&
                            row[1].Equals(row[2]));
                }
            return false;
        }

        public bool horizontal(){
            bool completeRow = false;
            if(this.rowIsComplete(row0) ||
                this.rowIsComplete(row1) ||
                this.rowIsComplete(row2)){
                completeRow = true;
            }
            return completeRow;
        }

        private bool columnIsComplete(int index){
            if (!(string.IsNullOrEmpty(this.row0[index]) ||
                string.IsNullOrEmpty(this.row1[index]) ||
                string.IsNullOrEmpty(this.row2[index]))) {
                    return (this.row0[index].Equals(this.row1[index]) &&
                            this.row1[index].Equals(this.row2[index]));
                }
            return false;
        }

        public bool vertical(){
            bool completeColumn = false;
            if(this.columnIsComplete(0) ||
                this.columnIsComplete(1) ||
                this.columnIsComplete(2)){
                completeColumn = true;
            }
            return completeColumn;
            
        }

        public void print(){
            Console.WriteLine(String.Join(", ", this.getRow0()));
            Console.WriteLine(String.Join(", ", this.getRow1()));
            Console.WriteLine(String.Join(", ", this.getRow2()));
        }

        public List<string> getRow0() {
            return this.row0;
        }

        public List<string> getRow1() {
            return this.row1;
        }
        public List<string> getRow2() {
            return this.row2;
        }

        public void setRow(List<string> newRow, int rowIndex){
            switch (rowIndex){
                case 0:
                    this.row0 = newRow;
                    break;
                case 1:
                    this.row1 = newRow;
                    break;
                case 2:
                    this.row2 = newRow;
                    break;
            }
        }
    }
}
